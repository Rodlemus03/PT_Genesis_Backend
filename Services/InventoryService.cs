using CazuelaChapina.API.Data;
using CazuelaChapina.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Data
{
    public class InventoryService
    {
        private readonly AppDbContext _db;
        public InventoryService(AppDbContext db) => _db = db;

        // Aumenta o descuenta inventario y mantiene costo promedio
        public async Task MovimientoAsync(int sucursalId, int materiaId, TipoMovimientoInventario tipo,
            decimal cantidad, decimal? costoUnitario = null, string? refx = null)
        {
            var saldo = await _db.InventarioSaldos
                .FirstOrDefaultAsync(x => x.SucursalId == sucursalId && x.MateriaPrimaId == materiaId);

            if (saldo == null)
            {
                saldo = new InventarioSaldo
                {
                    SucursalId = sucursalId,
                    MateriaPrimaId = materiaId,
                    Cantidad = 0,
                    CostoPromedio = 0
                };
                _db.InventarioSaldos.Add(saldo);
                await _db.SaveChangesAsync();
            }

            decimal costoUnit = costoUnitario ?? saldo.CostoPromedio;

            // Actualizar promedio solo en entradas
            if (tipo == TipoMovimientoInventario.Entrada && costoUnitario.HasValue)
{
    var totalActual = saldo.Cantidad * saldo.CostoPromedio;
    var totalNuevo  = cantidad * costoUnitario.Value; // <- aquí SÍ es .Value
    var cantNueva   = saldo.Cantidad + cantidad;

    saldo.CostoPromedio = cantNueva <= 0 ? 0 : (totalActual + totalNuevo) / cantNueva;
}

            // Aplicar cantidad (+/-)
            saldo.Cantidad += tipo == TipoMovimientoInventario.Entrada ? cantidad : -cantidad;

            _db.InventarioMovimientos.Add(new InventarioMovimiento
            {
                SucursalId = sucursalId,
                MateriaPrimaId = materiaId,
                Tipo = tipo,
                Cantidad = cantidad,
                CostoUnitario = costoUnit,
                CostoTotal = Math.Round(costoUnit * cantidad, 2),
                Referencia = refx
            });

            await _db.SaveChangesAsync();

            // Validar punto crítico
            var mat = await _db.MateriasPrimas.FindAsync(materiaId);
            if (mat != null && saldo.Cantidad < mat.PuntoCritico)
            {
                _db.Notificaciones.Add(new NotificacionEvento
                {
                    Tipo = "StockCritico",
                    Mensaje = $"Stock crítico: {mat.Nombre} en sucursal {sucursalId}.",
                    SucursalId = sucursalId
                });
                await _db.SaveChangesAsync();
            }
        }

        // Descuenta según receta (n unidades * consumo por unidad)
        public async Task DescontarPorRecetaAsync(TipoProductoLinea tipo, int productoId, int sucursalId, int unidades, string refx)
        {
            var receta = await _db.Recetas
                .Include(r => r.Items)
                .FirstOrDefaultAsync(r => r.TipoProducto == tipo && r.ProductoId == productoId);

            if (receta == null) return;

            foreach (var it in receta.Items)
            {
                var consumo = it.CantidadPorUnidad * unidades;
                await MovimientoAsync(sucursalId, it.MateriaPrimaId, TipoMovimientoInventario.ConsumoReceta, consumo, null, refx);
            }
        }

        public async Task<bool> PuedeVenderAsync(TipoProductoLinea tipo, int productoId, int sucursalId, int unidades)
        {
            var receta = await _db.Recetas
                .Include(r => r.Items)
                .FirstOrDefaultAsync(r => r.TipoProducto == tipo && r.ProductoId == productoId);

            if (receta == null) return true; // si no hay receta, no bloqueamos

            foreach (var it in receta.Items)
            {
                var saldo = await _db.InventarioSaldos
                    .FirstOrDefaultAsync(s => s.SucursalId == sucursalId && s.MateriaPrimaId == it.MateriaPrimaId);

                var mat = await _db.MateriasPrimas.FindAsync(it.MateriaPrimaId);
                var requerido = it.CantidadPorUnidad * unidades;
                var disponible = saldo?.Cantidad ?? 0;

                if (disponible - requerido < (mat?.PuntoCritico ?? 0))
                    return false; // bloquear
            }
            return true;
        }
    }
}
