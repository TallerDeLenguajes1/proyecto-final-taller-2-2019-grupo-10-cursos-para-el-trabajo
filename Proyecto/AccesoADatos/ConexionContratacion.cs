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
    public class ConexionContratacion
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        static MySqlCommand cmd;
        static MySqlDataReader dtr;
        static MySqlConnection cnn;


        /// <summary>
        /// Agrega la contratacion a la BD
        /// </summary>
        /// <param name="conexionDB"></param>
        /// <param name="idBeneficiario"></param>
        /// <param name="idEmpresa"></param>
        /// <param name="sueldo"></param>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public static string AgregarContratacion(MySqlConnection conexionDB, int idBeneficiario, int idEmpresa, Contratacion contratacion)
        {
            string mensaje = "Agregado a la BD";
            string insertQuery;

            if (conexionDB.State == ConnectionState.Open)
            {
                insertQuery = "INSERT INTO Contratacion (idBeneficiario, idEmpresa, Cargo, Sueldo) VALUE (@idBeneficiario, @idEmpresa, @Cargo, @Sueldo);";

                cmd = new MySqlCommand(insertQuery, conexionDB);

                cmd.Parameters.AddWithValue("@idBeneficiario", idBeneficiario);

                cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);

                cmd.Parameters.AddWithValue("@Cargo", contratacion.Cargo);

                cmd.Parameters.AddWithValue("@Sueldo", contratacion.Sueldo);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Agregar contratacion command");

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
        /// Eliminar contratacion de la BD
        /// </summary>
        /// <param name="conexioDB"></param>
        /// <param name="idBeneficiario"></param>
        /// <returns></returns>
        public static string EliminarContratacion(MySqlConnection conexioDB, int idBeneficiario)
        {
            string mensaje = "Eliminado de la BD";

            if (conexioDB.State == ConnectionState.Open)
            {
                var deleteQuery = "DELETE FROM Contratacion WHERE idBeneficiario = @idBeneficiario";

                cmd = new MySqlCommand(deleteQuery, conexioDB);

                cmd.Parameters.AddWithValue("@idBeneficiario", idBeneficiario);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Eliminar contratacion command");

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
        /// Modifica la contratacion de la BD
        /// </summary>
        /// <param name="conexionDB"></param>
        /// <param name="idBeneficiario"></param>
        /// <param name="cargo"></param>
        /// <param name="sueldo"></param>
        /// <returns></returns>
        public static string ModificarContratacion(MySqlConnection conexionDB, int idBeneficiario, Contratacion contratacion)
        {
            string mensaje = "Modificado de la BD correctamente";

            if (conexionDB.State == ConnectionState.Open)
            {
                var updateQuery = "UPDATE Contratacion SET Cargo = @Cargo, Sueldo = @Sueldo WHERE idBeneficiario = @idBeneficiario;";

                cmd = new MySqlCommand(updateQuery, conexionDB);

                cmd.Parameters.AddWithValue("@idBeneficiario", idBeneficiario);

                cmd.Parameters.AddWithValue("@Cargo", contratacion.Cargo);

                cmd.Parameters.AddWithValue("@Sueldo", contratacion.Sueldo);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Modificar contratacion command");

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
        /// Obtiene las contrataciones de la BD
        /// </summary>
        /// <param name="contrataciones"></param>
        /// <param name="idesBeneficiarios"></param>
        /// <param name="idesEmpresas"></param>
        /// <returns></returns>
        public static string GetContrataciones(List<Contratacion> contrataciones, List<int> idesBeneficiarios, List<int> idesEmpresas)
        {
            string mensaje = "Empresas cargadas de la BD";

            Contratacion contratacion;

            try
            {
                cnn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Obtener contrataciones conexion");

                mensaje = ex.Message;

                return mensaje;
            }

            var selectQuery = "SELECT * FROM Contratacion;";

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
                contratacion = new Contratacion();

                idesBeneficiarios.Add(dtr.GetInt32(0));

                idesEmpresas.Add(dtr.GetInt32(1));

                contratacion.Cargo = dtr.GetString(2);

                contratacion.Sueldo = dtr.GetDecimal(3);

                contrataciones.Add(contratacion);
            }

            cnn = Conexion.Desconectar();

            return mensaje;
        }


        /// <summary>
        /// Revisa el id para saber si ya se encuentra contratado
        /// </summary>
        /// <param name="idBeneficiario"></param>
        /// <returns>Devuelve true si ya se encuentra contratado</returns>
        public static bool RevisarSiYaEstaContratado(int idBeneficiario)
        {
            bool resultado = false;

            try
            {
                cnn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Revisar contratos conexion");
            }

            var selectQuery = "SELECT idBeneficiario FROM Contratacion";

            cmd = new MySqlCommand(selectQuery, cnn);

            try
            {
                dtr = cmd.ExecuteReader();
            }
            catch (Exception)
            {

            }

            while (dtr.Read())
            {
                if (dtr.GetInt32(0) == idBeneficiario)
                {
                    resultado = true;
                }
            }

            return resultado;
        }



        /// <summary>
        /// Obtiene los contratados de una empresa en especifico
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="contratados"></param>
        /// <param name="contratos"></param>
        public static void GetEmpresaSeleccionada(int idEmpresa, List<Beneficiario> contratados, List<Contratacion> contratos)
        {
            var idesBeneficiariosContratados = new List<int>();

            Beneficiario beneficiario;

            Contratacion contrato;

            var selectQuery = "SELECT * FROM Contratacion WHERE idEmpresa = @idEmpresa";

            try
            {
                cnn = Conexion.Conectar();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Obtener contratos de una empresa conexion");
            }

            cmd = new MySqlCommand(selectQuery, cnn);

            cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);

            try
            {
                dtr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Obtener contratos de una empresa dtr");
            }

            while (dtr.Read())
            {
                idesBeneficiariosContratados.Add(dtr.GetInt32(0));

                contrato = new Contratacion();

                contrato.Cargo = dtr.GetString(2);

                contrato.Sueldo = dtr.GetDecimal(3);

                contratos.Add(contrato);
            }

            dtr.Close();

            foreach (var idBeneficiarioContratado in idesBeneficiariosContratados)
            {
                selectQuery = "SELECT * FROM Beneficiario WHERE idBeneficiario = @idBeneficiario";

                cmd = new MySqlCommand(selectQuery, cnn);

                cmd.Parameters.AddWithValue("@idBeneficiario", idBeneficiarioContratado);

                try
                {
                    dtr = cmd.ExecuteReader();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Obtener contratos de una empresa dtr2");
                }

                while (dtr.Read())
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

                    contratados.Add(beneficiario);
                }

                dtr.Close();
            }

        }

    }
}
