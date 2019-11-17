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
using AplicacionPrincipal.Vistas.VistasEmpleado;
using AplicacionPrincipal.Vistas.VistasBeneficiario;
using AplicacionPrincipal.Vistas.VistasCurso;

namespace AplicacionPrincipal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEmpleado_Click(object sender, RoutedEventArgs e)
        {
            MenuEmpleado frmMenuEmpleado = new MenuEmpleado();

            frmMenuEmpleado.ShowDialog();
        }

        private void btnBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            MenuBeneficiario frmMenuBeneficiario = new MenuBeneficiario();

            frmMenuBeneficiario.ShowDialog();
        }

        private void btnCurso_Click(object sender, RoutedEventArgs e)
        {
            MenuCurso frmMenuCurso = new MenuCurso();

            frmMenuCurso.ShowDialog();
        }

        private void btnEmpresa_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
