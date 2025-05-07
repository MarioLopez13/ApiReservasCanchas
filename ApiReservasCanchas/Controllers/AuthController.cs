using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiReservasCanchas.Data;
using ApiReservasCanchas.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ApiReservasCanchas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (usuario == null)
                return Unauthorized("Usuario no encontrado.");

            // Recalcular el hash
            var hasher = new PasswordHasher<Usuario>();
            var result = hasher.VerifyHashedPassword(usuario, usuario.Contrasena, request.Contrasena);

            if (result != PasswordVerificationResult.Success)
                return Unauthorized("Contraseña incorrecta.");



            // Login válido
            return Ok(new
            {
                id = usuario.Id,
                nombre = usuario.Nombre,
                email = usuario.Email,
                rol = usuario.Rol
            });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Contrasena { get; set; }
    }
}
