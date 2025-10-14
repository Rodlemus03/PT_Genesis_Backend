using CazuelaChapina.API.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Models
{
    public class InventarioSaldo : AuditEntity
    {
        public int MateriaPrimaId { get; set; }
        public MateriaPrima MateriaPrima { get; set; } = null!;

        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; } = null!;

        [Precision(18, 4)]
        public decimal Cantidad { get; set; } // existencias
        [Precision(18, 4)]
        public decimal CostoPromedio { get; set; } // costo promedio ponderado
        public MetodoCosto MetodoCosto { get; set; } = MetodoCosto.PromedioPonderado;
    }
}
