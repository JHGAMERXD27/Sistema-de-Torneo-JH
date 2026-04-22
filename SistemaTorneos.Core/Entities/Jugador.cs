namespace SistemaTorneos.Core.Entities
{
    public abstract class Persona // CLASE ABSTRACTA
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public Persona(string nombre) // CONSTRUCTOR BASE
        {
            Nombre = nombre;
        }
    }

    public class Jugador : Persona
    {
        public string Alias { get; set; } = string.Empty;

        // SOBRECARGA DE CONSTRUCTOR
        public Jugador(string nombre, string alias) : base(nombre)
        {
            Alias = alias;
        }

        public Jugador() : base(string.Empty) { }

        // Restaurado para resolver ENC0033: evitar que la eliminación del método en caliente cause errores
        public string ObtenerResumenNivel()
        {
            return $"{Nombre} ({Alias})";
        }
    }
}