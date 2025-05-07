namespace ApiReservasCanchas.Models
{
    public class Cancha
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; } // futbol, voleibol, etc.
        public string Ubicacion { get; set; }

        public ICollection<Horario>? Horarios { get; set; }
        public ICollection<Reserva>? Reservas { get; set; }
        public ICollection<Promocion>? Promociones { get; set; }
        public ICollection<HistorialOcupacion>? HistorialOcupaciones { get; set; }

    }
}
