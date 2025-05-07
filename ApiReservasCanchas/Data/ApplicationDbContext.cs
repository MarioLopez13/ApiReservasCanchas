using Microsoft.EntityFrameworkCore;
using ApiReservasCanchas.Models;

namespace ApiReservasCanchas.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cancha> Canchas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<HistorialOcupacion> HistorialesOcupacion { get; set; }
    }
}
