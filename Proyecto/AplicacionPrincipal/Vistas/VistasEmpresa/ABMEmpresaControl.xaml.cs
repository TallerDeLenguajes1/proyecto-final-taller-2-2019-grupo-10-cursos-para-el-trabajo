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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AplicacionPrincipal.Vistas.VistasEmpresa.VistaContratacion;

namespace AplicacionPrincipal.Vistas.VistasEmpresa
{
    /// <summary>
    /// Lógica de interacción para ABMEmpresaControl.xaml
    /// </summary>
    public partial class ABMEmpresaControl : UserControl
    {
        List<Empresa> empresas;
        MySqlConnection conn;
        string mensaje;
        public List<int> ides;
        public int id;

        public ABMEmpresaControl()
        {
            InitializeComponent();

            btnEliminarEmpresa.IsEnabled = false;
            btnModificarEmpresa.IsEnabled = false;
            btnContrataciones.IsEnabled = false;

            ActualizarListbox();
        }


        /// <summary>
        /// Cargar la listbox de la empresas almacenadas en la BD
        /// </summary>
        public void ActualizarListbox()
        {
            lbxEmpresas.Items.Clear();

            empresas = new List<Empresa>();

            ides = new List<int>();

            ConexionEmpresa.GetEmpresa(empresas, ides);

            foreach (var empresa in empresas)
            {
                lbxEmpresas.Items.Add(empresa);
            }
        }

        private void lbxEmpresas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxEmpresas.SelectedIndex != -1)
            {
                btnModificarEmpresa.IsEnabled = true;

                btnEliminarEmpresa.IsEnabled = true;

                btnContrataciones.IsEnabled = true;
            }
        }

        private void btnAltaEmpresa_Click(object sender, RoutedEventArgs e)
        {
            ABMAltaEmpresa frmAltaEmpresa = new ABMAltaEmpresa();

            frmAltaEmpresa.ShowDialog();

            if (frmAltaEmpresa.aceptar)
            {
                try
                {
                    conn = Conexion.Conectar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                mensaje = ConexionEmpresa.AgregarEmpresa(conn, frmAltaEmpresa.GetEmpresa());

                ActualizarListbox();

                MessageBox.Show(mensaje);

                conn = Conexion.Desconectar();
            }

            lbxEmpresas.SelectedIndex = -1;
            btnEliminarEmpresa.IsEnabled = false;
            btnModificarEmpresa.IsEnabled = false;
            btnContrataciones.IsEnabled = false;
        }

        private void btnModificarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            // variable que funciona de indice para los arreglos
            id = lbxEmpresas.SelectedIndex;

            ABMModificarEmpresa frmModificarEmpresa = new ABMModificarEmpresa(id, ides);

            frmModificarEmpresa.ShowDialog();

            if (frmModificarEmpresa.resultado)
            {
                try
                {
                    conn = Conexion.Conectar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                mensaje = ConexionEmpresa.ModificarEmpresa(conn, frmModificarEmpresa.GetEmpresa(), ides[id]);

                ActualizarListbox();

                MessageBox.Show(mensaje);

                conn = Conexion.Desconectar();
            }

            lbxEmpresas.SelectedIndex = -1;
            btnEliminarEmpresa.IsEnabled = false;
            btnModificarEmpresa.IsEnabled = false;
            btnContrataciones.IsEnabled = false;
        }

        private void btnEliminarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            id = lbxEmpresas.SelectedIndex;

            string mensaje;

            try
            {
                conn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            mensaje = ConexionEmpresa.EliminarEmpresa(conn, ides[id]);

            MessageBox.Show(mensaje);

            conn = Conexion.Desconectar();

            ActualizarListbox();

            lbxEmpresas.SelectedIndex = -1;
            btnEliminarEmpresa.IsEnabled = false;
            btnModificarEmpresa.IsEnabled = false;
            btnContrataciones.IsEnabled = false;
        }

        private void btnContrataciones_Click(object sender, RoutedEventArgs e)
        {
            MenuContratacion frmMenuContratacion = new MenuContratacion(empresas[lbxEmpresas.SelectedIndex], ides[lbxEmpresas.SelectedIndex]);

            frmMenuContratacion.ShowDialog();
        }
    }
}
