using AccesoADatos;
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

namespace AplicacionPrincipal.Vistas.VistasEmpresa.VistaContratacion
{
    /// <summary>
    /// Lógica de interacción para ABMAltaContratacion.xaml
    /// </summary>
    public partial class ABMAltaContratacion : Window
    {
        public List<int> idesBeneficiarios;

        public bool aceptar;

        public ABMAltaContratacion()
        {
            InitializeComponent();

            CargarListaCandidatos();

            btnAceptar.IsEnabled = false;
            
            aceptar = false;
        }

        public void CargarListaCandidatos()
        {
            var beneficiarios = new List<Beneficiario>();

            idesBeneficiarios = new List<int>();

            ConexionBeneficiario.GetBeneficiariosCandidatos(beneficiarios, idesBeneficiarios);

            foreach (var benef in beneficiarios)
            {
                lbxCandidatos.Items.Add(benef);
                //if (!ConexionContratacion.RevisarSiYaEstaContratado(idesBeneficiarios[i]))
                //{
                //    lbxCandidatos.Items.Add(benef);

                //    i++;
                //}
                //else
                //{
                //    i++;
                //}
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            aceptar = true;

            this.Close();
        }

        public void HabilitarBtnContratar()
        {
            var habilitar = !string.IsNullOrEmpty(txtCargo.Text) && lbxCandidatos.SelectedIndex != -1;

            btnAceptar.IsEnabled = habilitar;
        }

        public Contratacion GetContratacion()
        {
            var contratacion = new Contratacion();

            contratacion.Cargo = txtCargo.Text;

            contratacion.Sueldo = Convert.ToDecimal(txbSueldo.Text);

            return contratacion;
        }

        private void LbxCandidatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HabilitarBtnContratar();
        }

        private void txtCargo_TextChanged(object sender, TextChangedEventArgs e)
        {
            HabilitarBtnContratar();
        }

        private void txbSueldo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
