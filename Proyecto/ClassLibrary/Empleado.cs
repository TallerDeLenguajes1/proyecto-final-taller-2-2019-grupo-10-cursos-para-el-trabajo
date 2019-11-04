using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Empleado : Persona
    {
        private string reparticion;

        public string Reparticion1 { get => reparticion; set => reparticion = value; }

        /// <summary>
        /// Constructor de Empleado
        /// </summary>
        public Empleado()
        {

        }
    }
}
