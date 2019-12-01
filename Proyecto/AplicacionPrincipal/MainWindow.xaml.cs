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
using AplicacionPrincipal.Vistas.VistasBeneficiario;
using AplicacionPrincipal.Vistas.VistasEmpleado;
using AplicacionPrincipal.Vistas.VistasCurso;
using AplicacionPrincipal.Vistas.VistasEmpresa;

namespace PopUpMenu
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

        private void btnCerrarMenu_Click(object sender, RoutedEventArgs e)
        {
            btnAbrirMenu.Visibility = Visibility.Visible;

            btnCerrarMenu.Visibility = Visibility.Collapsed;
        }

        private void btnAbrirMenu_Click(object sender, RoutedEventArgs e)
        {
            btnAbrirMenu.Visibility = Visibility.Collapsed;

            btnCerrarMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ABMEmpleadoControl());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ABMBeneficiarioControl());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ABMCursoControl());
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ABMEmpresaControl());
                    break;
                default:
                    break;
            }
        }

        private void btnPower_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnPower_MouseEnter(object sender, MouseEventArgs e)
        {
            btnPower.Foreground = new SolidColorBrush(Color.FromRgb(255, 100, 100));
        }

        private void btnPower_MouseLeave(object sender, MouseEventArgs e)
        {
            btnPower.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }
    }
}
