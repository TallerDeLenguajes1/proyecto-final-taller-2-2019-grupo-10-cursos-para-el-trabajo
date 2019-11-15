using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Instructor : Empleado
    {
        /// <summary>
        /// Constructor de Instructor
        /// </summary>
        public Instructor()
        {

        }

        public override string ToString()
        {
            return Apellido + ",  " + Nombre + " - DNI: " + DNI + " - Reparticion: " + Reparticion + " - Funcion: Instructor";
        }
    }
}
