using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Data
{
    public class DashboardService
    {
        private readonly AppDbContext _db;
        public DashboardService(AppDbContext db) => _db = db;

        public async Task<object> VentasDiaMesAsync()
        {
            var hoy = DateTime.UtcNow.Date;
            var diarias = await _db.Ventas
                .Where(v => v.Fecha >= hoy.AddDays(-7))
                .GroupBy(v => v.Fecha.Date).Select(g => new { fecha = g.Key, total = g.Sum(x => x.Total) })
                .ToListAsync();

            var inicioMes = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            var mensuales = await _db.Ventas
                .Where(v => v.Fecha >= inicioMes)
                .GroupBy(v => v.Fecha.Date).Select(g => new { fecha = g.Key, total = g.Sum(x => x.Total) })
                .ToListAsync();

            return new { diarias, mensuales };
        }

        public async Task<object> TamalesTopAsync()
        {
            var q = await _db.VentaItems
                .Where(i => i.TipoProducto == Models.TipoProductoLinea.Tamal && i.TamalId != null)
                .GroupBy(i => i.TamalId!)
                .Select(g => new { tamalId = g.Key, cantidad = g.Sum(x => x.Cantidad) })
                .OrderByDescending(x => x.cantidad)
                .Take(10)
                .ToListAsync();
            return q;
        }

        public async Task<object> BebidasPorHoraAsync()
        {
            var q = await _db.VentaItems
                .Where(i => i.TipoProducto == Models.TipoProductoLinea.Bebida)
                .GroupBy(i => i.Venta.Fecha.Hour)
                .Select(g => new { hora = g.Key, cantidad = g.Sum(x => x.Cantidad) })
                .OrderBy(x => x.hora)
                .ToListAsync();
            return q;
        }

        public async Task<object> ProporcionPicanteAsync()
        {
            var q = await _db.VentaItems
                .Where(i => i.Picante != null)
                .GroupBy(i => i.Picante)
                .Select(g => new { picante = g.Key!.ToString(), cantidad = g.Sum(x => x.Cantidad) })
                .ToListAsync();
            return q;
        }

        public async Task<object> DesperdicioAsync()
        {
            var q = await _db.InventarioMovimientos
                .Where(m => m.Tipo == Models.TipoMovimientoInventario.Merma)
                .GroupBy(m => m.MateriaPrimaId)
                .Select(g => new { materiaId = g.Key, merma = g.Sum(x => x.Cantidad) })
                .ToListAsync();
            return q;
        }
    }
}
