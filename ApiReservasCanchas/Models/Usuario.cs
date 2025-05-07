namespace ApiReservasCanchas.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; } // "admin" o "cliente"

        public ICollection<Reserva>? Reservas { get; set; }

    }
}
