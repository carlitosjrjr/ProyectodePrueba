using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class OperacionesSQL
    {
        //Cadena de conexion a la base de datos recuperad del archivo de configuración
        public static string _connectionString = ConfigurationManager.ConnectionStrings["BDLibrary"].ConnectionString;

        /// <summary>
        /// Retorna un comando sql relacionado a la conexion
        /// </summary>
        /// <returns></returns>
        public static SqlCommand CreateBasicCommand()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            return cmd;
        }

        /// <summary>
        /// Retorna el objeto de la conexion a la base de datos
        /// </summary>
        /// <returns></returns>
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            return connection;
        }
        /// <summary>
        /// Retorna un comando sql relacionado a la conexion
        /// </summary>
        /// <param name="query">consulta para ejecutar el comando</param>
        /// <returns></returns>
        public static SqlCommand CreateBasicCommand(string query)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = connection;
            return cmd;
        }

        /// <summary>
        /// Retorna un comando sql relacionado a la conexion
        /// </summary>
        /// <param name="query">consulta para ejecutar el comando</param>
        /// <returns></returns>
        public static SqlCommand CreateBasicCommandWithTransaction(string query, SqlTransaction transaccion, SqlConnection conexion)
        {
            SqlConnection connection = conexion;
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = connection;
            cmd.Transaction = transaccion;
            return cmd;
        }

        /// <summary>
        /// recibe un sql command y lo ejecuta con ExecuteNonQuery();  
        /// </summary>
        /// <param name="cmd"> comando relacionado con una conexion</param>
        public static void ExecuteBasicCommand(SqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                WriteLogsRelease("Methods", "SqlException in ExecuteBasicCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteBasicCommand(SqlCommand cmd)", ex);
            }
            catch (Exception ex)
            {
                WriteLogsRelease("Methods", "Exception in ExecuteBasicCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteBasicCommand(SqlCommand cmd)", ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        /// <summary>
        /// recibe un sql command y lo ejecuta con ExecuteNonQuery();  
        /// </summary>
        /// <param name="cmd"> comando relacionado con una conexion</param>
        public static void ExecuteBasicCommandWithTransaction(SqlCommand cmd)
        {
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                WriteLogsRelease("Methods", "SqlException in ExecuteBasicCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteBasicCommand(SqlCommand cmd)", ex);
            }
            catch (Exception ex)
            {
                WriteLogsRelease("Methods", "Exception in ExecuteBasicCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteBasicCommand(SqlCommand cmd)", ex);
            }

        }

        private static void WriteLogsRelease(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// realiza un conteo hasta 255
        /// </summary>
        /// <param name="cmd">comando a ejecutar COUNT</param>
        /// <returns>retornael valor del count</returns>
        public static byte ExecuteBasicCommandCount(SqlCommand cmd)
        {
            byte x;
            try
            {
                cmd.Connection.Open();
                x = (byte)cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                WriteLogsRelease("Methods", "SqlException in ExecuteBasicCommandCount", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteBasicCommandCount(SqlCommand cmd)", ex);
            }
            catch (Exception ex)
            {
                WriteLogsRelease("Methods", "Exception in ExecuteBasicCommandCount", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteBasicCommandCount(SqlCommand cmd)", ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
            return x;
        }

        /// <summary>
        /// recibe un sql command y consulta sql en caso de no usar el otro metodo
        /// </summary>
        /// <param name="cmd">sql command</param>
        /// <param name="query">consulta</param>
        public static void ExecuteBasicCommand(SqlCommand cmd, string query)
        {
            try
            {
                cmd.CommandText = query;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                WriteLogsRelease("Methods", "SqlException in ExecuteBasicCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteBasicCommand(SqlCommand cmd, string query)", ex);
            }
            catch (Exception ex)
            {
                WriteLogsRelease("Methods", "Exception in ExecuteBasicCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteBasicCommand(SqlCommand cmd, string query)", ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        /// <summary>
        /// recibe un comando lo ejecuta y retorna el resultado en un datatable
        /// </summary>
        /// <param name="cmd">sql command con consulta select</param>
        /// <returns>data table con resultado de un select</returns>
        public static DataTable ExcecuteDataTableCommand(SqlCommand cmd)
        {
            DataTable res = new DataTable();

            try
            {
                cmd.Connection.Open();
                SqlDataAdapter data = new SqlDataAdapter(cmd);//la conexion ya esta abierta
                data.Fill(res);

            }
            catch (SqlException ex)
            {
                WriteLogsRelease("Methods", "SqlException in ExcecuteDataTableCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExcecuteDataTableCommand(SqlCommand cmd)", ex);
            }
            catch (Exception ex)
            {
                WriteLogsRelease("Methods", "Exception in ExcecuteDataTableCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExcecuteDataTableCommand(SqlCommand cmd)", ex);
            }
            finally
            {
                cmd.Connection.Close();
            }

            return res;
        }

        /// <summary>
        /// recibe un comando lo ejecuta y retorna el resultado en un datatable
        /// </summary>
        /// <param name="cmd">sql command con consulta select</param>
        /// <returns>data table con resultado de un select</returns>
        public static DataTable ExcecuteDataTableCommand()
        {
            DataTable res = new DataTable();

            try
            {
                //  cmd.Connection.Open();.
                SqlDataAdapter data = new SqlDataAdapter();//la conexion ya esta abierta
                data.Fill(res);

            }
            catch (SqlException ex)
            {
                WriteLogsRelease("Methods", "SqlException in ExcecuteDataTableCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExcecuteDataTableCommand()", ex);
            }
            catch (Exception ex)
            {
                WriteLogsRelease("Methods", "Exception in ExcecuteDataTableCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExcecuteDataTableCommand()", ex);
            }

            return res;
        }

        /// <summary>
        /// devuelve un data reader
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteDataReaderCommand(SqlCommand cmd)
        {
            SqlDataReader res = null;
            try
            {
                cmd.Connection.Open();
                res = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                WriteLogsRelease("Methods", "SqlException in ExcecuteDataReaderCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteDataReaderCommand(SqlCommand cmd)", ex);
            }
            catch (Exception ex)
            {
                WriteLogsRelease("Methods", "Exception in ExcecuteDataReaderCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteDataReaderCommand(SqlCommand cmd)", ex);
            }
            return res;
        }

        /// <summary>
        /// comand scalar
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string ExcecuteScalarCommand(SqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                return cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                WriteLogsRelease("Methods", "SqlException in ExcecuteScalarCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExcecuteScalarCommand(SqlCommand cmd)", ex);
            }
            catch (Exception ex)
            {
                WriteLogsRelease("Methods", "Exception in ExcecuteScalarCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExcecuteScalarCommand(SqlCommand cmd)", ex);
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        /// <summary>
        /// consigue el siguiente id de una tabla aummentado con su incremento
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public static int GetNextIdTable(string tabla)
        {
            int res = -1;
            string query = "SELECT IDENT_CURRENT('" + tabla + "')+ IDENT_INCR('" + tabla + "')";
            try
            {
                SqlCommand cmd = CreateBasicCommand(query);
                res = int.Parse(ExcecuteScalarCommand(cmd));
            }
            catch (SqlException ex)
            {
                WriteLogsRelease("Methods", "SqlException in GetNextIDTable", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método GetNextIdTable(string tabla)", ex);
            }
            catch (Exception ex)
            {
                WriteLogsRelease("Methods", "Exception in GetNextIDTable", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método GetNextIdTable(string tabla)", ex);
            }
            return res;
        }

        /// <summary>
        /// consigue el ultimo id de una tabla
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public static int GetActIdTable(string tabla)
        {
            int res = -1;
            string query = "SELECT IDENT_CURRENT('" + tabla + "')";
            try
            {
                SqlCommand cmd = CreateBasicCommand(query);
                res = int.Parse(ExcecuteScalarCommand(cmd));
            }
            catch (SqlException ex)
            {
                WriteLogsRelease("Methods", "SqlException in GetActIDTable", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método GetActIdTable(string tabla)", ex);
            }
            catch (Exception ex)
            {
                WriteLogsRelease("Methods", "Exception in GetActIDTable", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método GetActIdTable(string tabla)", ex);
            }
            return res;
        }

        /// <summary>
        /// ejecuta n comandos en una transaccion
        /// </summary>
        /// <param name="cmds">lista de comandos a ejecutar</param>
        public static void ExecuteNBasicCommand(List<SqlCommand> cmds)
        {
            SqlTransaction tran = null;
            SqlCommand cmd1 = cmds[0];
            try
            {
                cmd1.Connection.Open();
                tran = cmd1.Connection.BeginTransaction();

                foreach (SqlCommand cmd in cmds)
                {
                    cmd.Transaction = tran;
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                WriteLogsRelease("Methods", "SqlException in ExecuteNBasicCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteNBasicCommand(List<SqlCommand> cmds)", ex);
            }
            catch (Exception ex)
            {
                tran.Rollback();
                WriteLogsRelease("Methods", "Exception in ExecuteNBasicCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteNBasicCommand(List<SqlCommand> cmds)", ex);
            }
            finally
            {
                cmd1.Connection.Close();
            }
        }
        public static void Execute2BasicCommand(SqlCommand cmd1, SqlCommand cmd2)
        {

            try
            {
                cmd1.Connection.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                WriteLogsRelease("Methods", "SqlException in ExecuteNBasicCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteNBasicCommand(List<SqlCommand> cmds)", ex);
            }
            catch (Exception ex)
            {

                WriteLogsRelease("Methods", "Exception in ExecuteNBasicCommand", string.Format("{0} {1}", ex.Message, ex.StackTrace));
                throw new Exception("Se ha producido un error en el método ExecuteNBasicCommand(List<SqlCommand> cmds)", ex);
            }
            finally
            {
                cmd1.Connection.Close();
            }
        }

        /// <summary>
        /// crea n comandos para ejecutarlos despues recibiendo una lista de consultas
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static List<SqlCommand> CreateNCommands(List<string> lista)
        {
            List<SqlCommand> res = new List<SqlCommand>();

            SqlConnection connection = new SqlConnection(_connectionString);
            for (int i = 0; i < lista.Count; i++)
            {
                SqlCommand cmd = new SqlCommand(lista[i]);
                cmd.Connection = connection;
                res.Add(cmd);
            }

            return res;
        }

        /// <summary>
        /// crea n comandos 
        /// </summary>
        /// <param name="x">cantidad de comandos a crear</param>
        /// <returns></returns>
        public static List<SqlCommand> CreateNCommands(int x)
        {
            List<SqlCommand> res = new List<SqlCommand>();

            SqlConnection connection = new SqlConnection(_connectionString);
            for (int i = 0; i < x; i++)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                res.Add(cmd);
            }
            return res;
        }
    }
}

