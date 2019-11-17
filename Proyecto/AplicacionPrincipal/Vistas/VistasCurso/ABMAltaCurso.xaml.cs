using AccesoADatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AplicacionPrincipal.Vistas.VistasCurso
{
    /// <summary>
    /// Lógica de interacción para ABMAltaCurso.xaml
    /// </summary>
    public partial class ABMAltaCurso : Window
    {
        List<Instructor> instructores;
        List<Tutor> tutores;
        public int tutorSeleccionado;
        public int InstructorSeleccionado;
        List<int> idesInstructores;
        List<int> idesTutores;
        bool agregadoInstructor;
        bool agregadoTutor;
        public bool aceptar;

        public ABMAltaCurso()
        {
            InitializeComponent();

            btnAceptar.IsEnabled = false;
            btnAgregarInstructor.IsEnabled = false;
            btnAgregarTutor.IsEnabled = false;
            agregadoInstructor = false;
            agregadoTutor = false;
            aceptar = false;

            MostrarEmpleados();
        }


        /// <summary>
        /// Metodo para controlar cuando debe activarse el boton de aceptar
        /// </summary>
        private void HabilatarBtnAceptar()
        {
            // Controla si los campos estan vacios y devuelve verdadero si son distintos de vacio
            var habilitar = !string.IsNullOrEmpty(txtTemaCurso.Text) && agregadoInstructor && agregadoTutor;

            // Se habilita o no el boton segun el valor que devuelva la variable habilitar
            btnAceptar.IsEnabled = habilitar;
        }


        /// <summary>
        /// Metodo para cargar la listbox con la informacion de la base de datos
        /// </summary>
        public void MostrarEmpleados()
        {
            instructores = new List<Instructor>();

            tutores = new List<Tutor>();

            idesInstructores = new List<int>();

            idesTutores = new List<int>();

            ConexionEmpleado.GetInstructores(instructores, idesInstructores);

            ConexionEmpleado.GetTutores(tutores, idesTutores);

            foreach (var instructor in instructores)
            {
                lbxInstructores.Items.Add(instructor);
            }

            foreach (var tutor in tutores)
            {
                lbxTutor.Items.Add(tutor);
            }

            lbxInstructores.Items.Refresh();
        }


        private void lbxInstructores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxInstructores.SelectedIndex != -1)
            {
                btnAgregarInstructor.IsEnabled = true;
            }          
        }

        private void lbxTutor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxTutor.SelectedIndex != -1)
            {
                btnAgregarTutor.IsEnabled = true;
            }
        }

        private void txtTemaCurso_TextChanged(object sender, TextChangedEventArgs e)
        {
            HabilatarBtnAceptar();
        }

        private void btnAgregarInstructor_Click(object sender, RoutedEventArgs e)
        {
            agregadoInstructor = true;

            InstructorSeleccionado = idesInstructores[lbxInstructores.SelectedIndex];

            HabilatarBtnAceptar();
        }

        private void btnAgregarTutor_Click(object sender, RoutedEventArgs e)
        {
            agregadoTutor = true;

            tutorSeleccionado = idesTutores[lbxTutor.SelectedIndex];

            HabilatarBtnAceptar();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            aceptar = true;

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
