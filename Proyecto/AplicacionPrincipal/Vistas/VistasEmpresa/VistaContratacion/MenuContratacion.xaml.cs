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
        List<int> idesEmpresas;
        List<int> idesBeneficiariosContrataciones;
        List<int> idesBeneficiarios;
        List<Beneficiario> beneficiarios;
        MySqlConnection conn;

        public MenuContratacion(Empresa empresaSeleccionada, int idEmpresaSeleccionada)
        {
            InitializeComponent();

            empresa = empresaSeleccionada;

            idEmpresa = idEmpresaSeleccionada;

            lblTitulo.Content = empresa.Nombre;

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
        }

        /// <summary>
        /// Cargar la listbox de la empresas almacenadas en la BD
        /// </summary>
        public void ActualizarListbox()
        {
            lbxContratados.Items.Clear();

            contrataciones = new List<Contratacion>();

            idesEmpresas = new List<int>();

            idesBeneficiariosContrataciones = new List<int>();

            ConexionContratacion.GetContrataciones(contrataciones, idesBeneficiariosContrataciones, idesEmpresas);

            var i = 0;
            var j = 0;

            foreach (var id in idesEmpresas)
            {
                if (id == idEmpresa)
                {
                    foreach (var idBeneficiario in idesBeneficiarios)
                    {
                        if (idBeneficiario == idesBeneficiariosContrataciones[i])
                        {
                            lbxContratados.Items.Add(beneficiarios[j].Apellido + ", " + beneficiarios[j].Nombre + " - " + contrataciones[i]);
                        }

                        j++;
                    }
                }
                i++;
            }
        }

        private void LbxContratados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxContratados.SelectedIndex != -1)
            {
                btnAltaContratacion.IsEnabled = true;

                btnModificarContrato.IsEnabled = true;
            }
        }

        private void BtnAltaContratacion_Click(object sender, RoutedEventArgs e)
        {
            ABMAltaContratacion frmABMAltaContratacion = new ABMAltaContratacion();

            frmABMAltaContratacion.ShowDialog();
        }

        private void BtnModificarContrato_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnTerminarContrato_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
