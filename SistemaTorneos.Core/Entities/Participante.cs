using System;

namespace SistemaTorneos.Core.Entities
{
    public abstract class Participante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaRegistro { get; set; }

        protected Participante(string nombre)
        {
            Nombre = nombre;
            FechaRegistro = DateTime.Now;
        }

        public abstract string ObtenerResumenNivel();
    }
}