using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Curso
    {
        private string tema;
        private Instructor instructor;
        private Tutor tutor;
        private List<Beneficiario> alumnos;

        public string Tema { get => tema; set => tema = value; }
        public Instructor Instructor { get => instructor; set => instructor = value; }
        public Tutor Tutor { get => tutor; set => tutor = value; }
        public List<Beneficiario> Alumnos { get => alumnos; set => alumnos = value; }

        public Curso()
        {

        }

        public int CantidadDeAlumnos()
        {
            return alumnos.Count();
        }

        public override string ToString()
        {
            return Tema + " - Instructor: " + Instructor.Apellido + ", " + Instructor.Nombre + " - Tutor: " + Tutor.Apellido + ", " + Tutor.Nombre + " - Cantidad de Alumnos: " + CantidadDeAlumnos();
        }
    }
}
