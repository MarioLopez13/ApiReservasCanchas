namespace ApiReservasCanchas.Models
{
    public class HistorialOcupacion
    {
        public int Id { get; set; }
        public int CanchaId { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public DateTime Fecha { get; set; }
        public string EstadoOcupacion { get; set; } = string.Empty;

        public Cancha? Cancha { get; set; }
    }
}
