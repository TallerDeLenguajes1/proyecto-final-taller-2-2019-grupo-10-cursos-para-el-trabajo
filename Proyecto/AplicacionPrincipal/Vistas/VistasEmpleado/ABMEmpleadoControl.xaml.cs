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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplicacionPrincipal.Vistas.VistasEmpleado
{
    /// <summary>
    /// Lógica de interacción para ABMEmpleadoControl.xaml
    /// </summary>
    public partial class ABMEmpleadoControl : UserControl
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        List<Instructor> instructores;
        List<Tutor> tutores;
        MySqlConnection conn;
        string mensaje;
        public List<int> idesInstructores;
        public List<int> idesTutores;
        public int id;
        public bool tipoDeEmpleado;

        public ABMEmpleadoControl()
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

        /// <summary>
        /// Metodo para cargar la listbox con la informacion de la base de datos
        /// </summary>
        public void ActualizarListBox()
        {
            lbxEmpleados.Items.Clear();

            instructores = new List<Instructor>();

            tutores = new List<Tutor>();

            idesInstructores = new List<int>();

            idesTutores = new List<int>();

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

        private void lbxEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxEmpleados.SelectedIndex != -1)
            {
                btnModificarEmpleado.IsEnabled = true;

                btnEliminarEmpleado.IsEnabled = true;
            }
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
                    Logger.Error(ex, "Alta empleado conexion");

                    MessageBox.Show("Error: " + ex.Message);
                }

                if (frmAltaEmpleado.cbxFuncion.SelectedIndex == 0)
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
            // variable que funciona de indice para los arreglos
            id = lbxEmpleados.SelectedIndex;

            tipoDeEmpleado = true;

            if (!(instructores.Count > id))
            {
                id = lbxEmpleados.SelectedIndex - instructores.Count;

                tipoDeEmpleado = false;
            }

            ABMModificarEmpleado frmModificiarEmpleado = new ABMModificarEmpleado(id, tipoDeEmpleado, idesInstructores, idesTutores);

            frmModificiarEmpleado.ShowDialog();

            if (frmModificiarEmpleado.resultado)
            {
                try
                {
                    conn = Conexion.Conectar();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Modificar empleado conexion");

                    MessageBox.Show("Error: " + ex.Message);
                }

                if (frmModificiarEmpleado.cbxFuncion.SelectedIndex == 0)
                {
                    mensaje = ConexionEmpleado.ModificarInstructor(conn, frmModificiarEmpleado.GetInstructor(), idesInstructores[id]);
                }
                else
                {
                    mensaje = ConexionEmpleado.ModificarTutor(conn, frmModificiarEmpleado.GetTutor(), idesTutores[id]);
                }

                ActualizarListBox();

                MessageBox.Show(mensaje);

                conn = Conexion.Desconectar();
            }
        }

        private void btnEliminarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            id = lbxEmpleados.SelectedIndex;

            string mensaje;

            try
            {
                conn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Eliminar empleado conexion");

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

            ActualizarListBox();

            conn = Conexion.Desconectar();
        }

        private void btnGenerarReporte_Click(object sender, RoutedEventArgs e)
        {
            mensaje = Generar.Empleados(instructores, idesInstructores, tutores, idesTutores);

            MessageBox.Show(mensaje);
        }
    }
}
