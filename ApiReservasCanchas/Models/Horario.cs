namespace ApiReservasCanchas.Models
{
    public class Horario
    {
        public int Id { get; set; }
        public int CanchaId { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool Disponible { get; set; }

        public Cancha Cancha { get; set; }
    }
}
