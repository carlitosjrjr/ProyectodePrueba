using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PrestamoDAL
    {
        /// <summary>
        /// Actualiza Persona de la base de datos
        /// </summary>
        /// <param name="Persona"></param>
        public static void Prestamo(Prestamo prestamo, Libros libro)
        {
            //Operaciones.WriteLogsDebug("PersonaDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Persona"));

            string queryString1 = @"UPDATE Prestamo SET reserva = 2, fechaPrestamo = @fecha_prestamo, fechaDevolucion = @fecha_devolucion 
                                   WHERE idPrestamo = @id";

            string queryString2 = @"UPDATE Libro SET stock = (stock - 1) WHERE idLibro=@idLibro";

            List<SqlCommand> commands = new List<SqlCommand>();
            try
            {
                //Creamos los comados
                commands = OperacionesSQL.CreateNCommands(2);
                //Asignamos las consualtas
                SqlCommand command1 = (SqlCommand)commands[0];
                command1.CommandText = queryString1;

                SqlCommand command2 = (SqlCommand)commands[1];
                command2.CommandText = queryString2;

                command1.Parameters.AddWithValue("@id", prestamo.IdPrestamo);
                command1.Parameters.AddWithValue("@fecha_prestamo", prestamo.FechaPrestamo);
                command1.Parameters.AddWithValue("@fecha_devolucion", prestamo.FechaDevolucion);

                command2.Parameters.AddWithValue("@idLibro", libro.IdLibro);
                command2.Parameters.AddWithValue("@stock", libro.Stock);

                //
                OperacionesSQL.ExecuteNBasicCommand(commands);
            }
            catch (SqlException ex)
            {
               // Operaciones.WriteLogsRelease("PersonaDal", "Actualizar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                //Operaciones.WriteLogsRelease("PersonaDal", "Actualizar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

           // Operaciones.WriteLogsDebug("PersonaDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));

        }

        /// <summary>
        /// Actualiza Persona de la base de datos
        /// </summary>
        /// <param name="Persona"></param>
        public static void Devolucion(Prestamo prestamo, Libros libro)
        {
           // Operaciones.WriteLogsDebug("PersonaDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Persona"));

            string queryString1 = @"UPDATE Prestamo SET reserva = 3, fechaPrestamo = @fecha_prestamo, fechaDevolucion = @fecha_devolucion 
                                   WHERE idPrestamo = @id";

            string queryString2 = @"UPDATE Libro SET stock = (stock + 1) WHERE idLibro=@idLibro";

            List<SqlCommand> commands = new List<SqlCommand>();
            try
            {
                //Creamos los comados
                commands = OperacionesSQL.CreateNCommands(2);
                //Asignamos las consualtas
                SqlCommand command1 = (SqlCommand)commands[0];
                command1.CommandText = queryString1;

                SqlCommand command2 = (SqlCommand)commands[1];
                command2.CommandText = queryString2;

                command1.Parameters.AddWithValue("@id", prestamo.IdPrestamo);
                command1.Parameters.AddWithValue("@fecha_prestamo", prestamo.FechaPrestamo);
                command1.Parameters.AddWithValue("@fecha_devolucion", prestamo.FechaDevolucion);

                command2.Parameters.AddWithValue("@idLibro", libro.IdLibro);

                //
                OperacionesSQL.ExecuteNBasicCommand(commands);
            }
            catch (SqlException ex)
            {
               // Operaciones.WriteLogsRelease("PersonaDal", "Actualizar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
               // Operaciones.WriteLogsRelease("PersonaDal", "Actualizar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

            //Operaciones.WriteLogsDebug("PersonaDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));

        }

        /// <summary>
        /// Actualiza Persona de la base de datos
        /// </summary>
        /// <param name="Persona"></param>
        public static void ActulizarFecha(Prestamo prestamo)
        {
            //Operaciones.WriteLogsDebug("PersonaDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Persona"));
            SqlCommand command = null;
            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Prestamo SET fechaDevolucion = @fecha_devolucion 
                                   WHERE idPrestamo = @id";
            try
            {
                command = OperacionesSQL.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@id", prestamo.IdPrestamo);
                command.Parameters.AddWithValue("@fecha_devolucion", prestamo.FechaDevolucion);

                OperacionesSQL.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                //Operaciones.WriteLogsRelease("PersonaDal", "Actualizar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                //Operaciones.WriteLogsRelease("PersonaDal", "Actualizar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

           // Operaciones.WriteLogsDebug("PersonaDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));


        }
        /// <summary>
        /// Actualiza Persona de la base de datos
        /// </summary>
        /// <param name="Persona"></param>
        public static void Multas(Prestamo prestamo)
        {
           // Operaciones.WriteLogsDebug("PersonaDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Persona"));
            SqlCommand command = null;
            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Prestamo SET Multas=1 , Monto_multas = @monto_multas
                                   WHERE IdPrestamo = @id";
            try
            {
                command = OperacionesSQL.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@id", prestamo.IdPrestamo);
              //  command.Parameters.AddWithValue("@monto_multas", prestamo.);

                OperacionesSQL.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                //Operaciones.WriteLogsRelease("PersonaDal", "Actualizar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
               // Operaciones.WriteLogsRelease("PersonaDal", "Actualizar", string.Format("{0} Error: {1}", DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

            //Operaciones.WriteLogsDebug("PersonaDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));


        }

        public static Prestamo ObtenerID()
        {
            Prestamo prestamo = new Prestamo();
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            string query = @"SELECT max(idPrestamo) as IdPrestamo FROM Prestamo";
            try
            {
                cmd = OperacionesSQL.CreateBasicCommand(query);
                dr = OperacionesSQL.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    prestamo = new Prestamo()
                    {
                        IdPrestamo = dr.GetInt32(0)
                    };
                }
            }
            catch (Exception ex)
            {
                //Operaciones.WriteLogsRelease("LibroDal", "Obtenet(Get)", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return prestamo;
        }
        /// <summary>
        /// Metodo para obtener  un empleado
        /// </summary>
        /// <param name="id">Identificado del empleado </param>
        /// <returns>Empleado</returns>
        public static Prestamo Obtener(int id)
        {
            Prestamo prestamo = new Prestamo();
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            string query = @"select * from Prestamo
                             where idPrestamo= @id";

            try
            {
                cmd = OperacionesSQL.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = OperacionesSQL.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    prestamo = new Prestamo()
                    {
                        IdPrestamo = dr.GetInt32(0),
                        FechaPrestamo = dr.GetDateTime(2),
                        FechaDevolucion = dr.GetDateTime(5),
                        Reserva = dr.GetInt32(4),
                        //Fecha_hora_reserva = dr.GetDateTime(4),
                        //Multas = dr.GetInt32(5),
                        //Monto_multas = dr.GetInt32(6),
                        IdUsuario = dr.GetInt16(1),
                        IdLibro = dr.GetInt32(3)

                    };

                }
            }
            catch (Exception ex)
            {
                //Operaciones.WriteLogsRelease("PersonaDal", "Obtenet(Get)", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return prestamo;
        }

        public DataTable SelectLikeRPDM(byte opcionLike, string texto)
        {
            DataTable res = new DataTable();
            string query = @"SELECT * FROM VwListaRPDM WHERE [Nombre completo] like @texto  ";

            switch (opcionLike)
            {
                case 0:
                    query = query + " AND Reserva =1 ";
                    break;
                case 1:
                    query = query + " AND Reserva =2";
                    break;
            }
            query = query + " order by 7 desc";
            try
            {
                SqlCommand cmd = OperacionesSQL.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
                res = OperacionesSQL.ExcecuteDataTableCommand(cmd);
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }
        public DataTable SelectLikeActualizarFecha(string texto)
        {
            DataTable res = new DataTable();
            string query = @" SELECT * FROM VwActualizarFecha WHERE Reserva=2 AND [Nombre completo] like @texto  ";

            try
            {
                SqlCommand cmd = OperacionesSQL.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
                res = OperacionesSQL.ExcecuteDataTableCommand(cmd);
            }
            catch (Exception)
            {
                throw;
            }
            return res;
        }


    }
}

