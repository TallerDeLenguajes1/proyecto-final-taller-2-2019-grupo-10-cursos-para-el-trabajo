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
        List<Beneficiario> beneficiarios;
        MySqlConnection conn;
        MenuCurso abmMenuCurso;
        string mensaje;
        public List<int> ides;
        public int id;

        public ABMAgregarAlumno()
        {
            InitializeComponent();

            // Guardo el valor de la seleccion de la listbox accediendo a la ventana MenuEmpleado
            abmMenuCurso = Application.Current.Windows.OfType<MenuCurso>().FirstOrDefault();

            id = abmMenuCurso.lbxCursos.SelectedIndex;

            btnAceptar.IsEnabled = false;

            CargarListBox();
        }


        /// <summary>
        /// Metodo para cargar la listbox con la informacion de la base de datos
        /// </summary>
        public void CargarListBox()
        {

            beneficiarios = new List<Beneficiario>();

            ides = new List<int>();

            ConexionBeneficiario.GetBeneficiario(beneficiarios, ides);
            
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
                MessageBox.Show("Error: " + ex.Message);
            }

            mensaje = ConexionCurso.AgregarAlumno(conn, ides[lbxBeneficiarios.SelectedIndex], abmMenuCurso.ides[id]);

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
