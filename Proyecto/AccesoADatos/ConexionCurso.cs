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
    public class ConexionCurso
    {
        private static MySqlCommand cmd;
        private static MySqlConnection cnn;
        private static MySqlDataReader dtr;


        /// <summary>
        /// Agrega Curso a la base de datos
        /// </summary>
        /// <param name="conexionDB"></param>
        /// <param name="curso"></param>
        /// <returns></returns>
        public static string AgregarCursoTema(MySqlConnection conexionDB, string tema)
        {
            string mensaje;

            if (conexionDB.State == ConnectionState.Open)
            {
                var InsertQuery = "INSERT INTO Curso(Tema) VALUES(@Tema);";

                try
                {
                    cmd = new MySqlCommand(InsertQuery, conexionDB);

                    cmd.Parameters.AddWithValue("@Tema", tema);

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
        /// Agrega el instructor y tutor que estaran al curso y los vincula a la base de datos
        /// </summary>
        /// <param name="conexionDB"></param>
        /// <param name="idInstructor"></param>
        /// <param name="idTutor"></param>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public static string AgregarEmpleadosAlCurso(MySqlConnection conexionDB,int idInstructor, int idTutor, int idCurso)
        {
            string mensaje;

            var existenciaDelCurso = false;

            if (conexionDB.State == ConnectionState.Open)
            {
                var selectQuery = "SELECT * FROM cursobeneficiaro";

                cmd = new MySqlCommand(selectQuery, conexionDB);

                dtr = cmd.ExecuteReader();

                // Revisa y compara los id para no crear el mismo curso mas de una vez
                while (dtr.Read() && !existenciaDelCurso)
                {
                    if (idCurso == dtr.GetInt16(1))
                    {
                        existenciaDelCurso = true;
                    }
                }

                dtr.Close();

                // Si la existenciaDelCurso es falsa el curso no fue ingresado y se lo puede crear
                if (!existenciaDelCurso)
                {
                    var InsertQuery = "INSERT INTO CursoBeneficiaro(idCurso, idInstructor, idTutor) VALUES(@idCurso, @idInstructor, @idTutor);";

                    try
                    {
                        cmd = new MySqlCommand(InsertQuery, conexionDB);

                        cmd.Parameters.AddWithValue("@idCurso", idCurso);

                        cmd.Parameters.AddWithValue("@idInstructor", idInstructor);

                        cmd.Parameters.AddWithValue("@idTutor", idTutor);

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
                    mensaje = "El Curso ya fue creado";

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
        /// Agrega el beneficiario al curso
        /// </summary>
        /// <param name="conexionDB"></param>
        /// <param name="idBeneficiario"></param>
        /// <param name="idCurso"></param>
        /// <returns></returns>
        public static string AgregarAlumno(MySqlConnection conexionDB, int idBeneficiario, int idCurso)
        {
            string mensaje;

            if (conexionDB.State == ConnectionState.Open)
            {
                var InsertQuery = "INSERT INTO CursoBeneficiario(idBeneficiario) VALUES(@idBeneficiario) WHERE idCurso = @idCurso;";

                try
                {
                    cmd = new MySqlCommand(InsertQuery, conexionDB);

                    cmd.Parameters.AddWithValue("@idBeneficiario", idBeneficiario);

                    cmd.Parameters.AddWithValue("@idCurso", idCurso);

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



        public static int GetidCursoTema()
        {
            int idCurso = 0;

            try
            {
                cnn = new MySqlConnection();

                cnn = Conexion.Conectar();

            }
            catch (Exception ex)
            {
                
            }

            string selectQuery;

            // Almacena todos los cursos de la base de datos
            selectQuery = "SELECT * FROM Curso";

            cmd = new MySqlCommand(selectQuery, cnn);

            dtr = cmd.ExecuteReader();

            while (dtr.Read())
            {
                idCurso = dtr.GetInt32(0);
            }

            return idCurso;
        }



        public static string GetCursos(List<Curso> cursos, List<int> idesCurso)
        {
            Curso curso;

            Beneficiario beneficiario;

            string mensaje;

            int idInstructor = 0;

            int idTutor = 0;

            List<int> idesBeneficiarios;

            MySqlCommand cmdPersona;
            MySqlDataReader dtrEmpleado;
            MySqlDataReader dtrBeneficiario;

            try
            {
                cnn = new MySqlConnection();

                cnn = Conexion.Conectar();

            }
            catch (Exception ex)
            {
                mensaje = "Error " + ex.Message;

                return mensaje;
            }

            string selectQuery;

            // Almacena todos los cursos de la base de datos
            selectQuery = "SELECT * FROM Curso";

            cmd = new MySqlCommand(selectQuery, cnn);

            dtr = cmd.ExecuteReader();

            while (dtr.Read())
            {
                curso = new Curso();

                idesCurso.Add(Convert.ToInt32(dtr.GetString(0)));

                curso.Tema = dtr.GetString(1);

                cursos.Add(curso);
            }

            dtr.Close();

            int i = 0;

            int j;

            // Recorre cada Curso obtenido y obtiene sus respectivos datos
            while (idesCurso.Count > i)
            {
                // Ahora obtiene los empleados y beneficiarios asociados a ese curso
                selectQuery = "SELECT * FROM CursoBeneficiaro WHERE idCurso = @idCurso";

                cmd = new MySqlCommand(selectQuery, cnn);

                idesBeneficiarios = new List<int>();

                cmd.Parameters.AddWithValue("@idCurso", idesCurso[i]);

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    if (!dtr.IsDBNull(0))
                    {
                        idesBeneficiarios.Add(dtr.GetInt32(0));
                    }

                    idInstructor = dtr.GetInt16(2);

                    idTutor = dtr.GetInt16(3);
                }

                dtr.Close();

                // Una vez obtenido todos los ides asociados al curso actual obtengo los datos de los empleados y beneficiaros de la BD

                // Empieza almacenando todos los alumnos
                selectQuery = "SELECT * FROM Beneficiario WHERE idBeneficiario = @idBeneficiario";

                cmdPersona = new MySqlCommand(selectQuery, cnn);

                j = 0;

                cursos[i].Alumnos = new List<Beneficiario>();

                while (idesBeneficiarios.Count > j)
                {
                    cmdPersona.Parameters.AddWithValue("@idBeneficiario", idesBeneficiarios[j]);

                    dtrBeneficiario = cmdPersona.ExecuteReader();

                    while (dtrBeneficiario.Read())
                    {
                        beneficiario = new Beneficiario();

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

                        cursos[i].Alumnos.Add(beneficiario);
                    }

                    j++;

                    dtrBeneficiario.Close();
                }

                // Almacena el instructor
                selectQuery = "SELECT * FROM Instructor WHERE idInstructor = @idInstructor";

                cmdPersona = new MySqlCommand(selectQuery, cnn);

                cmdPersona.Parameters.AddWithValue("@idInstructor", idInstructor);

                dtrEmpleado = cmdPersona.ExecuteReader();

                while (dtrEmpleado.Read())
                {
                    cursos[i].Instructor = new Instructor();

                    cursos[i].Instructor.Nombre = dtrEmpleado.GetString(1);

                    cursos[i].Instructor.Apellido = dtrEmpleado.GetString(2);

                    cursos[i].Instructor.DNI = dtrEmpleado.GetString(3);

                    cursos[i].Instructor.Reparticion = dtrEmpleado.GetString(4);
                }

                dtrEmpleado.Close();

                // Almacena el Tutor
                selectQuery = "SELECT * FROM Tutor WHERE idTutor = @idTutor";

                cmdPersona = new MySqlCommand(selectQuery, cnn);

                cmdPersona.Parameters.AddWithValue("@idTutor", idTutor);

                dtrEmpleado = cmdPersona.ExecuteReader();

                while (dtrEmpleado.Read())
                {
                    cursos[i].Tutor = new Tutor();

                    cursos[i].Tutor.Nombre = dtrEmpleado.GetString(1);

                    cursos[i].Tutor.Apellido = dtrEmpleado.GetString(2);

                    cursos[i].Tutor.DNI = dtrEmpleado.GetString(3);

                    cursos[i].Tutor.Reparticion = dtrEmpleado.GetString(4);
                }

                dtrEmpleado.Close();

                i++;
            }

            mensaje = "Cursos cargados";

            cnn = Conexion.Desconectar();

            return mensaje;
        } 
    }
}
