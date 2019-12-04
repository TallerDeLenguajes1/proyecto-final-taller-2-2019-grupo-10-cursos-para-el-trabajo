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
using AplicacionPrincipal.Vistas;

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

            GridPrincipal.Children.Add(new ABMHomeControl());
        }


        /// <summary>
        /// Activa la animacion cerrar gridmenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrarMenu_Click(object sender, RoutedEventArgs e)
        {
            btnAbrirMenu.Visibility = Visibility.Visible;

            btnCerrarMenu.Visibility = Visibility.Collapsed;
        }


        /// <summary>
        /// Activa la animacion abrir gridmenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbrirMenu_Click(object sender, RoutedEventArgs e)
        {
            btnAbrirMenu.Visibility = Visibility.Collapsed;

            btnCerrarMenu.Visibility = Visibility.Visible;
        }


        /// <summary>
        /// Cambia el gridprincipal a la seleccionada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;

            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ABMHomeControl());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ABMEmpleadoControl());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ABMBeneficiarioControl());
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ABMCursoControl());
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ABMEmpresaControl());
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Mueve el grid de seleccion al indice seleccionado
        /// </summary>
        /// <param name="index"></param>
        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (150 + (60 * index)), 0, 0);
        }

        private void btnPower_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


        /// <summary>
        /// Cambia el color del contenido del boton cuando esta encima
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPower_MouseEnter(object sender, MouseEventArgs e)
        {
            btnPower.Foreground = new SolidColorBrush(Color.FromRgb(255, 100, 100));
        }


        /// <summary>
        /// Cambia el color del contenido del boton cuando sale de encima
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPower_MouseLeave(object sender, MouseEventArgs e)
        {
            btnPower.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        /// <summary>
        /// Cambia el color del contenido del boton cuando sale de encima
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimizar_MouseLeave(object sender, MouseEventArgs e)
        {
            btnMinimizar.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }


        /// <summary>
        /// Cambia el color del contenido del boton cuando esta encima
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimizar_MouseEnter(object sender, MouseEventArgs e)
        {
            btnMinimizar.Foreground = new SolidColorBrush(Color.FromRgb(255, 100, 100));
        }
    }
}
