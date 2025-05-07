using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiReservasCanchas.Data;
using ApiReservasCanchas.Models;

namespace ApiReservasCanchas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HorarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Horario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horario>>> GetHorarios()
        {
            return await _context.Horarios.Include(h => h.Cancha).ToListAsync();
        }

        // GET: api/Horario/porCancha/5
        [HttpGet("porCancha/{canchaId}")]
        public async Task<ActionResult<IEnumerable<Horario>>> GetHorariosPorCancha(int canchaId)
        {
            var horarios = await _context.Horarios
                .Where(h => h.CanchaId == canchaId)
                .ToListAsync();

            return horarios;
        }

        // POST: api/Horario
        [HttpPost]
        public async Task<ActionResult<Horario>> PostHorario(Horario horario)
        {
            _context.Horarios.Add(horario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHorarios), new { id = horario.Id }, horario);
        }

        // PUT: api/Horario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorario(int id, Horario horario)
        {
            if (id != horario.Id)
                return BadRequest();

            _context.Entry(horario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Horario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorario(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);
            if (horario == null)
                return NotFound();

            _context.Horarios.Remove(horario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
