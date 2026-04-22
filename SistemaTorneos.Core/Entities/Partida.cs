using System;

namespace SistemaTorneos.Core.Entities
{
    public class Partida
    {
        public int Id { get; set; }
        public int Ronda { get; set; } 
        public DateTime FechaHora { get; set; }

        public int TorneoId { get; set; }
        public Torneo Torneo { get; set; } = null!;

        public int Jugador1Id { get; set; }
        public Jugador Jugador1 { get; set; } = null!;

        public int? Jugador2Id { get; set; } 
        public Jugador? Jugador2 { get; set; }

        public int? GanadorId { get; set; }
        public Jugador? Ganador { get; set; }
    }
}