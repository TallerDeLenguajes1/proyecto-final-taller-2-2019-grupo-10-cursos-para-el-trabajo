using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase abastracta Contratacion de la cual heredan los distintos componentes
    /// </summary>
    public abstract class Contratacion
    {
        private string cargo;
        private decimal sueldo;


        public string Cargo { get => cargo; set => cargo = value; }
        public decimal Sueldo { get => sueldo; set => sueldo = value; }

        
        /// <summary>
        /// Contructor de Contratacion
        /// </summary>
        public Contratacion()
        {

        }
    }
}
