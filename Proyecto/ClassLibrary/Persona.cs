using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        private string nombre;
        private string apellido;
        private string dNI;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string DNI { get => dNI; set => dNI = value; }

        /// <summary>
        /// Constructor de Persona
        /// </summary>
        public Persona()
        {

        }
    }
}
