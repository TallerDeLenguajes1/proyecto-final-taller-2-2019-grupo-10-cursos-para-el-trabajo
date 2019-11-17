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

namespace AplicacionPrincipal.Vistas.VistasCurso
{
    /// <summary>
    /// Lógica de interacción para MenuCurso.xaml
    /// </summary>
    public partial class MenuCurso : Window
    {
        List<Curso> cursos;
        MySqlConnection conn;
        string mensaje;
        public List<int> ides;
        public int id;

        public MenuCurso()
        {
            InitializeComponent();

            cursos = new List<Curso>();
            ides = new List<int>();

            btnAgregarAlumno.IsEnabled = false;

            ActualizarListBox();
        }


        /// <summary>
        /// Metodo para cargar la listbox con la informacion de la base de datos
        /// </summary>
        public void ActualizarListBox()
        {
            lbxCursos.Items.Clear();

            cursos = new List<Curso>();

            ides = new List<int>();

            ConexionCurso.GetCursos(cursos, ides);

            foreach (var curso in cursos)
            {
                lbxCursos.Items.Add(curso);
            }

            lbxCursos.Items.Refresh();
        }


        /// <summary>
        /// Metodo para habilitar el boton de Eliminar y Modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbxCursos.SelectedIndex != -1)
            {
                btnAgregarAlumno.IsEnabled = true;
            }
        }

        private void btnAltaCursos_Click(object sender, RoutedEventArgs e)
        {
            int idCursoAlta;

            ABMAltaCurso frmAltaCurso = new ABMAltaCurso();

            frmAltaCurso.ShowDialog();

            if (frmAltaCurso.aceptar)
            {
                try
                {
                    conn = Conexion.Conectar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                ConexionCurso.AgregarCursoTema(conn, frmAltaCurso.txtTemaCurso.Text);

                idCursoAlta = ConexionCurso.GetidCursoTema();

                mensaje = ConexionCurso.AgregarEmpleadosAlCurso(conn, frmAltaCurso.InstructorSeleccionado, frmAltaCurso.tutorSeleccionado, idCursoAlta);

                MessageBox.Show(mensaje);

                ActualizarListBox();
            }
        }

        private void btnAgregarAlumno_Click(object sender, RoutedEventArgs e)
        {
            ABMAgregarAlumno frmAgregarAlumno = new ABMAgregarAlumno();

            frmAgregarAlumno.ShowDialog();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
