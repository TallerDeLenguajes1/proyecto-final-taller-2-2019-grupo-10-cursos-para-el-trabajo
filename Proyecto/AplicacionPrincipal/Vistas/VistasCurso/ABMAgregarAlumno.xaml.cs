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

namespace AplicacionPrincipal.Vistas.VistasCurso
{
    /// <summary>
    /// Lógica de interacción para ABMAgregarAlumno.xaml
    /// </summary>
    public partial class ABMAgregarAlumno : Window
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        List<Beneficiario> beneficiarios;
        MySqlConnection conn;
        string mensaje;
        public List<int> idesBeneficiarios;
        public List<int> idesCss;
        public int id;

        public ABMAgregarAlumno(int idSeleccionado, List<int> idesCursos)
        {
            InitializeComponent();

            id = idSeleccionado;

            idesCss = idesCursos;

            btnAceptar.IsEnabled = false;

            CargarListBox();
        }


        /// <summary>
        /// Metodo para cargar la listbox con la informacion de la base de datos
        /// </summary>
        public void CargarListBox()
        {

            beneficiarios = new List<Beneficiario>();

            idesBeneficiarios = new List<int>();

            ConexionBeneficiario.GetBeneficiario(beneficiarios, idesBeneficiarios);
            
            foreach (var beneficiario in beneficiarios)
            {
                lbxBeneficiarios.Items.Add(beneficiario);
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Agregar alumno conexion");

                MessageBox.Show("Error: " + ex.Message);
            }

            mensaje = ConexionCurso.AgregarAlumno(conn, idesBeneficiarios[lbxBeneficiarios.SelectedIndex], idesCss[id]);

            MessageBox.Show(mensaje);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lbxBeneficiarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnAceptar.IsEnabled = true;
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
