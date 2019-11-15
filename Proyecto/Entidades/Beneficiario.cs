using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Beneficiario : Persona
    {
        private string cuil;
        private string email;
        private string nivelDeEscolaridad;
        private bool candidato;

        public string Cuil { get => cuil; set => cuil = value; }
        public string Email { get => email; set => email = value; }
        public string NivelDeEscolaridad { get => nivelDeEscolaridad; set => nivelDeEscolaridad = value; }
        public bool Candidato { get => candidato; set => candidato = value; }

        /// <summary>
        /// Constructor de Beneficiario
        /// </summary>
        public Beneficiario()
        {

        }

        public override string ToString()
        {
            string estadoCandidato;

            if (Candidato)
            {
                estadoCandidato = "Si";
            }
            else
            {
                estadoCandidato = "No";
            }

            return Apellido + ",  " + Nombre + " - DNI: " + DNI + " - Cuil: " + Cuil + " - Email: " + Email + " - Nivel de Escolaridad: " + NivelDeEscolaridad + " - Candidato: " + estadoCandidato;
        }
    }
}
