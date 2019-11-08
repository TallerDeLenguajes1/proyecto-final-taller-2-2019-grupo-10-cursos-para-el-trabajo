using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace AccesoADatos
{
    public class ConexionBeneficiario
    {
        private static MySqlConnection cnn;
        private static MySqlCommand cmd;
        private static MySqlDataReader dtr;


        /// <summary>
        /// Recibe un beneficiario y una base datos para agregarlo a la misma
        /// </summary>
        /// <param name="conexionDB">Conexion para comunicarse con la base de datos</param>
        /// <param name="beneficiario">Recibe los instructores generados</param>
        /// <returns>Devuelve un string con un mensaje dependiendo del resultado de la accion</returns>
        public static string AgregarBeneficiario(MySqlConnection conexionDB, Beneficiario beneficiario)
        {
            string mensaje;

            if (conexionDB.State == ConnectionState.Open)
            {
                var InsertQuery = "INSERT INTO Beneficiario(Nombre, Apellido, DNI, Cuil, Email, NivelDeEscolaridad, Candidato) VALUES('" + beneficiario.Nombre + "', '" + beneficiario.Apellido + "', '" + beneficiario.DNI + "', '" + beneficiario.Cuil + "', '" + beneficiario.Email + "', '" + beneficiario.NivelDeEscolaridad + "', '" + beneficiario.Candidato + "' );";

                try
                {
                    cmd = new MySqlCommand(InsertQuery, conexionDB);

                    cmd.ExecuteNonQuery();

                    mensaje = "Agregado a la base de datos";

                    return mensaje;
                }
                catch (Exception ex)
                {
                    mensaje = "Error: " + ex.Message;

                    return mensaje;
                }
            }
            else
            {
                mensaje = "No se conecto a la base de datos";

                return mensaje;
            }
        }


        /// <summary>
        /// Recibe un beneficiario y una base datos para eliminarlo de la misma
        /// </summary>
        /// <param name="conexionDB">Conexion para comunicarse con la base de datos</param>
        /// <param name="id">id en la base de datos del beneficiario a eliminar</param>
        /// <returns>Devuelve un string con un mensaje dependiendo del resultado de la accion</returns>
        public static string EliminarBeneficiario(MySqlConnection conexionDB, int id)
        {
            string mensaje;

            if (conexionDB.State == ConnectionState.Open)
            {
                var deleteQuery = "DELETE FROM Beneficiario WHERE idBeneficiario = " + id;

                try
                {
                    cmd = new MySqlCommand(deleteQuery, conexionDB);

                    cmd.ExecuteNonQuery();

                    mensaje = "Eliminado de la BD";

                    return mensaje;
                }
                catch (Exception ex)
                {
                    mensaje = "Error: " + ex.Message;

                    return mensaje;
                }
            }
            else
            {
                mensaje = "No se conecto a la base de datos";

                return mensaje;
            }
        }


        /// <summary>
        /// Recibe un beneficiario y una base datos para modificarlo en la misma
        /// </summary>
        /// <param name="conexionDB">Conexion para comunicarse con la base de datos</param>
        /// <param name="beneficiario">Recibe el beneficiario generado</param>
        /// <param name="id">id en la base de datos del beneficiario recibido</param>
        /// <returns>Devuelve un string con un mensaje dependiendo del resultado de la accion</returns>
        public static string ModificarBeneficiario(MySqlConnection conexionDB, Beneficiario beneficiario, int id)
        {
            string mensaje;

            if (conexionDB.State == ConnectionState.Open)
            {
                var updateQuery = "UPDATE Beneficiario SET Nombre = '" + beneficiario.Nombre + "', Apellido = '" + beneficiario.Apellido + "', DNI = '" + beneficiario.DNI + "', Cuil = '" + beneficiario.Cuil + "', Email = '" + beneficiario.Email + "', NivelDeEscolaridad = '" + beneficiario.NivelDeEscolaridad + "', Candidato = '" + beneficiario.Candidato + "' WHERE idInstructor = " + id;

                try
                {
                    cmd = new MySqlCommand(updateQuery, conexionDB);

                    cmd.ExecuteNonQuery();

                    mensaje = "Modificado correctamente";

                    return mensaje;
                }
                catch (Exception ex)
                {
                    mensaje = "Error: " + ex.Message;

                    return mensaje;
                }
            }
            else
            {
                mensaje = "No se conecto a la base de datos";

                return mensaje;
            }
        }


        /// <summary>
        /// Metodo para obtener los beneficiarios de la base de dato
        /// </summary>
        /// <param name="beneficiarios">Lista de beneficiarios</param>
        /// <param name="ides">Lista en donde se cargaran los id en orden de los beneficiarios</param>
        /// <returns>Devuelve un string con un mensaje dependiendo del resultado de la accion</returns>
        public static string GetBeneficiario(List<Beneficiario> beneficiarios, List<int> ides)
        {
            beneficiarios = new List<Beneficiario>();

            ides = new List<int>();

            int i = 0;

            string mensaje;

            try
            {
                cnn = new MySqlConnection();

                cnn = Conexion.Conectar();

                string selectQuery;

                selectQuery = "SELECT idBeneficiario FROM Beneficiario";

                cmd = new MySqlCommand(selectQuery, cnn);

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    ides[i] = Convert.ToInt32(dtr);

                    i++;
                }

                i = 0;

                selectQuery = "SELECT Nombre FROM Beneficiario";

                cmd = new MySqlCommand(selectQuery, cnn);

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    beneficiarios[i].Nombre = dtr.ToString();

                    i++;
                }

                i = 0;

                selectQuery = "SELECT Apellido FROM Beneficiario";

                cmd = new MySqlCommand(selectQuery, cnn);

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    beneficiarios[i].Apellido = dtr.ToString();

                    i++;
                }

                i = 0;

                selectQuery = "SELECT DNI FROM Beneficiario";

                cmd = new MySqlCommand(selectQuery, cnn);

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    beneficiarios[i].DNI = dtr.ToString();

                    i++;
                }

                i = 0;

                selectQuery = "SELECT Cuil FROM Beneficiario";

                cmd = new MySqlCommand(selectQuery, cnn);

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    beneficiarios[i].Cuil = dtr.ToString();

                    i++;
                }

                i = 0;

                selectQuery = "SELECT Email FROM Beneficiario";

                cmd = new MySqlCommand(selectQuery, cnn);

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    beneficiarios[i].Email = dtr.ToString();

                    i++;
                }

                i = 0;

                selectQuery = "SELECT NivelDeEscolaridad FROM Beneficiario";

                cmd = new MySqlCommand(selectQuery, cnn);

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    beneficiarios[i].NivelDeEscolaridad = dtr.ToString();

                    i++;
                }

                i = 0;

                selectQuery = "SELECT Candidato FROM Beneficiario";

                cmd = new MySqlCommand(selectQuery, cnn);

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    beneficiarios[i].Candidato = Convert.ToBoolean(dtr.ToString());

                    i++;
                }

                cnn = Conexion.Desconectar();

                mensaje = "Beneficiarios cargados";

                return mensaje;
            }
            catch (Exception ex)
            {
                mensaje = "Error " + ex.Message;

                return mensaje;
            }
        }
    }
}
