using ClassLibrary;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AccesoADatos
{
    public class ConexionEmpleado
    {
        private static MySqlCommand cmd;
        private static MySqlConnection cnn;
        private static MySqlDataReader dtr;


        /// <summary>
        /// Recibe un instructor y una base datos para agregarlo a la misma
        /// </summary>
        /// <param name="conexionDB">Conexion para comunicarse con la base de datos</param>
        /// <param name="instructor">Recibe los instructores generados</param>
        /// <returns>Devuelve un string con un mensaje dependiendo del resultado de la accion</returns>
        public static string AgregarInstructor(MySqlConnection conexionDB, Instructor instructor)
        {
            string mensaje;

            if (conexionDB.State == ConnectionState.Open)
            {
                var InsertQuery = "INSERT INTO Instructor(Nombre, Apellido, DNI, Reparticion) VALUES('" + instructor.Nombre + "', '" + instructor.Apellido + "', '" + instructor.DNI + "', '" + instructor.Reparticion + "' );";

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
        /// Recibe un tutor y una base datos para agregarlo a la misma
        /// </summary>
        /// <param name="conexionDB">Conexion para comunicarse con la base de datos</param>
        /// <param name="tutor">Recibe los tutores generados</param>
        /// <returns>Devuelve un string con un mensaje dependiendo del resultado de la accion</returns>
        public static string AgregarTutor(MySqlConnection conexionDB, Tutor tutor)
        {
            string mensaje;

            if (conexionDB.State == ConnectionState.Open)
            {
                var InsertQuery = "INSERT INTO Tutor(Nombre, Apellido, DNI, Reparticion) VALUES('" + tutor.Nombre + "', '" + tutor.Apellido + "', '" + tutor.DNI + "', '" + tutor.Reparticion + "' );";

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
        /// Recibe un instructor y una base datos para eliminarlo de la misma
        /// </summary>
        /// <param name="conexionDB">Conexion para comunicarse con la base de datos</param>
        /// <param name="id">id en la base de datos del instructor a eliminar</param>
        /// <returns>Devuelve un string con un mensaje dependiendo del resultado de la accion</returns>
        public static string EliminarInstructor(MySqlConnection conexionDB, int id)
        {
            string mensaje;

            if (conexionDB.State == ConnectionState.Open)
            {
                var deleteQuery = "DELETE FROM Instructor WHERE idInstructor = " + id;

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
        /// Recibe un tutor y una base datos para eliminarlo de la misma
        /// </summary>
        /// <param name="conexionDB">Conexion para comunicarse con la base de datos</param>
        /// <param name="id">id en la base de datos del tutor a eliminar</param>
        /// <returns>Devuelve un string con un mensaje dependiendo del resultado de la accion</returns>
        public static string EliminarTutor(MySqlConnection conexionDB, int id)
        {
            string mensaje;

            if (conexionDB.State == ConnectionState.Open)
            {
                var deleteQuery = "DELETE FROM Tutor WHERE idTutor = " + id;

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
        /// Recibe un instructor y una base datos para modificarlo en la misma
        /// </summary>
        /// <param name="conexionDB">Conexion para comunicarse con la base de datos</param>
        /// <param name="instructor">Recibe los instructores generados</param>
        /// <param name="id">id en la base de datos del instructor recibido</param>
        /// <returns>Devuelve un string con un mensaje dependiendo del resultado de la accion</returns>
        public static string ModificarInstructor(MySqlConnection conexionDB, Instructor instructor, int id)
        {
            string mensaje;

            if (conexionDB.State == ConnectionState.Open)
            {
                var updateQuery = "UPDATE Instructor SET Nombre = '" + instructor.Nombre + "', Apellido = '" + instructor.Apellido + "', DNI = '" + instructor.DNI + "', Reparticion = '" + instructor.Reparticion + "' WHERE idInstructor = " + id;

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
        /// Recibe un tutor y una base datos para modificarlo en la misma
        /// </summary>
        /// <param name="conexionDB">Conexion para comunicarse con la base de datos</param>
        /// <param name="tutor">Recibe los tutores generados</param>
        /// <param name="id">id en la base de datos del tutor recibido</param>
        /// <returns>Devuelve un string con un mensaje dependiendo del resultado de la accion</returns>
        public static string ModificarTutor(MySqlConnection conexionDB, Tutor tutor, int id)
        {
            string mensaje;

            if (conexionDB.State == ConnectionState.Open)
            {
                var updateQuery = "UPDATE Tutor SET Nombre = '" + tutor.Nombre + "', Apellido = '" + tutor.Apellido + "', DNI = '" + tutor.DNI + "', Reparticion = '" + tutor.Reparticion + "' WHERE idTutor = " + id;

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
        /// Metodo para obtener los instructores de la base de dato
        /// </summary>
        /// <param name="instructores">Lista de instructores</param>
        /// <param name="ides">Lista en donde se cargaran los id en orden de los instructores</param>
        /// <returns>Devuelve un string con un mensaje dependiendo del resultado de la accion</returns>
        public static string GetInstructores(List<Instructor> instructores, List<int> ides)
        {
            Instructor instructor;

            string mensaje;

            try
            {
                cnn = new MySqlConnection();

                cnn = Conexion.Conectar();

                string selectQuery;

                selectQuery = "SELECT * FROM Instructor";

                cmd = new MySqlCommand(selectQuery, cnn);

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    instructor = new Instructor();

                    ides.Add(Convert.ToInt32(dtr.GetString(0)));

                    instructor.Nombre = dtr.GetString(1);

                    instructor.Apellido = dtr.GetString(2);

                    instructor.DNI = dtr.GetString(3);

                    instructor.Reparticion = dtr.GetString(4);

                    instructores.Add(instructor);
                }

                mensaje = "Instructores cargados";

                return mensaje;
            }
            catch (Exception ex)
            {
                mensaje = "Error " + ex.Message;

                return mensaje;
            }
        }


        /// <summary>
        /// Metodo para obtener los tutores de la base de dato
        /// </summary>
        /// <param name="tutores">Lista de tutores</param>
        /// <param name="ides">Lista en donde se cargaran los id en orden de los tutores</param>
        /// <returns>Devuelve un string con un mensaje dependiendo del resultado de la accion</returns>
        public static string GetTutores(List<Tutor> tutores, List<int> ides)
        {
            Tutor tutor;

            string mensaje;

            try
            {
                cnn = new MySqlConnection();

                cnn = Conexion.Conectar();

                string selectQuery;

                selectQuery = "SELECT * FROM Tutor";

                cmd = new MySqlCommand(selectQuery, cnn);

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    tutor = new Tutor();

                    ides.Add(Convert.ToInt32(dtr.GetString(0)));

                    tutor.Nombre = dtr.GetString(1);

                    tutor.Apellido = dtr.GetString(2);

                    tutor.DNI = dtr.GetString(3);

                    tutor.Reparticion = dtr.GetString(4);

                    tutores.Add(tutor);
                }

                mensaje = "Tutores cargados";

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
