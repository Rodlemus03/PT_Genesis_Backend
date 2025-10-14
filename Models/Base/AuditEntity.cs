namespace CazuelaChapina.API.Models.Base
{
    public abstract class AuditEntity
    {
        public int Id { get; set; }
        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
        public DateTime? ActualizadoEn { get; set; }
        public string? CreadoPor { get; set; }
        public string? ActualizadoPor { get; set; }
        public bool Activo { get; set; } = true;
    }
}
