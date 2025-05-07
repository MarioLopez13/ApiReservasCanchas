namespace ApiReservasCanchas.Models
{
    public class Promocion
    {
        public int Id { get; set; }
        public int CanchaId { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int Descuento { get; set; } // porcentaje
        public string Motivo { get; set; }
        public bool Activa { get; set; }

        public Cancha Cancha { get; set; }
    }
}
