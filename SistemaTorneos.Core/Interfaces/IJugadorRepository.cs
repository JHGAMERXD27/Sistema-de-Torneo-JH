using SistemaTorneos.Core.Entities;

namespace SistemaTorneos.Core.Interfaces
{
    public interface IJugadorRepository
    {
        Task<IEnumerable<Jugador>> GetAllAsync();

        Task AddAsync(Jugador jugador);
    }
}