namespace SistemaTorneos.Core.Entities
{
    public class Torneo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Now;
        public bool EstaFinalizado { get; set; } = false;

        // Relación: Un torneo tiene muchos jugadores
        public List<Jugador> Participantes { get; set; } = new List<Jugador>();
    }
}