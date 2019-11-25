using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class Methods
    {
        /// <summary>
        /// cadena de conexion del app.config en DAL
        /// </summary>
        private static string connectionString = ConfigurationManager.ConnectionStrings["BDLibrary"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        #region Creacion de SQLCommand
        /// <summary>
        /// Creamos un sqlCommand y se relaciona a una conexion de BD
        /// </summary>
        /// <returns></returns>
        public static SqlCommand CreateBasicCommand()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            return cmd;
        }
        /// <summary>
        /// Creamos un sqlCommand y se relaciona a una conexion de BD
        /// </summary>
        /// <param name="query">Consulta SQL</param>
        /// <returns>SqlCommand creado y relacionado a la conexion de BD</returns>
        public static SqlCommand CreateBasicCommand(string query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = connection;
            return cmd;
        }
        /// <summary>
        /// Creamos una lista de comandos y se relaciona con la conexion de BD
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<SqlCommand> CreateNBasicCommand(int n)
        {
            List<SqlCommand> res = new List<SqlCommand>();

            //Creamos la conexion
            SqlConnection connection = new SqlConnection(connectionString);

            for (int i = 0; i < n; i++)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                res.Add(cmd);
            }


            return res;
        }

        #endregion

        #region Ejecucion de sqlCommand
        /// <summary>
        /// Ejecuta dos comandos basicos
        /// </summary>
        /// <param name="cmd1"></param>
        /// <param name="cmd2"></param>
        public static void Execute2BasicCommand(SqlCommand cmd1, SqlCommand cmd2)
        {
            SqlTransaction tran = null;

            try
            {
                cmd1.Connection.Open();
                tran = cmd1.Connection.BeginTransaction();
                cmd1.Transaction = tran;
                cmd1.ExecuteNonQuery();

                cmd2.Transaction = tran;
                cmd2.ExecuteNonQuery();

                //NO existe error
                tran.Commit();

            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                cmd1.Connection.Close();
            }

        }
        /// <summary>
        /// Obtiene el ultimo ID de una tabla
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public static short GetIDGenerateTable(string tabla)
        {
            short res = -1;
            string query = "SELECT IDENT_CURRENT('" + tabla + "')+IDENT_INCR('" + tabla + "')";

            try
            {
                SqlCommand cmd = CreateBasicCommand(query);
                res = short.Parse(ExecuteScalarCommand(cmd));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }
        /// <summary>
        /// Obtiene el ultimo ID de una tabla
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public static int GetIDGenerateTableInt(string tabla)
        {
            int res = -1;
            string query = "SELECT IDENT_CURRENT('" + tabla + "')+IDENT_INCR('" + tabla + "')";

            try
            {
                SqlCommand cmd = CreateBasicCommand(query);
                res = int.Parse(ExecuteScalarCommand(cmd));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }
        /// <summary>
        /// Obtiene el maximo ID de una tabla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public static short GetMaxIDTable(string id, string tabla)
        {
            short res = -1;
            string query = "SELECT MAX(" + id + ") FROM " + tabla;

            try
            {
                SqlCommand cmd = CreateBasicCommand(query);
                res = short.Parse(ExecuteScalarCommand(cmd));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }
        /// <summary>
        /// Ejecuta un comando basico
        /// </summary>
        /// <param name="cmd"></param>
        public static void ExecuteBasicCommand(SqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        /// <summary>
        /// Ejecuta un comando basico con la consulta
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="query"></param>
        public static void ExecuteBasicCommand(SqlCommand cmd, string query)
        {
            try
            {
                cmd.CommandText = query;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        /// <summary>
        /// Ejecuta multiples comandos de una lista de comandos
        /// </summary>
        /// <param name="cmds"></param>
        public static void ExecuteNBasicCommand(List<SqlCommand> cmds)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction tran = null;

            try
            {
                connection.Open();
                tran = connection.BeginTransaction();
                foreach (SqlCommand cmd in cmds)
                {
                    cmd.Connection = connection;

                    cmd.Transaction = tran;
                    cmd.ExecuteNonQuery();

                }
                tran.Commit();
            }
            catch (Exception)
            {
                tran.Rollback();
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// Ejecuta un comando retornando un DataTable
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTableCommand(SqlCommand cmd)
        {
            DataTable res = new DataTable();
            try
            {
                cmd.Connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }

        /// <summary>
        /// Ejecuta un comando en el cuelo devuelve un data reader que seria todas las filas de la consulta ejecutada
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteDataReaderCommand(SqlCommand cmd)
        {
            SqlDataReader dataReader = null;
            try
            {
                cmd.Connection.Open();
                dataReader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return dataReader;
        }

        /// <summary>
        /// Ejecuta un comando escalar devolviendolo como una cadena
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string ExecuteScalarCommand(SqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                return cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }


        }

        #endregion


        public static int GetMaxIDTableInt(string id, string tabla)
        {
            int res = -1;
            string query = "SELECT MAX(" + id + ") FROM " + tabla;

            try
            {
                SqlCommand cmd = CreateBasicCommand(query);
                res = int.Parse(ExecuteScalarCommand(cmd));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }
    }
}
