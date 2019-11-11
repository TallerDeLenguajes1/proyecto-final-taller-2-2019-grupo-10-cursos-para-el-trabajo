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
using AplicacionPrincipal.Vistas;

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

        private void btnAltaTutor_Click(object sender, RoutedEventArgs e)
        {
            ABMAltaTutor frmAltaTutor = new ABMAltaTutor();

            frmAltaTutor.ShowDialog();
        }

        private void btnAltaInstructor_Click(object sender, RoutedEventArgs e)
        {
            ABMAltaInstructor frmAltaInstructor = new ABMAltaInstructor();

            frmAltaInstructor.ShowDialog();
        }

        private void btnAltaBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            ABMAltaBeneficiario frmAltaBeneficiario = new ABMAltaBeneficiario();

            frmAltaBeneficiario.ShowDialog();
        }

        private void btnAltaCurso_Click(object sender, RoutedEventArgs e)
        {
            ABMAltaCurso frmAltaCurso = new ABMAltaCurso();

            frmAltaCurso.ShowDialog();
        }
    }
}
