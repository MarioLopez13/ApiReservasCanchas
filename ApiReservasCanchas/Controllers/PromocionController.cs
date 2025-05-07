using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiReservasCanchas.Data;
using ApiReservasCanchas.Models;

namespace ApiReservasCanchas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PromocionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Promocion/generar
        [HttpPost("generar")]
        public async Task<IActionResult> GenerarPromociones()
        {
            var historial = await _context.HistorialesOcupacion
                .GroupBy(h => new { h.CanchaId, h.HoraInicio, h.HoraFin })
                .Select(g => new
                {
                    g.Key.CanchaId,
                    g.Key.HoraInicio,
                    g.Key.HoraFin,
                    Ocupadas = g.Count(h => h.EstadoOcupacion == "ocupado"),
                    Total = g.Count()
                }).ToListAsync();

            foreach (var h in historial)
            {
                var porcentaje = (double)h.Ocupadas / h.Total;

                if (porcentaje < 0.5)
                {
                    var existe = await _context.Promociones.AnyAsync(p =>
                        p.CanchaId == h.CanchaId &&
                        p.HoraInicio == h.HoraInicio &&
                        p.HoraFin == h.HoraFin);

                    if (!existe)
                    {
                        _context.Promociones.Add(new Promocion
                        {
                            CanchaId = h.CanchaId,
                            HoraInicio = h.HoraInicio,
                            HoraFin = h.HoraFin,
                            Descuento = 20,
                            Motivo = "Baja ocupación",
                            Activa = true
                        });
                    }
                }
            }

            await _context.SaveChangesAsync();
            return Ok("Promociones generadas.");
        }

        [HttpGet("activas/{canchaId}")]
        public async Task<ActionResult<IEnumerable<Promocion>>> GetPromocionesActivas(int canchaId)
        {
            return await _context.Promociones
                .Where(p => p.CanchaId == canchaId && p.Activa)
                .ToListAsync();
        }
    }
}
