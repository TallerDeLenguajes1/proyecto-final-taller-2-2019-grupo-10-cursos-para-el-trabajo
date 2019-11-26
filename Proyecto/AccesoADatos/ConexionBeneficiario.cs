using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
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
                //var InsertQuery = "INSERT INTO Beneficiario(Nombre, Apellido, DNI, Cuil, Email, NivelDeEscolaridad, Candidato) VALUES('" + beneficiario.Nombre + "', '" + beneficiario.Apellido + "', '" + beneficiario.DNI + "', '" + beneficiario.Cuil + "', '" + beneficiario.Email + "', '" + beneficiario.NivelDeEscolaridad + "', '" + beneficiario.Candidato + "' );";
                var InsertQuery = "INSERT INTO Beneficiario(Nombre, Apellido, DNI, Cuil, Email, NivelDeEscolaridad, Candidato) VALUES(@Nombre, @Apellido, @DNI, @Cuil, @Email, @NivelDeEscolaridad, @Candidato);";

                try
                {
                    cmd = new MySqlCommand(InsertQuery, conexionDB);

                    cmd.Parameters.AddWithValue("@Nombre", beneficiario.Nombre);

                    cmd.Parameters.AddWithValue("@Apellido", beneficiario.Apellido);

                    cmd.Parameters.AddWithValue("@DNI", beneficiario.DNI);

                    cmd.Parameters.AddWithValue("@Cuil", beneficiario.Cuil);

                    cmd.Parameters.AddWithValue("@Email", beneficiario.Email);

                    cmd.Parameters.AddWithValue("@NivelDeEscolaridad", beneficiario.NivelDeEscolaridad);

                    if (beneficiario.Candidato)
                    {
                        cmd.Parameters.AddWithValue("@Candidato", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Candidato", 0);
                    }

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
                //var deleteQuery = "DELETE FROM Beneficiario WHERE idBeneficiario = " + id;
                var deleteQuery = "DELETE FROM Beneficiario WHERE idBeneficiario = @id";

                try
                {
                    cmd = new MySqlCommand(deleteQuery, conexionDB);

                    cmd.Parameters.AddWithValue("@id", id);

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
                //var updateQuery = "UPDATE Beneficiario SET Nombre = '" + beneficiario.Nombre + "', Apellido = '" + beneficiario.Apellido + "', DNI = '" + beneficiario.DNI + "', Cuil = '" + beneficiario.Cuil + "', Email = '" + beneficiario.Email + "', NivelDeEscolaridad = '" + beneficiario.NivelDeEscolaridad + "', Candidato = '" + beneficiario.Candidato + "' WHERE idInstructor = " + id;
                var updateQuery = "UPDATE Beneficiario SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Cuil = @Cuil, Email = @Email, NivelDeEscolaridad = @NivelDeEscolaridad, Candidato = @Candidato WHERE idBeneficiario = @id";

                try
                {
                    cmd = new MySqlCommand(updateQuery, conexionDB);

                    cmd.Parameters.AddWithValue("@Nombre", beneficiario.Nombre);

                    cmd.Parameters.AddWithValue("@Apellido", beneficiario.Apellido);

                    cmd.Parameters.AddWithValue("@DNI", beneficiario.DNI);

                    cmd.Parameters.AddWithValue("@Cuil", beneficiario.Cuil);

                    cmd.Parameters.AddWithValue("@Email", beneficiario.Email);

                    cmd.Parameters.AddWithValue("@NivelDeEscolaridad", beneficiario.NivelDeEscolaridad);

                    if (beneficiario.Candidato)
                    {
                        cmd.Parameters.AddWithValue("@Candidato", 1);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Candidato", 0);
                    }

                    cmd.Parameters.AddWithValue("@id", id);

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
            Beneficiario beneficiario;

            string mensaje;

            try
            {
                cnn = new MySqlConnection();

                cnn = Conexion.Conectar();

                string selectQuery;

                selectQuery = "SELECT * FROM Beneficiario";

                cmd = new MySqlCommand(selectQuery, cnn);

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    beneficiario = new Beneficiario();

                    ides.Add(Convert.ToInt32(dtr.GetString(0)));

                    beneficiario.Nombre = dtr.GetString(1);

                    beneficiario.Apellido = dtr.GetString(2);

                    beneficiario.DNI = dtr.GetString(3);

                    beneficiario.Cuil = dtr.GetString(4);

                    beneficiario.Email = dtr.GetString(5);

                    beneficiario.NivelDeEscolaridad = dtr.GetString(6);

                    if (dtr.GetInt16(7) == 1)
                    {
                        beneficiario.Candidato = true;
                    }
                    else
                    {
                        beneficiario.Candidato = false;
                    }

                    beneficiarios.Add(beneficiario);
                }

                mensaje = "Beneficiarios cargados";

                cnn = Conexion.Desconectar();

                return mensaje;
            }
            catch (Exception ex)
            {
                mensaje = "Error " + ex.Message;

                return mensaje;
            }
        }



        public static string ActualizarCandidatos()
        {
            List<int> idesBenfEnCurso = new List<int>();
            List<int> idesCandidatos = new List<int>();

            string mensaje = "Candidatos actualizados";
            string selectQuery;
            string updateQuery;

            try
            {
                cnn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
            }

            selectQuery = "SELECT idBeneficiario FROM CursoBeneficiario";

            cmd = new MySqlCommand(selectQuery, cnn);

            dtr = cmd.ExecuteReader();

            while (dtr.Read())
            {
                idesBenfEnCurso.Add(dtr.GetInt32(0));
            }

            dtr.Close();

            // Ordeno la lista para contar los valores que se repiten
            
            var ordenarLista = idesBenfEnCurso.GroupBy(x => x).Select(g => new { Value = g.Key, Count = g.Count() }).OrderByDescending(x => x.Count);
            
            // x.Value: valor del id, x.Count Cantidad de veces que se repite el id
            foreach (var x in ordenarLista)
            {
                // Si se repite 3 veces o mas (Curso mas de 3 veces) es candidato
                if (x.Count > 2)
                {
                    idesCandidatos.Add(x.Value);
                }
            }

            foreach (var candidato in idesCandidatos)
            {
                updateQuery = "UPDATE Beneficiario SET Candidato = @Candidato WHERE idBeneficiario = @idBeneficiario;";

                cmd = new MySqlCommand(updateQuery, cnn);

                cmd.Parameters.AddWithValue("@Candidato", 1);

                cmd.Parameters.AddWithValue("@idBeneficiario", candidato);

                cmd.ExecuteNonQuery();
            }

            return mensaje;
        }
    }
}
