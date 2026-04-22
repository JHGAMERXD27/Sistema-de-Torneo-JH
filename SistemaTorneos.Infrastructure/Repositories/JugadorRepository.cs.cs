using Microsoft.EntityFrameworkCore;
using SistemaTorneos.Core.Entities;
using SistemaTorneos.Core.Interfaces; 
using SistemaTorneos.Infrastructure.Data;

namespace SistemaTorneos.Infrastructure.Repositories
{

    public class JugadorRepository : IJugadorRepository
    {
        private readonly TorneoDbContext _context;


        public JugadorRepository(TorneoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Jugador>> GetAllAsync()
        {
            return await _context.Jugadores.ToListAsync();
        }


        public async Task AddAsync(Jugador jugador)
        {
            await _context.Jugadores.AddAsync(jugador);
            await _context.SaveChangesAsync();
        }
    }
}