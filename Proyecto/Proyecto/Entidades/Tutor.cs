using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tutor : Empleado
    {
        /// <summary>
        /// Constructor de Tutor
        /// </summary>
        public Tutor()
        {

        }

        public override string ToString()
        {
            return Apellido + ",  " + Nombre + " - DNI: " + DNI + " - Reparticion: " + Reparticion + " - Funcion: Tutor";
        }
    }
}
