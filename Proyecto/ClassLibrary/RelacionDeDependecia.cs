using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RelacionDeDependecia : Contratacion
    {
        /// <summary>
        /// Constructor de RelacionDeDependencia
        /// </summary>
        public RelacionDeDependecia()
        {

        }


        /// <summary>
        /// Sobrecarga del metodo abstracto GetSueldo
        /// </summary>
        /// <returns>Devuelve un valor de tipo decimal</returns>
        public override decimal GetSueldo()
        {
            decimal sueldoFinal;

            decimal obraSocial = (decimal)0.3 * Sueldo;

            sueldoFinal = Sueldo + obraSocial;

            return sueldoFinal;
        }
    }
}
