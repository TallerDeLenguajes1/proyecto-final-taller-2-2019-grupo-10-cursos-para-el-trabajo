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
        List<int> idesInstructores;
        List<int> idesTutores;

        public MenuEmpleado()
        {
            InitializeComponent();

            instructores = new List<Instructor>();
            tutores = new List<Tutor>();
            idesInstructores = new List<int>();
            idesTutores = new List<int>();

            btnEliminarEmpleado.IsEnabled = false;
            btnModificarEmpleado.IsEnabled = false;

            ActualizarListBox();
        }

        public void ActualizarListBox()
        {
            lbxEmpleados.Items.Clear();

            ConexionEmpleado.GetInstructores(instructores, idesInstructores);

            ConexionEmpleado.GetTutores(tutores, idesTutores);

            foreach (var instructor in instructores)
            {
                lbxEmpleados.Items.Add(instructor);
            }

            foreach (var tutor in tutores)
            {
                lbxEmpleados.Items.Add(tutor);
            }

            lbxEmpleados.Items.Refresh();
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

                ActualizarListBox();

                MessageBox.Show(mensaje);

                conn = Conexion.Desconectar();
            }
        }

        private void btnModificarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            ABMModificarEmpleado frmModificarEmpleado = new ABMModificarEmpleado();

            frmModificarEmpleado.ShowDialog();
        }

        private void btnEliminarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            int id = lbxEmpleados.SelectedIndex;

            string mensaje;

            try
            {
                conn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            if (instructores.Count > lbxEmpleados.SelectedIndex)
            {
                mensaje = ConexionEmpleado.EliminarInstructor(conn, idesInstructores[id]);

                //MessageBox.Show(instructores[lbxEmpleados.SelectedIndex].Nombre + " - " + idesInstructores[lbxEmpleados.SelectedIndex]);
            }
            else
            {
                id = lbxEmpleados.SelectedIndex - instructores.Count;

                mensaje = ConexionEmpleado.EliminarTutor(conn, idesTutores[id]);
                //MessageBox.Show(tutores[id].Apellido + " - " + idesTutores[id]);
            }

            MessageBox.Show(mensaje);

            conn = Conexion.Desconectar();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Metodo para habilitar el boton de Eliminar y Modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {  
            if (lbxEmpleados.SelectedIndex != -1)
            {
                btnModificarEmpleado.IsEnabled = true;

                btnEliminarEmpleado.IsEnabled = true;
            }
        }
    }
}
