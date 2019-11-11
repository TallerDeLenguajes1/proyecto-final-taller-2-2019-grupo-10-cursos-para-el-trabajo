using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Monotributista : Contratacion
    {
        /// <summary>
        /// Contructor de Monotributista
        /// </summary>
        public Monotributista()
        {

        }


        /// <summary>
        /// Sobrecarga del metodo abstracto GetSueldo
        /// </summary>
        /// <returns>Devuelve un valor de tipo decimal</returns>
        public override decimal GetSueldo()
        {
            decimal sueldoFinal;

            decimal montoFijo = 1;

            sueldoFinal = Sueldo + montoFijo;

            return sueldoFinal;
        }
    }
}
