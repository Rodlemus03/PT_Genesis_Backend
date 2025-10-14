using CazuelaChapina.API.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Models
{
    public class Combo : AuditEntity
    {
        public string Nombre { get; set; } = "";
        public string? Descripcion { get; set; }
        [Precision(18, 2)]
        public decimal Precio { get; set; }

        public bool EsEditableEnProduccion { get; set; } = false; // Para “Combo Estacional” editable sin redeploy

        public ICollection<ComboItem> Items { get; set; } = new List<ComboItem>();
    }

    public class ComboItem : AuditEntity
    {
        public int ComboId { get; set; }
        public Combo Combo { get; set; } = null!;

        public TipoProductoLinea TipoProducto { get; set; }
        public int? TamalId { get; set; }
        public Tamal? Tamal { get; set; }
        public int? BebidaId { get; set; }
        public Bebida? Bebida { get; set; }

        public int Cantidad { get; set; } = 1;
        public string? Notas { get; set; }
    }
}
