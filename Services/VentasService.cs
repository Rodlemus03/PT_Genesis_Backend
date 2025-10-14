using CazuelaChapina.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Data
{
    public class VentasService
    {
        private readonly AppDbContext _db;
        private readonly InventoryService _inv;
        public VentasService(AppDbContext db, InventoryService inv) { _db = db; _inv = inv; }

        public async Task<Venta> RegistrarAsync(Venta venta)
        {
            // Bloqueo por punto crítico
            foreach (var it in venta.Items)
            {
                var ok = await _inv.PuedeVenderAsync(it.TipoProducto,
                    it.TamalId ?? it.BebidaId ?? it.ComboId ?? 0, venta.SucursalId, it.Cantidad);
                if (!ok) throw new InvalidOperationException("Stock insuficiente o punto crítico alcanzado.");
            }

            // Totales
            venta.Subtotal = venta.Items.Sum(i => i.TotalLinea);
            venta.Impuestos = Math.Round(venta.Subtotal * 0.12m, 2); // IVA Guatemala 12% (ajusta si aplica)
            venta.Total = venta.Subtotal + venta.Impuestos;

            _db.Ventas.Add(venta);
            await _db.SaveChangesAsync();

            // Descontar inventario por receta de cada ítem
            foreach (var it in venta.Items)
            {
                var idProd = it.TamalId ?? it.BebidaId ?? it.ComboId ?? 0;
                await _inv.DescontarPorRecetaAsync(it.TipoProducto, idProd, venta.SucursalId, it.Cantidad, $"VENTA:{venta.Id}");
            }

            _db.Notificaciones.Add(new NotificacionEvento
            {
                Tipo = "VentaRealizada",
                Mensaje = $"Venta #{venta.Id} por Q{venta.Total}",
                SucursalId = venta.SucursalId,
                VentaId = venta.Id
            });
            await _db.SaveChangesAsync();

            return venta;
        }
    }
}
