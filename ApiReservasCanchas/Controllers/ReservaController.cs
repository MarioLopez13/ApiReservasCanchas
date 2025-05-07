using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiReservasCanchas.Data;
using ApiReservasCanchas.Models;

namespace ApiReservasCanchas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(Reserva reserva)
        {
            // Validación 1: máximo 2 reservas por usuario por día
            var reservasHoy = await _context.Reservas
                .Where(r => r.UsuarioId == reserva.UsuarioId && r.Fecha.Date == reserva.Fecha.Date)
                .CountAsync();

            if (reservasHoy >= 2)
            {
                return BadRequest("Solo puedes tener 2 reservas por día.");
            }

            // Validación 2: evitar duplicidad en mismo horario
            var reservaExistente = await _context.Reservas.AnyAsync(r =>
                r.UsuarioId == reserva.UsuarioId &&
                r.Fecha.Date == reserva.Fecha.Date &&
                r.HoraInicio == reserva.HoraInicio &&
                r.HoraFin == reserva.HoraFin);

            if (reservaExistente)
            {
                return BadRequest("Ya tienes una reserva en ese horario.");
            }

            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReserva", new { id = reserva.Id }, reserva);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva>> GetReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null) return NotFound();
            return reserva;
        }

        [HttpGet("porUsuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReservasPorUsuario(int usuarioId)
        {
            return await _context.Reservas
                .Where(r => r.UsuarioId == usuarioId)
                .OrderByDescending(r => r.Fecha)
                .ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null) return NotFound();

            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
