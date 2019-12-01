using AccesoADatos;
using Entidades;
using MySql.Data.MySqlClient;
using Reportes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplicacionPrincipal.Vistas.VistasBeneficiario
{
    /// <summary>
    /// Lógica de interacción para ABMBeneficiarioControl.xaml
    /// </summary>
    public partial class ABMBeneficiarioControl : UserControl
    {
        List<Beneficiario> beneficiarios;
        MySqlConnection conn;
        string mensaje;
        public List<int> ides;
        public int id;

        public ABMBeneficiarioControl()
        {
            InitializeComponent();

            ConexionBeneficiario.ActualizarCandidatos();

            beneficiarios = new List<Beneficiario>();

            ides = new List<int>();

            btnEliminarBeneficiario.IsEnabled = false;
            btnModificarBeneficiario.IsEnabled = false;

            ActualizarListBox();
        }


        /// <summary>
        /// Metodo para cargar la listbox con la informacion de la base de datos
        /// </summary>
        public void ActualizarListBox()
        {
            lbxBeneficiarios.Items.Clear();

            beneficiarios = new List<Beneficiario>();

            ides = new List<int>();

            ConexionBeneficiario.GetBeneficiario(beneficiarios, ides);

            foreach (var beneficiario in beneficiarios)
            {
                lbxBeneficiarios.Items.Add(beneficiario);
            }

            lbxBeneficiarios.Items.Refresh();
        }

        private void btnModificarBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            // variable que funciona de indice para los arreglos
            id = lbxBeneficiarios.SelectedIndex;

            ABMModificarBeneficiario frmModificarBeneficiario = new ABMModificarBeneficiario(id, ides);

            frmModificarBeneficiario.ShowDialog();

            if (frmModificarBeneficiario.resultado)
            {
                try
                {
                    conn = Conexion.Conectar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                mensaje = ConexionBeneficiario.ModificarBeneficiario(conn, frmModificarBeneficiario.GetBeneficiario(), ides[id]);

                ActualizarListBox();

                MessageBox.Show(mensaje);

                conn = Conexion.Desconectar();
            }
        }

        private void btnEliminarBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            id = lbxBeneficiarios.SelectedIndex;

            string mensaje;

            try
            {
                conn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            mensaje = ConexionBeneficiario.EliminarBeneficiario(conn, ides[id]);

            MessageBox.Show(mensaje);

            conn = Conexion.Desconectar();

            ActualizarListBox();
        }

        private void btnGenerarReporte_Click(object sender, RoutedEventArgs e)
        {
            mensaje = Generar.Beneficiarios(beneficiarios, ides);

            MessageBox.Show(mensaje);
        }


        /// <summary>
        /// Metodo para habilitar el boton de Eliminar y Modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxBeneficiarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxBeneficiarios.SelectedIndex != -1)
            {
                btnModificarBeneficiario.IsEnabled = true;

                btnEliminarBeneficiario.IsEnabled = true;
            }
        }

        private void btnAltaBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            ABMAltaBeneficiario frmAltaBeneficiario = new ABMAltaBeneficiario();

            frmAltaBeneficiario.ShowDialog();

            try
            {
                conn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            if (frmAltaBeneficiario.aceptar)
            {
                mensaje = ConexionBeneficiario.AgregarBeneficiario(conn, frmAltaBeneficiario.GetBeneficiario());

                ActualizarListBox();

                MessageBox.Show(mensaje);
            }

            conn = Conexion.Desconectar();
        }
    }
}
