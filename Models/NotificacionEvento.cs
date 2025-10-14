using CazuelaChapina.API.Models.Base;

namespace CazuelaChapina.API.Models
{
    public class NotificacionEvento : AuditEntity
    {
        public string Tipo { get; set; } = ""; // VentaRealizada, LoteFinalizado, StockCritico
        public string Mensaje { get; set; } = "";
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public int? SucursalId { get; set; }
        public int? VentaId { get; set; }
        public int? LoteCoccionId { get; set; }
    }
}
