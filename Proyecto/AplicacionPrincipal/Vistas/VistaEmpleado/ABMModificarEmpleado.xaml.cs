﻿using AccesoADatos;
using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AplicacionPrincipal.Vistas.VistaEmpleado
{
    /// <summary>
    /// Lógica de interacción para ABMModificarEmpleado.xaml
    /// </summary>
    public partial class ABMModificarEmpleado : Window
    {
        MenuEmpleado abmMenuEmpleado;
        int seleccion;
        Instructor instructor;
        Tutor tutor;
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader dtr;
        // Variable para conocer si el usiario hizo click en el boton aceptar
        public bool resultado;

        public ABMModificarEmpleado()
        {
            InitializeComponent();

            //Guardo el valor de la seleccion de la listbox accediendo a la ventana MenuEmpleado
            abmMenuEmpleado = Application.Current.Windows.OfType<MenuEmpleado>().FirstOrDefault();

            seleccion = abmMenuEmpleado.id;

            MostrarDatosActuales();

            btnAceptar.IsEnabled = false;

            resultado = false;
        }

        public Tutor GetTutor()
        {
            tutor = new Tutor();

            tutor.Nombre = txtNombre.Text;

            tutor.Apellido = txtApellido.Text;

            tutor.DNI = txtDNI.Text;

            tutor.Reparticion = txtReparticion.Text;

            return tutor;
        }

        public Instructor GetInstructor()
        {
            instructor = new Instructor();

            instructor.Nombre = txtNombre.Text;

            instructor.Apellido = txtApellido.Text;

            instructor.DNI = txtDNI.Text;

            instructor.Reparticion = txtReparticion.Text;

            return instructor;
        }

        public void MostrarDatosActuales()
        {
            string selectQuery;

            int id;

            try
            {
                conn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            if (abmMenuEmpleado.tipoDeEmpleado)
            {
                selectQuery = "SELECT * FROM Instructor WHERE idInstructor = @id";

                id = abmMenuEmpleado.idesInstructores[seleccion];
            }
            else
            {
                selectQuery = "SELECT * FROM Tutor WHERE idTutor = @id";

                id = abmMenuEmpleado.idesTutores[seleccion];
            }

            cmd = new MySqlCommand(selectQuery, conn);

            cmd.Parameters.AddWithValue("@id", id);

            dtr = cmd.ExecuteReader();

            while (dtr.Read())
            {
                txtNombre.Text = dtr.GetString(1);

                txtApellido.Text = dtr.GetString(2);

                txtDNI.Text = dtr.GetString(3);

                txtReparticion.Text = dtr.GetString(4);
            }

            conn = Conexion.Desconectar();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            resultado = true;

            this.Close();
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            HabilatarBtnAceptar();
        }

        /// <summary>
        /// Metodo para controlar cuando debe activarse el boton de aceptar
        /// </summary>
        private void HabilatarBtnAceptar()
        {
            // Controla si los campos estan vacios y devuelve verdadero si son distintos de vacio
            var habilitar = !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtApellido.Text) && !string.IsNullOrEmpty(txtDNI.Text) && !string.IsNullOrEmpty(txtReparticion.Text) && cboFuncion.SelectedIndex != -1;

            // Se habilita o no el boton segun el valor que devuelva la variable habilitar
            btnAceptar.IsEnabled = habilitar;
        }

        /// <summary>
        /// Metodo para que en el textbox solo se pueda ingresar numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDNI_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void cboFuncion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HabilatarBtnAceptar();
        }
    }
}
