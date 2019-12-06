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
        /// Metodo para conectar a la base de datos
        /// </summary>
        /// <returns>Retorna la conexion</returns>
        public static MySqlConnection Conectar()
        {
            conn = new MySqlConnection("Database = ProyectoDB; Data Source = localhost; User Id = root; Password =");

            conn.Open();

            return conn;
        }


        /// <summary>
        /// Desconectar de la base de datos
        /// </summary>
        /// <returns>Retorna el resultado de la desconexion</returns>
        public static MySqlConnection Desconectar()
        {
            conn.Close();

            return conn;
        }
    }
}
