using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empresa
    {
        private string nombre;

        public string Nombre { get => nombre; set => nombre = value; }


        /// <summary>
        /// Constructor vacio de empresa
        /// </summary>
        public Empresa()
        {

        }


        public override string ToString()
        {
            return "Empresa: " + Nombre;
        }
    }
}
