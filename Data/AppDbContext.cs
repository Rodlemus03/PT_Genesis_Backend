using Microsoft.EntityFrameworkCore;
using CazuelaChapina.API.Models;
using CazuelaChapina.API.Models.Llm;

namespace CazuelaChapina.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Sucursal> Sucursales => Set<Sucursal>();

        public DbSet<MateriaPrima> MateriasPrimas => Set<MateriaPrima>();
        public DbSet<InventarioSaldo> InventarioSaldos => Set<InventarioSaldo>();
        public DbSet<InventarioMovimiento> InventarioMovimientos => Set<InventarioMovimiento>();

        public DbSet<Tamal> Tamales => Set<Tamal>();
        public DbSet<TamalPresentacionPrecio> TamalPresentaciones => Set<TamalPresentacionPrecio>();
        public DbSet<Bebida> Bebidas => Set<Bebida>();

        public DbSet<Combo> Combos => Set<Combo>();
        public DbSet<ComboItem> ComboItems => Set<ComboItem>();

        public DbSet<Receta> Recetas => Set<Receta>();
        public DbSet<RecetaItem> RecetaItems => Set<RecetaItem>();

        public DbSet<Venta> Ventas => Set<Venta>();
        public DbSet<VentaItem> VentaItems => Set<VentaItem>();

        public DbSet<LoteCoccion> LotesCoccion => Set<LoteCoccion>();

        public DbSet<Proveedor> Proveedores => Set<Proveedor>();
        public DbSet<NotificacionEvento> Notificaciones => Set<NotificacionEvento>();

        public DbSet<LlmPromptLog> LlmLogs => Set<LlmPromptLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unicidad de receta por producto
            modelBuilder.Entity<Receta>()
                .HasIndex(r => new { r.TipoProducto, r.ProductoId })
                .IsUnique();

            // Unicidad de presentación por Tamal
            modelBuilder.Entity<TamalPresentacionPrecio>()
                .HasIndex(tp => new { tp.TamalId, tp.Presentacion })
                .IsUnique();

            // Saldo único por Sucursal + Materia
            modelBuilder.Entity<InventarioSaldo>()
                .HasIndex(s => new { s.SucursalId, s.MateriaPrimaId })
                .IsUnique();

            // Índices para analítica rápida
            modelBuilder.Entity<Venta>()
                .HasIndex(v => v.Fecha);
            modelBuilder.Entity<VentaItem>()
                .HasIndex(vi => new { vi.TipoProducto, vi.TamalId, vi.BebidaId, vi.ComboId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
