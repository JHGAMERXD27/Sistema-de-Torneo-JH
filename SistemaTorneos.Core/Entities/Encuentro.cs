namespace SistemaTorneos.Core.Entities
{
    public class Encuentro
    {
        public int Id { get; set; }
        public int TorneoId { get; set; }
        public string JugadorA { get; set; } = string.Empty; // Cambiado de JugadorUno
        public string JugadorB { get; set; } = string.Empty; // Cambiado de JugadorDos
        public string? Ganador { get; set; }
        public int Ronda { get; set; }
    }
}