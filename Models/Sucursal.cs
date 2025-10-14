using CazuelaChapina.API.Models.Base;

namespace CazuelaChapina.API.Models
{
    public class Sucursal : AuditEntity
    {
        public string Nombre { get; set; } = "";
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public ICollection<InventarioSaldo> Saldos { get; set; } = new List<InventarioSaldo>();
    }
}
