using AccesoADatos;
using Entidades;
using MySql.Data.MySqlClient;
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
    /// Lógica de interacción para ABMModificarEmpresa.xaml
    /// </summary>
    public partial class ABMModificarEmpresa : Window
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        int seleccion;
        List<int> idesEmpresas;
        Empresa empresa;
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader dtr;
        // Variable para conocer si el usiario hizo click en el boton aceptar
        public bool resultado;

        public ABMModificarEmpresa(int idSeleccionado, List<int> ides)
        {
            InitializeComponent(); 

            seleccion = idSeleccionado;

            idesEmpresas = ides;

            MostrarDatosActuales();

            btnAceptar.IsEnabled = false;

            resultado = false;
        }


        public Empresa GetEmpresa()
        {
            empresa = new Empresa();

            empresa.Nombre = txtNombre.Text;

            return empresa;
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
                Logger.Error(ex, "Mostar datos de empresa conexion");

                MessageBox.Show("Error: " + ex.Message);
            }

            selectQuery = "SELECT * FROM Empresa WHERE idEmpresa = @idEmpresa";

            id = idesEmpresas[seleccion];

            cmd = new MySqlCommand(selectQuery, conn);

            cmd.Parameters.AddWithValue("@idEmpresa", id);

            dtr = cmd.ExecuteReader();

            while (dtr.Read())
            {
                txtNombre.Text = dtr.GetString(1);
            }

            conn = Conexion.Desconectar();
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

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            HabilitarBtnAceptar();
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
