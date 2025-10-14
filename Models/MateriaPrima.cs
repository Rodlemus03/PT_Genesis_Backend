using CazuelaChapina.API.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Models
{
    public class MateriaPrima : AuditEntity
    {
        public string Nombre { get; set; } = "";
        public string Categoria { get; set; } = ""; // masa, hoja, proteína, grano, endulzante, especia, empaque, combustible, etc.
        public string Unidad { get; set; } = "kg";  // kg, g, l, ml, unidad
        [Precision(18, 4)]
        public decimal PuntoCritico { get; set; } = 0; // umbral para bloqueo de venta/producción
    }
}
