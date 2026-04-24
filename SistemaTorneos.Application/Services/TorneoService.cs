using Microsoft.EntityFrameworkCore;
using SistemaTorneos.Core.Entities;
using SistemaTorneos.Infrastructure.Data;

namespace SistemaTorneos.Application.Services
{
    public class TorneoService
    {
        private readonly TorneoDbContext _context;

        public TorneoService(TorneoDbContext context)
        {
            _context = context;
        }

        // Generar Ronda 1 (Aleatoria)
        public async Task<List<Encuentro>> GenerarRondaInicial()
        {
            var jugadores = await _context.Jugadores.ToListAsync();
            if (jugadores.Count < 2) return new List<Encuentro>();

            var mezclados = jugadores.OrderBy(x => Guid.NewGuid()).ToList();
            var encuentros = CrearBrackets(mezclados, 1);

            await _context.Encuentros.AddRangeAsync(encuentros);
            await _context.SaveChangesAsync();
            return encuentros;
        }

        // NUEVO: Generar Siguiente Ronda basada en los ganadores
        public async Task<List<Encuentro>> GenerarSiguienteRonda()
        {
            // 1. Buscamos la última ronda jugada
            int ultimaRonda = await _context.Encuentros.MaxAsync(e => (int?)e.Ronda) ?? 0;

            // 2. Obtenemos los ganadores de esa última ronda
            var ganadores = await _context.Encuentros
                .Where(e => e.Ronda == ultimaRonda && e.Ganador != null)
                .Select(e => e.Ganador)
                .ToListAsync();

            if (ganadores.Count < 2) return new List<Encuentro>();

            // 3. Emparejamos a los ganadores para la nueva ronda
            var nuevosBrackets = new List<Encuentro>();
            for (int i = 0; i < ganadores.Count; i += 2)
            {
                if (i + 1 < ganadores.Count)
                {
                    nuevosBrackets.Add(new Encuentro
                    {
                        TorneoId = 1,
                        JugadorA = ganadores[i],
                        JugadorB = ganadores[i + 1],
                        Ronda = ultimaRonda + 1
                    });
                }
                else
                {
                    nuevosBrackets.Add(new Encuentro
                    {
                        TorneoId = 1,
                        JugadorA = ganadores[i],
                        JugadorB = "BYE",
                        Ganador = ganadores[i],
                        Ronda = ultimaRonda + 1
                    });
                }
            }

            await _context.Encuentros.AddRangeAsync(nuevosBrackets);
            await _context.SaveChangesAsync();
            return nuevosBrackets;
        }

        private List<Encuentro> CrearBrackets(List<Jugador> jugadores, int ronda)
        {
            var lista = new List<Encuentro>();
            for (int i = 0; i < jugadores.Count; i += 2)
            {
                if (i + 1 < jugadores.Count)
                    lista.Add(new Encuentro { TorneoId = 1, JugadorA = jugadores[i].Alias, JugadorB = jugadores[i + 1].Alias, Ronda = ronda });
                else
                    lista.Add(new Encuentro { TorneoId = 1, JugadorA = jugadores[i].Alias, JugadorB = "BYE", Ganador = jugadores[i].Alias, Ronda = ronda });
            }
            return lista;
        }
    }
}