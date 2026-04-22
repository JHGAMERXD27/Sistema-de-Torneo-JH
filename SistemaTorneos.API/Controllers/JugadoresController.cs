using Microsoft.AspNetCore.Mvc;
using SistemaTorneos.Core.Entities;
using SistemaTorneos.Core.Interfaces;

namespace SistemaTorneos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JugadoresController : ControllerBase
    {
        private readonly IJugadorRepository _repository;

        public JugadoresController(IJugadorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jugador>>> Get()
        {
            var jugadores = await _repository.GetAllAsync();
            return Ok(jugadores);
        }

        [HttpPost]
        public async Task<ActionResult> Post(string nombre, string alias)
        {
            var nuevoJugador = new Jugador(nombre, alias);
            await _repository.AddAsync(nuevoJugador);
            return Ok(nuevoJugador);
        }
    }
}