using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado : Persona
    {
        private string reparticion;

        public string Reparticion { get => reparticion; set => reparticion = value; }

        /// <summary>
        /// Constructor de Empleado
        /// </summary>
        public Empleado()
        {

        }
    }
}
