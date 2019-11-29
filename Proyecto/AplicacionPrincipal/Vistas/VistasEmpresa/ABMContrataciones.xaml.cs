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
    /// Lógica de interacción para ABMContrataciones.xaml
    /// </summary>
    public partial class ABMContrataciones : Window
    {
        List<Beneficiario> beneficiarios;
        MySqlConnection conn;
        string mensaje;
        public List<int> ides;
        public int id;

        public ABMContrataciones()
        {
            InitializeComponent();

            btnAceptar.IsEnabled = false;
        }

        private void lbxCandidatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
