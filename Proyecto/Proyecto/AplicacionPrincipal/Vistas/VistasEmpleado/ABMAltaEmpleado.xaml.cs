using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AplicacionPrincipal.Vistas.VistasEmpleado
{
    /// <summary>
    /// Lógica de interacción para ABMAltaEmpleado.xaml
    /// </summary>
    public partial class ABMAltaEmpleado : Window
    {
        Instructor instructor;
        Tutor tutor;
        // Variable para conocer si el usiario hizo click en el boton aceptar
        public bool resultado;

        public ABMAltaEmpleado()
        {
            InitializeComponent();

            btnAceptar.IsEnabled = false;

            resultado = false;
        }

        public Tutor GetTutor()
        {
            tutor = new Tutor();

            tutor.Nombre = txtNombre.Text;

            tutor.Apellido = txtApellido.Text;

            tutor.DNI = txtDNI.Text;

            tutor.Reparticion = txtReparticion.Text;

            return tutor;
        }

        public Instructor GetInstructor()
        {
            instructor = new Instructor();

            instructor.Nombre = txtNombre.Text;

            instructor.Apellido = txtApellido.Text;

            instructor.DNI = txtDNI.Text;

            instructor.Reparticion = txtReparticion.Text;

            return instructor;
        }

        /// <summary>
        /// Metodo para controlar cuando debe activarse el boton de aceptar
        /// </summary>
        private void HabilatarBtnAceptar()
        {
            // Controla si los campos estan vacios y devuelve verdadero si son distintos de vacio
            var habilitar = !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtDNI.Text) && !string.IsNullOrEmpty(txtReparticion.Text) && cbxFuncion.SelectedIndex != -1;

            // Se habilita o no el boton segun el valor que devuelva la variable habilitar
            btnAceptar.IsEnabled = habilitar;
        }

        /// <summary>
        /// Cada vez que el textbox cambia llama el metodo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            HabilatarBtnAceptar();
        }

        /// <summary>
        /// Metodo para que en el textbox solo se pueda ingresar numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDNI_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        /// <summary>
        /// Cada vez que el combobox cambia llama el metodo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxFuncion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HabilatarBtnAceptar();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            resultado = true;

            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
