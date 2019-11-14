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
        private DateTime fechaInicio;
        private DateTime fechaFinal;
        private string cargo;
        private decimal sueldo;

        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFinal { get => fechaFinal; set => fechaFinal = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public decimal Sueldo { get => sueldo; set => sueldo = value; }

        
        /// <summary>
        /// Contructor de Contratacion
        /// </summary>
        public Contratacion()
        {

        }


        /// <summary>
        /// Método abstracto GetSueldo sin funcionalidad definida en la clase abstracta requiere definición en las clases que hereden de Contratacion
        /// </summary>
        /// <returns>Devuelve un valor de tipo decimal</returns>
        public abstract decimal GetSueldo();
    }
}
