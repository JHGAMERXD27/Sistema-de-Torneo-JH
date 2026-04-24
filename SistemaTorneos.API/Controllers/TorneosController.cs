using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaTorneos.Application.Services;
using SistemaTorneos.Core.Entities;
using SistemaTorneos.Infrastructure.Data;

namespace SistemaTorneos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TorneosController : ControllerBase
    {
        private readonly TorneoService _torneoService;
        private readonly TorneoDbContext _context;

        public TorneosController(TorneoService torneoService, TorneoDbContext context)
        {
            _torneoService = torneoService;
            _context = context;
        }

        [HttpPost("crear-ronda-inicial")]
        public async Task<ActionResult> Iniciar() => Ok(await _torneoService.GenerarRondaInicial());

        [HttpPost("avanzar-ronda")]
        public async Task<ActionResult> Avanzar() => Ok(await _torneoService.GenerarSiguienteRonda());

        [HttpGet("encuentros")]
        public async Task<ActionResult> Get() => Ok(await _context.Encuentros.OrderBy(e => e.Ronda).ToListAsync());

        [HttpPut("registrar-ganador/{id}")]
        public async Task<IActionResult> Ganador(int id, [FromBody] string nombre)
        {
            var e = await _context.Encuentros.FindAsync(id);
            if (e == null) return NotFound();
            e.Ganador = nombre;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("limpiar-torneo")]
        public async Task<IActionResult> Limpiar()
        {
            _context.Encuentros.RemoveRange(_context.Encuentros);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}