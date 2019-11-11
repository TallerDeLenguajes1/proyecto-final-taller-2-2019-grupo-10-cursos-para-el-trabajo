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
using AccesoADatos;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using Entidades;

namespace PruebaDeConexiones
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection cnn;
        List<Instructor> instructores;
        List<int> ides;

        public MainWindow()
        {
            InitializeComponent();

            //string mensaje;

            //try
            //{
            //    cnn = Conexion.Conectar();

            //    MessageBox.Show("Conectado");

            //    var instructor = new Instructor();

            //    instructor.Nombre = "Raul";
            //    instructor.Apellido = "Armando";
            //    instructor.DNI = "19686987";
            //    instructor.Reparticion = "Gabinete";

            //    mensaje = ConexionEmpleado.AgregarInstructor(cnn, instructor);

            //    MessageBox.Show(mensaje);

            //    try
            //    {
            //        cnn = Conexion.Desconectar();

            //        MessageBox.Show("Desconectado");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("error al desconectar: " + ex.Message);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al conectar la base de datos: " + ex.Message);
            //}


            instructores = new List<Instructor>();
            ides = new List<int>();
            string mensaje;
            mensaje = ConexionEmpleado.GetInstructores(instructores, ides);
            MessageBox.Show(mensaje);
            int i = 0;
            while (ides.Count > i)
            {
                MessageBox.Show(ides[i].ToString() + ", " + instructores[i].Nombre + ", " + instructores[i].Apellido + ", " + instructores[i].DNI + ", " + instructores[i].Reparticion);
                i++;
            }


            //MySqlConnection conn = Conexion.Conectar();
            ////var query = "SELECT * FROM Instructor";
            ////MySqlCommand cmd = new MySqlCommand(query, conn);
            ////MySqlDataReader dtr = cmd.ExecuteReader();
            ////while (dtr.Read())
            ////{
            ////    MessageBox.Show(dtr.GetString(2));
            ////}


            //mensaje = ConexionEmpleado.EliminarInstructor(conn, 3);

            //MessageBox.Show(mensaje);

            //conn = Conexion.Desconectar();
        }
    }
}
