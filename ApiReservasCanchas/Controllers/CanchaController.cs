using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiReservasCanchas.Data;
using ApiReservasCanchas.Models;

namespace ApiReservasCanchas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CanchaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancha>>> GetCanchas()
        {
            return await _context.Canchas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cancha>> GetCancha(int id)
        {
            var cancha = await _context.Canchas.FindAsync(id);
            if (cancha == null)
                return NotFound();
            return cancha;
        }

        [HttpPost]
        public async Task<ActionResult<Cancha>> PostCancha(Cancha cancha)
        {
            _context.Canchas.Add(cancha);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCancha), new { id = cancha.Id }, cancha);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCancha(int id, Cancha cancha)
        {
            if (id != cancha.Id)
                return BadRequest();

            _context.Entry(cancha).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancha(int id)
        {
            var cancha = await _context.Canchas.FindAsync(id);
            if (cancha == null)
                return NotFound();

            _context.Canchas.Remove(cancha);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
