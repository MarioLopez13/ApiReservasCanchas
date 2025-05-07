using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiReservasCanchas.Data;
using ApiReservasCanchas.Models;

namespace ApiReservasCanchas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialOcupacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HistorialOcupacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialOcupacion>>> GetHistorial()
        {
            return await _context.HistorialesOcupacion.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<HistorialOcupacion>> PostHistorial(HistorialOcupacion historial)
        {
            _context.HistorialesOcupacion.Add(historial);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHistorial), new { id = historial.Id }, historial);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorial(int id)
        {
            var registro = await _context.HistorialesOcupacion.FindAsync(id);
            if (registro == null) return NotFound();

            _context.HistorialesOcupacion.Remove(registro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
