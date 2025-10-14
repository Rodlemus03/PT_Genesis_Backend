using CazuelaChapina.API.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Models
{
    // Permite precio diferenciado por presentación (unidad/6/12) para un tamal específico
    public class TamalPresentacionPrecio : AuditEntity
    {
        public int TamalId { get; set; }
        public Tamal Tamal { get; set; } = null!;
        public TamalPresentacion Presentacion { get; set; }

        [Precision(18, 2)]
        public decimal Precio { get; set; }
    }
}
