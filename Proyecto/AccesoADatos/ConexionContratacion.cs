﻿using System;
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
        public static string AgregarContratacion(MySqlConnection conexionDB, int idBeneficiario, int idEmpresa, decimal sueldo, string cargo)
        {
            string mensaje = "Agregado a la BD";
            string insertQuery;

            if (conexionDB.State == ConnectionState.Open)
            {
                insertQuery = "INSERT INTO Contratacion (idBeneficiario, idEmpresa, Cargo, Sueldo) VALUE (@idBeneficiario, @idEmpresa, @Cargo, @Sueldo);";

                cmd = new MySqlCommand(insertQuery, conexionDB);

                cmd.Parameters.AddWithValue("@idBeneficiario", idBeneficiario);

                cmd.Parameters.AddWithValue("@idEmpresa", idEmpresa);

                cmd.Parameters.AddWithValue("@Cargo", cargo);

                cmd.Parameters.AddWithValue("@Sueldo", sueldo);

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
        public static string ModificarContratacion(MySqlConnection conexionDB, int idBeneficiario, string cargo, decimal sueldo)
        {
            string mensaje = "Modificado de la BD correctamente";

            if (conexionDB.State == ConnectionState.Open)
            {
                var updateQuery = "UPDATE Contratacion SET Cargo = @Cargo, Sueldo = @Sueldo WHERE idBeneficiario = @idBeneficiario;";

                cmd = new MySqlCommand(updateQuery, conexionDB);

                cmd.Parameters.AddWithValue("@idBeneficiario", idBeneficiario);

                cmd.Parameters.AddWithValue("@Cargo", cargo);

                cmd.Parameters.AddWithValue("@Sueldo", sueldo);

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

    }
}
