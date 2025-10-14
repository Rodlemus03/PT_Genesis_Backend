using CazuelaChapina.API.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Models
{
    public class Tamal : AuditEntity
    {
        public MasaTamal Masa { get; set; }
        public RellenoTamal Relleno { get; set; }
        public EnvolturaTamal Envoltura { get; set; }
        public PicanteTamal Picante { get; set; }

        // Precio por unidad; para 6 o 12 se calculará con reglas/combo
        [Precision(18, 2)]
        public decimal PrecioUnitario { get; set; }

        // Opcional: SKU interno
        public string? Sku { get; set; }
    }
}
