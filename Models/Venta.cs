using CazuelaChapina.API.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Models
{
    public class Venta : AuditEntity
    {
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; } = null!;

        [Precision(18, 2)]
        public decimal Subtotal { get; set; }
        [Precision(18, 2)]
        public decimal Impuestos { get; set; }
        [Precision(18, 2)]
        public decimal Total { get; set; }

        public MedioPago MedioPago { get; set; } = MedioPago.Efectivo;

        public ICollection<VentaItem> Items { get; set; } = new List<VentaItem>();
    }

    public class VentaItem : AuditEntity
    {
        public int VentaId { get; set; }
        public Venta Venta { get; set; } = null!;

        public TipoProductoLinea TipoProducto { get; set; }
        public int? TamalId { get; set; }
        public Tamal? Tamal { get; set; }
        public int? BebidaId { get; set; }
        public Bebida? Bebida { get; set; }
        public int? ComboId { get; set; }
        public Combo? Combo { get; set; }

        public int Cantidad { get; set; }
        [Precision(18, 2)]
        public decimal PrecioUnitario { get; set; }
        [Precision(18, 2)]
        public decimal TotalLinea { get; set; }

        // Metadatos para analytics
        public PicanteTamal? Picante { get; set; } // útil para proporción picante vs no picante
        public TamanoBebida? TamanoBebida { get; set; }
        public TipoBebida? TipoBebida { get; set; }
    }
}
