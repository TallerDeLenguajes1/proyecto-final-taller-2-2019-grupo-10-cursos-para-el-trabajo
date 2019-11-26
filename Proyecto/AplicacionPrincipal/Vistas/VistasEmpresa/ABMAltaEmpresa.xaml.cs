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

namespace AplicacionPrincipal.Vistas.VistasEmpresa
{
    /// <summary>
    /// Lógica de interacción para ABMAltaEmpresa.xaml
    /// </summary>
    public partial class ABMAltaEmpresa : Window
    {
        Empresa empresa;
        public bool aceptar;

        public ABMAltaEmpresa()
        {
            InitializeComponent();

            btnAceptar.IsEnabled = false;

            aceptar = false;
        }


        /// <summary>
        /// Metodo para controlar cuando debe activarse el boton de aceptar
        /// </summary>
        public void HabilitarBtnAceptar()
        {
            // Controla si los campos estan vacios y devuelve verdadero si son distintos de vacio
            var habilitar = !string.IsNullOrEmpty(txtNombre.Text);

            // Se habilita o no el boton segun el valor que devuelva la variable habilitar
            btnAceptar.IsEnabled = habilitar;
        }



        public Empresa GetEmpresa()
        {
            empresa = new Empresa();

            empresa.Nombre = txtNombre.Text;

            return empresa;
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

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            HabilitarBtnAceptar();
        }
    }
}
