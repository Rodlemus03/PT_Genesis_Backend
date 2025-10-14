using CazuelaChapina.API.Data;
using CazuelaChapina.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriasPrimasController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly InventoryService _inv;
        public MateriasPrimasController(AppDbContext db, InventoryService inv) { _db = db; _inv = inv; }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _db.MateriasPrimas.OrderBy(x => x.Nombre).ToListAsync());

        [HttpPost("entrada")]
        public async Task<IActionResult> Entrada([FromQuery] int sucursalId, [FromBody] EntradaDto dto)
        {
            await _inv.MovimientoAsync(sucursalId, dto.MateriaPrimaId, TipoMovimientoInventario.Entrada, dto.Cantidad, dto.CostoUnitario, "ENTRADA");
            return Ok();
        }

        [HttpGet("saldos/{sucursalId}")]
        public async Task<IActionResult> Saldos(int sucursalId)
        {
            var q = await _db.InventarioSaldos
                .Include(s => s.MateriaPrima)
                .Where(s => s.SucursalId == sucursalId)
                .ToListAsync();
            return Ok(q);
        }
    }

    public record EntradaDto(int MateriaPrimaId, decimal Cantidad, decimal CostoUnitario);
}
