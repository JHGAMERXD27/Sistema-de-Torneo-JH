using Microsoft.AspNetCore.Mvc;
using SistemaTorneos.Application.Services;
using SistemaTorneos.Core.Entities;
using SistemaTorneos.Core.Interfaces;
using SistemaTorneos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SistemaTorneos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TorneosController : ControllerBase
    {
        private readonly IJugadorRepository _jugadorRepository;
        private readonly TorneoService _torneoService;
        private readonly TorneoDbContext _context;

        public TorneosController(IJugadorRepository jugadorRepository, TorneoService torneoService, TorneoDbContext context)
        {
            _jugadorRepository = jugadorRepository;
            _torneoService = torneoService;
            _context = context;
        }

        [HttpPost("crear-ronda-inicial")]
        public async Task<ActionResult<List<Encuentro>>> GenerarBrackets()
        {
            var jugadores = await _jugadorRepository.GetAllAsync();
            var listaJugadores = jugadores.ToList();

            // Generamos los encuentros con ID de torneo ficticio 1 por ahora
            var encuentros = _torneoService.GenerarEnfrentamientos(listaJugadores, 1);

            // GUARDAR EN BASE DE DATOS
            _context.Encuentros.AddRange(encuentros);
            await _context.SaveChangesAsync();

            return Ok(encuentros);
        }

        [HttpGet("ver-encuentros")]
        public async Task<ActionResult<List<Encuentro>>> GetEncuentros()
        {
            return await _context.Encuentros.ToListAsync();
        }
        [HttpPost("registrar-ganador")]
        public async Task<ActionResult> RegistrarGanador(int encuentroId, string nombreGanador)
        {
            var encuentro = await _context.Encuentros.FindAsync(encuentroId);

            if (encuentro == null) return NotFound("Encuentro no encontrado");

            encuentro.Ganador = nombreGanador;
            await _context.SaveChangesAsync();

            return Ok($"Se registró a {nombreGanador} como ganador del encuentro {encuentroId}");
        }
    }
}