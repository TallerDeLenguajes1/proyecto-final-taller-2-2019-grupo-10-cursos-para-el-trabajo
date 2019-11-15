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

namespace AplicacionPrincipal.Vistas.VistasBeneficiario
{
    /// <summary>
    /// Lógica de interacción para ABMAltaBeneficiario.xaml
    /// </summary>
    public partial class ABMAltaBeneficiario : Window
    {
         public Beneficiario beneficiario;
        bool aceptar;

        public ABMAltaBeneficiario()
        {
            InitializeComponent();

            btnAceptar.IsEnabled = false;

            aceptar = false;
        }

        /// <summary>
        /// Metodo para controlar cuando debe activarse el boton de aceptar
        /// </summary>
        private void HabilatarBtnAceptar()
        {
            // Controla si los campos estan vacios y devuelve verdadero si son distintos de vacio
            var habilitar = !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtDNI.Text) && ValidarEmail(txtMail.Text) && cbxNvlEscolar.SelectedIndex != -1;

            // Se habilita o no el boton segun el valor que devuelva la variable habilitar
            btnAceptar.IsEnabled = habilitar;
        }

        public Beneficiario GetBeneficiario()
        {
            beneficiario = new Beneficiario();

            beneficiario.Nombre = txtNombre.Text;

            beneficiario.Apellido = txtApellido.Text;

            beneficiario.DNI = txtDNI.Text;

            beneficiario.Cuil = txtCuil.Text;

            beneficiario.Email = txtMail.Text;

            beneficiario.NivelDeEscolaridad = cbxNvlEscolar.Text;

            beneficiario.Candidato = false;

            return beneficiario;
        }

        /// <summary>
        /// Metodo para comprobar si el texto ingresado es un email valido
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public bool ValidarEmail(string mail)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(mail);
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            HabilatarBtnAceptar();
        }

        private void txtDNI_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void cbxFuncion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        private void txtMail_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool validacion;

            validacion = ValidarEmail(txtMail.Text);

            if (validacion)
            {
                iconCheck.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                iconCheck.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
