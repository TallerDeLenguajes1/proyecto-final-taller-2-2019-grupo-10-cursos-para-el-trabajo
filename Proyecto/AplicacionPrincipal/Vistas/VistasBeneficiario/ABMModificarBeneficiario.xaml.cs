using AccesoADatos;
using Entidades;
using MySql.Data.MySqlClient;
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
using AplicacionPrincipal;

namespace AplicacionPrincipal.Vistas.VistasBeneficiario
{
    /// <summary>
    /// Lógica de interacción para ABMModificarBeneficiario.xaml
    /// </summary>
    public partial class ABMModificarBeneficiario : Window
    {
        int seleccion;
        List<int> ides;
        Beneficiario beneficiario;
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader dtr;
        // Variable para conocer si el usiario hizo click en el boton aceptar
        public bool resultado;
        public bool candidato;

        public ABMModificarBeneficiario(int idSeleccionado, List<int> idesBeneficiarios)
        {
            InitializeComponent();

            seleccion = idSeleccionado;

            ides = idesBeneficiarios;

            MostrarDatosActuales();

            btnAceptar.IsEnabled = false;

            resultado = false;
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

            beneficiario.Candidato = candidato;

            return beneficiario;
        }

        public void MostrarDatosActuales()
        {
            string selectQuery;

            int id;

            try
            {
                conn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            selectQuery = "SELECT * FROM Beneficiario WHERE idBeneficiario = @id";

            id = ides[seleccion];

            cmd = new MySqlCommand(selectQuery, conn);

            cmd.Parameters.AddWithValue("@id", id);

            dtr = cmd.ExecuteReader();

            while (dtr.Read())
            {
                txtNombre.Text = dtr.GetString(1);

                txtApellido.Text = dtr.GetString(2);

                txtDNI.Text = dtr.GetString(3);

                txtCuil.Text = dtr.GetString(4);

                txtMail.Text = dtr.GetString(5);

                if (dtr.GetInt16(7) == 1)
                {
                    candidato = true;
                }
                else
                {
                    candidato = false;
                }
            }

            conn = Conexion.Desconectar();
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

        private void cbxNvlEscolar_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
