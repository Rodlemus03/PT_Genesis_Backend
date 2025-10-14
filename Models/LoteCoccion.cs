using CazuelaChapina.API.Models.Base;

namespace CazuelaChapina.API.Models
{
    public class LoteCoccion : AuditEntity
    {
        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; } = null!;

        public int TamalId { get; set; }
        public Tamal Tamal { get; set; } = null!;

        public int CantidadProgramada { get; set; }
        public int? CantidadObtenida { get; set; }

        public DateTime? Inicio { get; set; }
        public DateTime? Fin { get; set; }
        public EstadoLote Estado { get; set; } = EstadoLote.Pendiente;

        public string? Notas { get; set; } // telemetría, cronos, etc.
    }
}
