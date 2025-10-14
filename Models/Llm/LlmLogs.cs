using CazuelaChapina.API.Models.Base;

namespace CazuelaChapina.API.Models.Llm
{
    public class LlmPromptLog : AuditEntity
    {
        public string Origen { get; set; } = ""; // API/Backoffice/App
        public string Prompt { get; set; } = "";
        public string? Respuesta { get; set; }
        public int? HttpStatus { get; set; }
        public long? LatenciaMs { get; set; }
    }
}
