using CazuelaChapina.API.Data;
using CazuelaChapina.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly VentasService _ventas;
        public VentasController(AppDbContext db, VentasService ventas) { _db = db; _ventas = ventas; }

        [HttpPost]
        public async Task<IActionResult> Crear(Venta dto)
        {
            try
            {
                var v = await _ventas.RegistrarAsync(dto);
                return Ok(v);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> List() =>
            Ok(await _db.Ventas.Include(v => v.Items).OrderByDescending(v => v.Id).Take(50).ToListAsync());
    }
}
