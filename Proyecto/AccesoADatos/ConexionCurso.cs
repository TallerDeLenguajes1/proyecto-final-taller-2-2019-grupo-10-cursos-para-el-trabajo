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

            if (conexionDB.State == ConnectionState.Open)
            {
                var InsertQuery = "INSERT INTO CursoEmpleado(idCurso, idInstructor, idTutor) VALUES(@idCurso, @idInstructor, @idTutor);";

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

            // Obtiene los beneficiarios para verificar que no este ya agregado a ese curso
            var selectQuery = "SELECT * FROM CursoBeneficiario";

            cmd = new MySqlCommand(selectQuery, conexionDB);

            dtr = cmd.ExecuteReader();

            while (dtr.Read())
            {
                if (dtr.GetInt32(0) == idCurso && dtr.GetInt32(1) == idBeneficiario)
                {
                    mensaje = "El alumno ya esta en el curso seleccionado";

                    return mensaje;
                }
            }

            dtr.Close();

            if (conexionDB.State == ConnectionState.Open)
            {
                var InsertQuery = "INSERT INTO CursoBeneficiario(idCurso, idBeneficiario) VALUES(@idCurso, @idBeneficiario);";

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
            catch (Exception)
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
            string selectQuery;

            int idInstructor = 0;
            int idTutor = 0;
            int i = 0;
            int j;

            MySqlCommand cmdPersona;
            MySqlDataReader dtrEmpleado;
            MySqlDataReader dtrBeneficiario;

            bool sinAlumnos = true;
            bool sinInstructor = true;
            bool sinTutor = true;

            List<int> idesBeneficiarios;

            try
            {
                cnn = Conexion.Conectar();

            }
            catch (Exception ex)
            {
                mensaje = "Error " + ex.Message;

                return mensaje;
            }

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

            // Recorre cada Curso obtenido y obtiene sus respectivos datos
            while (idesCurso.Count > i)
            {
                // Ahora obtiene los beneficiarios asociados a ese curso
                selectQuery = "SELECT * FROM CursoBeneficiario";

                cmd = new MySqlCommand(selectQuery, cnn);

                idesBeneficiarios = new List<int>();

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    if (dtr.GetInt32(0) == idesCurso[i])
                    {
                        if (!dtr.IsDBNull(1))
                        {
                            idesBeneficiarios.Add(dtr.GetInt32(1));

                            sinAlumnos = false;
                        }
                    }                    
                }

                dtr.Close();

                // Ahora obtiene los Empleados asociados a ese curso
                selectQuery = "SELECT * FROM CursoEmpleado WHERE idCurso = @idCurso";

                cmd = new MySqlCommand(selectQuery, cnn);

                cmd.Parameters.AddWithValue("@idCurso", idesCurso[i]);

                dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    if (!dtr.IsDBNull(1))
                    {
                        idInstructor = dtr.GetInt32(1);

                        sinInstructor = false;
                    }

                    if (!dtr.IsDBNull(2))
                    {
                        idTutor = dtr.GetInt32(2);

                        sinTutor = false;
                    }
                }

                dtr.Close();

                // Una vez obtenido todos los ides asociados al curso actual obtengo los datos de los empleados y beneficiaros de la BD

                // Empieza almacenando todos los alumnos
                cursos[i].Alumnos = new List<Beneficiario>();

                // Pregunta si aun existen los alumnos en la base de datos
                if (!sinAlumnos)
                {
                    selectQuery = "SELECT * FROM Beneficiario WHERE idBeneficiario = @idBeneficiario";                    

                    j = 0;                    

                    while (idesBeneficiarios.Count > j)
                    {
                        cmdPersona = new MySqlCommand(selectQuery, cnn);

                        cmdPersona.Parameters.AddWithValue("@idBeneficiario", idesBeneficiarios[j]);

                        dtrBeneficiario = cmdPersona.ExecuteReader();

                        while (dtrBeneficiario.Read())
                        {
                            beneficiario = new Beneficiario();

                            beneficiario.Nombre = dtrBeneficiario.GetString(1);

                            beneficiario.Apellido = dtrBeneficiario.GetString(2);

                            beneficiario.DNI = dtrBeneficiario.GetString(3);

                            beneficiario.Cuil = dtrBeneficiario.GetString(4);

                            beneficiario.Email = dtrBeneficiario.GetString(5);

                            beneficiario.NivelDeEscolaridad = dtrBeneficiario.GetString(6);

                            if (dtrBeneficiario.GetInt16(7) == 1)
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
                }


                // Almacena el instructor
                cursos[i].Instructor = new Instructor();

                // Pregunta si el instructor aun existe en la base de datos
                if (!sinInstructor)
                {
                    selectQuery = "SELECT * FROM Instructor WHERE idInstructor = @idInstructor";

                    cmdPersona = new MySqlCommand(selectQuery, cnn);

                    cmdPersona.Parameters.AddWithValue("@idInstructor", idInstructor);

                    dtrEmpleado = cmdPersona.ExecuteReader();

                    while (dtrEmpleado.Read())
                    {
                        cursos[i].Instructor.Nombre = dtrEmpleado.GetString(1);

                        cursos[i].Instructor.Apellido = dtrEmpleado.GetString(2);

                        cursos[i].Instructor.DNI = dtrEmpleado.GetString(3);

                        cursos[i].Instructor.Reparticion = dtrEmpleado.GetString(4);
                    }

                    dtrEmpleado.Close();
                }


                // Almacena el Tutor
                cursos[i].Tutor = new Tutor();

                //Pregunta si el tutor aun existe en la base de datos
                if (!sinTutor)
                {
                    selectQuery = "SELECT * FROM Tutor WHERE idTutor = @idTutor";

                    cmdPersona = new MySqlCommand(selectQuery, cnn);

                    cmdPersona.Parameters.AddWithValue("@idTutor", idTutor);

                    dtrEmpleado = cmdPersona.ExecuteReader();

                    while (dtrEmpleado.Read())
                    {
                        cursos[i].Tutor.Nombre = dtrEmpleado.GetString(1);

                        cursos[i].Tutor.Apellido = dtrEmpleado.GetString(2);

                        cursos[i].Tutor.DNI = dtrEmpleado.GetString(3);

                        cursos[i].Tutor.Reparticion = dtrEmpleado.GetString(4);
                    }

                    dtrEmpleado.Close();
                }                

                i++;
            }

            mensaje = "Cursos cargados";

            cnn = Conexion.Desconectar();

            return mensaje;
        }


        public static string GetCurso(List<Curso> cursos, List<int> idesCurso)
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
