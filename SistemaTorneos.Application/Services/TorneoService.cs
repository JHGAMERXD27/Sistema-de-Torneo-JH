using SistemaTorneos.Core.Entities;

namespace SistemaTorneos.Application.Services
{
    public class TorneoService
    {
        private List<Jugador> MezclarJugadores(List<Jugador> jugadores)
        {
            var random = new Random();
            return jugadores.OrderBy(j => random.Next()).ToList();
        }

        // MÉTODO ORIGINAL
        public List<Encuentro> GenerarEnfrentamientos(List<Jugador> participantes, int torneoId)
        {
            var encuentros = new List<Encuentro>();

            if (participantes.Count < 2)
            {
                return encuentros; // Devuelve lista vacía si no hay suficientes
            }

            var listaMezclada = MezclarJugadores(participantes);

            for (int i = 0; i < listaMezclada.Count; i += 2)
            {
                var encuentro = new Encuentro
                {
                    TorneoId = torneoId,
                    Ronda = 1,
                    JugadorA = listaMezclada[i].Alias,
                    JugadorB = (i + 1 < listaMezclada.Count) ? listaMezclada[i + 1].Alias : "BYE"
                };
                encuentros.Add(encuentro);
            }

            return encuentros; // AQUÍ SE CORRIGE EL ERROR DE RETORNO
        }

        // SOBRECARGA (Requisito de la rúbrica)
        public List<Encuentro> GenerarEnfrentamientos(int cantidadRandom, int torneoId)
        {
            var listaPrueba = new List<Jugador>();
            for (int i = 0; i < cantidadRandom; i++)
            {
                listaPrueba.Add(new Jugador($"Nombre {i}", $"Alias {i}"));
            }
            return GenerarEnfrentamientos(listaPrueba, torneoId);
        }
    }
}