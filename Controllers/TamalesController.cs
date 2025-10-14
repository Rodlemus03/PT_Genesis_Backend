using CazuelaChapina.API.Data;
using CazuelaChapina.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CazuelaChapina.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TamalesController : ControllerBase
    {
        private readonly AppDbContext _db;
        public TamalesController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _db.Tamales.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Tamal model)
        {
            _db.Tamales.Add(model);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var t = await _db.Tamales.FindAsync(id);
            return t == null ? NotFound() : Ok(t);
        }
    }
}
