using CazuelaChapina.API.Data;
using CazuelaChapina.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BebidasController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BebidasController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _db.Bebidas.ToListAsync());
    }
}
