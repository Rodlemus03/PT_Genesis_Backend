using CazuelaChapina.API.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Models
{
    public class Receta : AuditEntity
    {
        public TipoProductoLinea TipoProducto { get; set; }
        public int ProductoId { get; set; } // Id del Tamal/Bebida/Combo según TipoProducto
        public string? Notas { get; set; }

        public ICollection<RecetaItem> Items { get; set; } = new List<RecetaItem>();
    }

    public class RecetaItem : AuditEntity
    {
        public int RecetaId { get; set; }
        public Receta Receta { get; set; } = null!;

        public int MateriaPrimaId { get; set; }
        public MateriaPrima MateriaPrima { get; set; } = null!;

        [Precision(18, 4)]
        public decimal CantidadPorUnidad { get; set; } // cuánto consume una unidad de producto
        public string Unidad { get; set; } = "";       // misma unidad que el saldo
    }
}
