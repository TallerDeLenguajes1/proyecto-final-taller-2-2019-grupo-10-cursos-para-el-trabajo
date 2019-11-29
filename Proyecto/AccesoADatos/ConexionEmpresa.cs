using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class ConexionEmpresa
    {
        static MySqlCommand cmd;
        static MySqlDataReader dtr;
        static MySqlConnection cnn;


        /// <summary>
        /// Agrega la empresa a la BD
        /// </summary>
        /// <param name="conexionDB"></param>
        /// <param name="empresa"></param>
        /// <returns></returns>
        public static string AgregarEmpresa(MySqlConnection conexionDB, Empresa empresa)
        {
            string mensaje = "Agregado a la BD";
            string insertQuery;

            if (conexionDB.State == ConnectionState.Open)
            {
                insertQuery = "INSERT INTO Empresa (Nombre) VALUE (@Nombre);";

                cmd = new MySqlCommand(insertQuery, conexionDB);

                cmd.Parameters.AddWithValue("@Nombre", empresa.Nombre);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;

                    return mensaje;
                }

                return mensaje;
            }
            else
            {
                mensaje = "No se conecto a la BD";

                return mensaje;
            }
        }



        /// <summary>
        /// Elima la empresa de la BD
        /// </summary>
        /// <param name="conexioDB"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string EliminarEmpresa(MySqlConnection conexioDB, int id)
        {
            string mensaje = "Eliminado de la BD";

            if (conexioDB.State == ConnectionState.Open)
            {
                var deleteQuery = "DELETE FROM Empresa WHERE idEmpresa = @idEmpresa";

                cmd = new MySqlCommand(deleteQuery, conexioDB);

                cmd.Parameters.AddWithValue("@idEmpresa", id);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;

                    return mensaje;
                }

                return mensaje;
            }
            else
            {
                mensaje = "No se conecto a la BD";

                return mensaje;
            }
        }


        
        /// <summary>
        /// Modifica la empresa de la BD
        /// </summary>
        /// <param name="conexionDB"></param>
        /// <param name="empresa"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string ModificarEmpresa(MySqlConnection conexionDB, Empresa empresa, int id)
        {
            string mensaje = "Modificado de la BD correctamente";

            if (conexionDB.State == ConnectionState.Open)
            {
                var updateQuery = "UPDATE Empresa SET Nombre = @Nombre WHERE idEmpresa = @idEmpresa;";

                cmd = new MySqlCommand(updateQuery, conexionDB);

                cmd.Parameters.AddWithValue("@Nombre", empresa.Nombre);

                cmd.Parameters.AddWithValue("@idEmpresa", id);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;

                    return mensaje;
                }

                return mensaje;
            }
            else
            {
                mensaje = "No se conecto a la BD";

                return mensaje;
            }
        }


        /// <summary>
        /// Obtiene las empresas de la BD
        /// </summary>
        /// <param name="empresas"></param>
        /// <param name="ides"></param>
        /// <returns></returns>
        public static string GetEmpresa(List<Empresa> empresas, List<int> ides)
        {
            string mensaje = "Empresas cargadas de la BD";

            Empresa empresa;

            try
            {
                cnn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;

                return mensaje;
            }

            var selectQuery = "SELECT * FROM Empresa;";

            cmd = new MySqlCommand(selectQuery, cnn);

            try
            {
                dtr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;

                return mensaje;
            }

            while (dtr.Read())
            {
                empresa = new Empresa();

                ides.Add(dtr.GetInt32(0));

                empresa.Nombre = dtr.GetString(1);

                empresas.Add(empresa);
            }

            cnn = Conexion.Desconectar();

            return mensaje;
        }


    }
}
