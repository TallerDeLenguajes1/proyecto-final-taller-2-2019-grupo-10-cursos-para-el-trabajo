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
using System.Windows.Shapes;

namespace AplicacionPrincipal.Vistas.VistasEmpresa.VistaContratacion
{
    /// <summary>
    /// Lógica de interacción para MenuContratacion.xaml
    /// </summary>
    public partial class MenuContratacion : Window
    {
        Empresa empresa;
        int idEmpresa;
        List<Contratacion> contrataciones;
        List<Beneficiario> benefContratados;
        List<int> idesBeneficiarios;
        List<Beneficiario> beneficiarios;
        MySqlConnection conn;
        string mensaje;

        public MenuContratacion(Empresa empresaSeleccionada, int idEmpresaSeleccionada)
        {
            InitializeComponent();

            ConexionBeneficiario.ActualizarCandidatos();

            empresa = empresaSeleccionada;

            idEmpresa = idEmpresaSeleccionada;

            lblListaContratacion.Content = empresa.Nombre;

            try
            {
                conn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            beneficiarios = new List<Beneficiario>();

            idesBeneficiarios = new List<int>();

            ConexionBeneficiario.GetBeneficiario(beneficiarios, idesBeneficiarios);

            conn = Conexion.Desconectar();

            ActualizarListbox();
        }

        /// <summary>
        /// Cargar la listbox de la empresas almacenadas en la BD
        /// </summary>
        public void ActualizarListbox()
        {
            lbxContrataciones.Items.Clear();

            contrataciones = new List<Contratacion>();

            benefContratados = new List<Beneficiario>();

            ConexionContratacion.GetEmpresaSeleccionada(idEmpresa, benefContratados, contrataciones);

            var i = 0;

            foreach (var contrato in benefContratados)
            {
                lbxContrataciones.Items.Add(contrato.Apellido + ", " + contrato.Nombre + " - " + contrataciones[i]);

                i++;
            }
        }

        private void LbxContratados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxContrataciones.SelectedIndex != -1)
            {
                btnAltaContratacion.IsEnabled = true;

                btnModificarContrato.IsEnabled = true;
            }
        }

        private void btnModificarContrato_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminarContrato_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnGenerarReporte_Click(object sender, RoutedEventArgs e)
        {
            mensaje = Generar.Contrataciones(empresa.Nombre, benefContratados, contrataciones);

            MessageBox.Show(mensaje);
        }

        private void btnAltaContratacion_Click(object sender, RoutedEventArgs e)
        {
            ABMAltaContratacion frmABMaltaContratacion = new ABMAltaContratacion();

            frmABMaltaContratacion.ShowDialog();

            if (frmABMaltaContratacion.aceptar)
            {
                try
                {
                    conn = Conexion.Conectar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                var contratacion = frmABMaltaContratacion.GetContratacion();

                var idBenef = frmABMaltaContratacion.idesBeneficiarios[frmABMaltaContratacion.lbxCandidatos.SelectedIndex];

                mensaje = ConexionContratacion.AgregarContratacion(conn, idBenef, idEmpresa, contratacion);

                MessageBox.Show(mensaje);
            }

            ActualizarListbox();
        }
    }
}
