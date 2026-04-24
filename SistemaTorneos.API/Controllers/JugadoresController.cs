using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaTorneos.Core.Entities;
using SistemaTorneos.Core.Interfaces;
using SistemaTorneos.Infrastructure.Data;

namespace SistemaTorneos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JugadoresController : ControllerBase
    {
        private readonly IJugadorRepository _repository;
        private readonly TorneoDbContext _context;

        // Inyectamos el contexto de la BD directo para hacer el borrado más rápido
        public JugadoresController(IJugadorRepository repository, TorneoDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Jugador>> PostJugador(Jugador jugador)
        {
            await _repository.AddAsync(jugador);
            return Ok(jugador);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jugador>>> GetJugadores()
        {
            var jugadores = await _repository.GetAllAsync();
            return Ok(jugadores);
        }

        // NUEVO: Eliminar un jugador específico por su ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarJugador(int id)
        {
            var jugador = await _context.Jugadores.FindAsync(id);
            if (jugador == null) return NotFound("Jugador no encontrado");

            _context.Jugadores.Remove(jugador);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // NUEVO: Limpiar toda la tabla de jugadores de un golpe
        [HttpDelete("limpiar")]
        public async Task<IActionResult> LimpiarTodosLosJugadores()
        {
            _context.Jugadores.RemoveRange(_context.Jugadores);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}