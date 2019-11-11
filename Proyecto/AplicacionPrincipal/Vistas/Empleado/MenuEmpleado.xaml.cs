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

namespace AplicacionPrincipal.Vistas.Empleado
{
    /// <summary>
    /// Lógica de interacción para MenuEmpleado.xaml
    /// </summary>
    public partial class MenuEmpleado : Window
    {
        List<Instructor> instructores;
        List<Tutor> tutores;
        MySqlConnection conn;
        string mensaje;
        public MenuEmpleado()
        {
            InitializeComponent();

            instructores = new List<Instructor>();
            tutores = new List<Tutor>();
        }

        private void btnAltaEmpleado_Click(object sender, RoutedEventArgs e)
        {
            ABMAltaEmpleado frmAltaEmpleado = new ABMAltaEmpleado();

            frmAltaEmpleado.ShowDialog();

            if (frmAltaEmpleado.resultado)
            {
                try
                {
                    conn = Conexion.Conectar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                if (frmAltaEmpleado.cboFuncion.SelectedIndex == 0)
                {
                    instructores.Add(frmAltaEmpleado.GetInstructor());

                    mensaje = ConexionEmpleado.AgregarInstructor(conn, frmAltaEmpleado.GetInstructor());
                }
                else
                {
                    tutores.Add(frmAltaEmpleado.GetTutor());

                    mensaje = ConexionEmpleado.AgregarTutor(conn, frmAltaEmpleado.GetTutor());
                }

                MessageBox.Show(mensaje);

                conn = Conexion.Desconectar();
            }
        }
    }
}
