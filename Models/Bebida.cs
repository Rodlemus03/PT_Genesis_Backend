using CazuelaChapina.API.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Models
{
    public class Bebida : AuditEntity
    {
        public TipoBebida Tipo { get; set; }
        public Endulzante Endulzante { get; set; }
        public Topping Topping { get; set; } = Topping.Ninguno;
        public TamanoBebida Tamano { get; set; }

        [Precision(18, 2)]
        public decimal Precio { get; set; }

        public string? Sku { get; set; }
    }
}
