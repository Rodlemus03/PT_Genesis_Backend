using CazuelaChapina.API.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Models
{
    public class InventarioMovimiento : AuditEntity
    {
        public int MateriaPrimaId { get; set; }
        public MateriaPrima MateriaPrima { get; set; } = null!;

        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; } = null!;

        public TipoMovimientoInventario Tipo { get; set; }
        [Precision(18, 4)]
        public decimal Cantidad { get; set; }
        [Precision(18, 4)]
        public decimal CostoUnitario { get; set; } // para actualizaciones de promedio
        [Precision(18, 2)]
        public decimal CostoTotal { get; set; }
        public string? Referencia { get; set; } // compra, ajuste, orden
        public string? Notas { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
