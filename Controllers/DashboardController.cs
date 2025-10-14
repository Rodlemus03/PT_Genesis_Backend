using CazuelaChapina.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace CazuelaChapina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _svc;
        public DashboardController(DashboardService svc) => _svc = svc;

        [HttpGet("ventas")]
        public async Task<IActionResult> Ventas() => Ok(await _svc.VentasDiaMesAsync());

        [HttpGet("tamales-top")]
        public async Task<IActionResult> TamalesTop() => Ok(await _svc.TamalesTopAsync());

        [HttpGet("bebidas-hora")]
        public async Task<IActionResult> BebidasHora() => Ok(await _svc.BebidasPorHoraAsync());

        [HttpGet("picante")]
        public async Task<IActionResult> Picante() => Ok(await _svc.ProporcionPicanteAsync());

        [HttpGet("mermas")]
        public async Task<IActionResult> Mermas() => Ok(await _svc.DesperdicioAsync());
    }
}
