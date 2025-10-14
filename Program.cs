using CazuelaChapina.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Web API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Servicios de dominio
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<VentasService>();
builder.Services.AddScoped<DashboardService>();

var app = builder.Build();

// Log de ruta DB
var dbPath = Path.GetFullPath(Path.Combine(app.Environment.ContentRootPath, "AppData", "cazuela.db"));
Console.WriteLine($"[DB PATH] {dbPath}");

// Crear carpeta AppData si no existe
var dataDir = Path.Combine(app.Environment.ContentRootPath, "AppData");
if (!Directory.Exists(dataDir)) Directory.CreateDirectory(dataDir);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

// Aplicar migraciones y (opcional) seed controlado por flag
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await ctx.Database.MigrateAsync();

    // Flags: appsettings: "Seed:RunOnStartup"=true o variable de entorno SEED=1
    var seedFlag = builder.Configuration.GetValue<bool>("Seed:RunOnStartup");
    var envSeed  = Environment.GetEnvironmentVariable("SEED"); // "1" para forzar
    var runSeed  = seedFlag || envSeed == "1";

    if (runSeed)
    {
        await Seed.SeedAsync(ctx, force: true);
        Console.WriteLine("[SEED] Datos de ejemplo insertados.");
    }
    else
    {
        Console.WriteLine("[SEED] Saltado (Seed:RunOnStartup=false y SEED!=1).");
    }
}

app.Run();
