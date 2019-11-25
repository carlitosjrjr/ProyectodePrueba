using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Common;

namespace DAL
{
    public class ReservacionDAL : AbstractDAL
    {
        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Insert()
        {
            throw new NotImplementedException();
        }

        public override DataTable Select()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
        public static void Prestamo(Prestamo prestamo, Libros libro)
        {
            string query1 = "UPDATE  PRESTAMO SET catidad = (cantidad + 1),fechaPrestamo=@fechaPrestamo,fechaDevolucion=@fechaDevolucion where idPrestamo=@id";
            string query2 = "UPDATE  LIBRO where idLibro= @idLibro";
            List<SqlCommand> cmds = new List<SqlCommand>();

            try
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del Metodo de Insercion de Usuario", DateTime.Now));
                cmds = Methods.CreateNBasicCommand(2);

                SqlCommand cmd1 = cmds[0];
                SqlCommand cmd2 = cmds[1];

                cmd1.CommandText = query1;
                cmd2.CommandText = query2;

                cmd1.Parameters.AddWithValue("@id", prestamo.IdPrestamo);
                cmd1.Parameters.AddWithValue("@fechaPrestamo", prestamo.FechaPrestamo);
                cmd1.Parameters.AddWithValue("@fechaDevolucion", prestamo.FechaDevolucion);
                cmd1.Parameters.AddWithValue("@catidad", prestamo.Catidad);
                
               

                //short id = Methods.GetIDGenerateTable("Empleado");

                cmd2.Parameters.AddWithValue("@idLibro", libro.IdLibro);
                //cmd2.Parameters.AddWithValue("@nombreUsuario", libro.NombreUsuario);
             
                

                Methods.Execute2BasicCommand(cmd1, cmd2);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Prestamo de Libro, Nombre Titulo: {1}, Usuario: {2}", DateTime.Now, libro.Titulo, Sesion.usuarioSesion));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Error al Insertar Usuario:  {1} Usuario: {2}", DateTime.Now, ex.Message, Sesion.usuarioSesion));
                throw ex;
            }
        }

        public static void Insertar(Prestamo Reserva)
        {
           // Operaciones.WriteLogsDebug("PersonaDal", "Insertar", string.Format("{0} Info: {1}",
           // DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para crear un persona"));

            SqlCommand command = null;

            //Consulta para insertar persona
            string queryString = @"INSERT INTO Prestamo (IdPrestamo,Fecha_prestamo,Fecha_devolucion, Reserva,Fecha_hora_reserva, Multas,Monto_multas,IdPersona,IdLibro)
                                     VALUES(@IdPrestamo,@Fecha_prestamo,@Fecha_devolucion, @Reserva,CURRENT_TIMESTAMP, @Multas,@Monto_multas,@IdPersona,@IdLibro)";
            //Declaro e inicio la conexion
            SqlConnection conexion = OperacionesSQL.ObtenerConexion();

            //Declaro la transaccion
            SqlTransaction transaccion = null;
            try
            {
                //Abro la conexion a la base de datos
                conexion.Open();

                //Inicio la transaccion
                transaccion = conexion.BeginTransaction();

                command = OperacionesSQL.CreateBasicCommandWithTransaction(queryString, transaccion, conexion);

                command.Parameters.AddWithValue("@IdPrestamo", Reserva.IdPrestamo);
                command.Parameters.AddWithValue("@Reserva", Reserva.Reserva);
                command.Parameters.AddWithValue("@Fecha_prestamo", "2019-07-09");
                command.Parameters.AddWithValue("@Fecha_devolucion", "2019-07-09");
               /// command.Parameters.AddWithValue("@Multas", Reserva.Multas);
               // command.Parameters.AddWithValue("@Monto_multas", Reserva.Monto_multas);
               // command.Parameters.AddWithValue("@IdPersona", Reserva.IdPersona);
                command.Parameters.AddWithValue("@IdLibro", Reserva.IdLibro);


                OperacionesSQL.ExecuteBasicCommandWithTransaction(command);



                transaccion.Commit();

            }
            catch (SqlException ex)
            {
                //Operaciones.WriteLogsRelease("PersonaDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
               // Operaciones.WriteLogsRelease("PersonaDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
           // Operaciones.WriteLogsDebug("PersonaDal", "Insertar", string.Format("{0} {1} Info: {2}",
               // DateTime.Now.ToString(), DateTime.Now.ToString(),
                //"Termino de ejecutar  el metodo acceso a datos para insertar persona"));
        }

        public static void Eliminar(int idReserva)
        {
           // Operaciones.WriteLogsDebug("LibroDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Usuario"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Prestamo SET Reserva=0
                                     WHERE IdPrestamo=@idPrestamo";
            try
            {
                command = OperacionesSQL.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@idPrestamo", idReserva);
                OperacionesSQL.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                //Operaciones.WriteLogsRelease("LibroDal", "Eliminar", string.Format("{0} {1} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                //Operaciones.WriteLogsRelease("LibroDal", "Eliminar", string.Format("{0} {1} Error: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            //Operaciones.WriteLogsDebug("LibroDal", "Eliminar", string.Format("{0} {1} Info: {1}", DateTime.Now.ToString(), DateTime.Now.ToString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));
        }

        public DataTable Contar(int id)
        {
            DataTable dt = new DataTable();
            string query = "SELECT COUNT (reserva) FROM Prestamo WHERE idUsuario=@id AND reserva=1";
            try
            {
                SqlCommand cmd = OperacionesSQL.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dt = OperacionesSQL.ExcecuteDataTableCommand(cmd);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al insertar el cliente" + err);
                throw err;
            }
            return dt;
        }

        public DataTable SelectReservaLibro(int id)
        {
            DataTable res = new DataTable();
            string query = @"  SELECT * FROM VwReserbaPersona WHERE [Id Persona]=@id ORDER BY 5";
            try
            {
                SqlCommand cmd = OperacionesSQL.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
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
    

