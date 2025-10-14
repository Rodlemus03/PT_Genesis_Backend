using CazuelaChapina.API.Models.Base;

namespace CazuelaChapina.API.Models
{
    public class Proveedor : AuditEntity
    {
        public string Nombre { get; set; } = "";
        public string? Contacto { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
    }
}
