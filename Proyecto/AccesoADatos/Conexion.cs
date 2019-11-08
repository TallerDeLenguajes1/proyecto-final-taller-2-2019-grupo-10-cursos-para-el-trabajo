using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace AccesoADatos
{
    public class Conexion
    {
        private static MySqlConnection conn;

        /// <summary>
        /// Conectar a la base de datos utilizando el metodo open para abrir la conexion
        /// </summary>
        /// <param name="ConexionDB">Conexion para comunicarse con la base de datos</param>
        /// <returns>Devuelve un string con el resultado de la conexion</returns>
        //public static string Conectar(MySqlConnection ConexionDB)
        //{
        //    string mensaje;

        //    try
        //    {
        //        ConexionDB = new MySqlConnection("Database = ProyectoDB; Data Source = localhost; User Id = root; Password = 493-admin");

        //        ConexionDB.Open();

        //        mensaje = "Conectado a la base de Datos";

        //        return mensaje;
        //    }
        //    catch (Exception ex)
        //    {
        //        mensaje = "No se pudo conectar a la base de Datos: " + ex.Message;

        //        return mensaje;
        //    }
        //}


        public static MySqlConnection Conectar()
        {
            conn = new MySqlConnection("Database = ProyectoDB; Data Source = localhost; User Id = root; Password = 493-admin");

            conn.Open();

            return conn;
        }


        /// <summary>
        /// Desconectar de la base de datos utilizando el metodo close para cerrar la conexion
        /// </summary>
        /// <param name="ConexionDB">Conexion para comunicarse con la base de datos</param>
        /// <returns>Devuelve un string con el resultado de la desconexion</returns>
        //public static string Desconectar(MySqlConnection ConexionDB)
        //{
        //    string mensaje;

        //    try
        //    {
        //        // Revisa si la base de datos esta conectada
        //        if (ConexionDB.State == ConnectionState.Open)
        //        {
        //            ConexionDB.Close();

        //            mensaje = "Base de datos Desconectada";
        //        }
        //        else
        //        {
        //            mensaje = "La base de datos no estaba Conectada";
        //        }

        //        return mensaje;
        //    }
        //    catch (Exception ex)
        //    {
        //        mensaje = "Ocurrio un error: " + ex.Message;

        //        return mensaje;
        //    }
        //}
        public static MySqlConnection Desconectar()
        {
            conn.Close();

            return conn;
        }
    }
}
