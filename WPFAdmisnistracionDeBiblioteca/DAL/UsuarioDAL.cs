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
    /// <summary>
    /// Lógica de interacción con la Base de Datos tabla Usuario-Persona
    /// </summary>
    public  class UsuarioDAL : AbstractDAL
    {

        #region atributos, propiedades y Constructores
        private Usuario user;

        public Usuario User
        {
            get { return user; }
            set { user = value; }
        }

        private Empleado emplead;

        public Empleado Emplead
        {
            get { return emplead; }
            set { emplead = value; }
        }


        public UsuarioDAL()
        {

        }
        public UsuarioDAL(Usuario user)
        {
            this.user = user;
        }

        public UsuarioDAL(Empleado emplead, Usuario user)
        {
            this.emplead = emplead;
            this.user = user;

        }
        #endregion


        public string RequestPassword(string requestcorreo)
        {
            using (var connection = Methods.GetConnection())
            {
                connection.Open();
               using (var command = new SqlCommand())

                {
                    using (var command1 = new SqlCommand())
                    {


                        //command = Methods.CreateNBasicCommand(2);
                        command.Connection = connection;
                        command1.Connection = connection;
                        command.CommandText = "SELECT idUsuario,nombreUsuario,password,rol,estado,correo FROM Usuario WHERE  correo=@correo";
                        command1.CommandText = "update Usuario  set password = HASHBYTES('md5',@password)";
                        command.Parameters.AddWithValue("@correo", requestcorreo);
                        command1.Parameters.AddWithValue("@password", "fer250").SqlDbType = SqlDbType.VarChar; 
                        command.CommandType = CommandType.Text;

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read() == true)
                        {
                            string username = reader.GetString(1);
                            var pass = reader.GetSqlBinary(2).ToString()+" "+ "su nueva contrasena es : pepe123";
                            string correo = reader.GetString(5);

                            Email.EmailSoporteDAL mail = new Email.EmailSoporteDAL();
                            //List<string>
                            mail.enviarCorreo(cabeza: "solicitud de recuperacion de contraasena",
                                              body: "hola" + username + "solicitaes recuperar contrasena" + "tu contrasena es " +
                                              pass, corrreo: new List<string> { correo });


                            return "hola" + username + "solicitaes recuperar contrasena" +
                                    "porfavor revise su correo electronico" + correo;

                        }
                        else
                        {
                            return "disculpa pero no esta registrado";
                        }
                    }
                }

            }
               
                

                //return "";
                    //dt = Methods.ExecuteDataTableCommand(cmd);
                 
           
            //return dt;
            //return res;

        }

        #region Metodos Clase
        /// <summary>
        /// Metodo que ejecuta una consulta INSERT en la tabla Empleado-Usuario
        /// </summary>
        public override void Insert()
        {

            string query1 = "INSERT INTO Empleado (nombres,primerApellido,segundoApellido,ci,sexo,fechaIngreso,telefono,tipoEmpleado,latitud,longitud,fechaNacimiento,idUsuario) VALUES (@nombres,@primerApellido,@segundoApellido,@ci,@sexo,@fechaIngreso,@telefono,@tipoEmpleado,@latitud,@longitud,@fechaNacimiento,@idUsuario)";
            string query2 = "INSERT INTO Usuario (idUsuario,nombreUsuario,password,correo,rol) VALUES (@idUsuario,@nombreUsuario,HASHBYTES('md5',@password),@correo,@rol)";
            List<SqlCommand> cmds = new List<SqlCommand>();

            try
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del Metodo de Insercion de Usuario", DateTime.Now));
                cmds = Methods.CreateNBasicCommand(2);

                SqlCommand cmd1 = cmds[0];
                SqlCommand cmd2 = cmds[1];

                cmd1.CommandText = query1;
                cmd2.CommandText = query2;

                cmd1.Parameters.AddWithValue("@nombres", emplead.Nombres);
                cmd1.Parameters.AddWithValue("@primerApellido", emplead.PrimerApellido);
                cmd1.Parameters.AddWithValue("@segundoApellido", emplead.SegundoApellido);
                cmd1.Parameters.AddWithValue("@ci", emplead.Ci);
                cmd1.Parameters.AddWithValue("@sexo", emplead.Sexo);
                cmd1.Parameters.AddWithValue("@fechaIngreso", emplead.FechaIngreso);
                cmd1.Parameters.AddWithValue("@telefono", emplead.Telefono);
                cmd1.Parameters.AddWithValue("@tipoEmpleado", emplead.TipoEmpleado);
                cmd1.Parameters.AddWithValue("@latitud", emplead.Latitud);
                cmd1.Parameters.AddWithValue("@longitud", emplead.Longitud);
                cmd1.Parameters.AddWithValue("@fechaNacimiento", emplead.FechaNacimiento);
                cmd1.Parameters.AddWithValue("@idUsuario", Sesion.idSesion);

                short id = Methods.GetIDGenerateTable("Empleado");

                cmd2.Parameters.AddWithValue("@idUsuario", id);
                cmd2.Parameters.AddWithValue("@nombreUsuario", user.NombreUsuario);
                cmd2.Parameters.AddWithValue("@password", user.Password).SqlDbType = SqlDbType.VarChar;
                cmd2.Parameters.AddWithValue("@correo", user.Correo);
                cmd2.Parameters.AddWithValue("@rol", user.Rol);


                Methods.Execute2BasicCommand(cmd1, cmd2);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro de Usuario insertado, Nombre Empleado: {1}, Usuario: {2}", DateTime.Now, emplead.Nombres + " " + emplead.PrimerApellido, Sesion.usuarioSesion));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Error al Insertar Usuario:  {1} Usuario: {2}", DateTime.Now, ex.Message, Sesion.usuarioSesion));
                throw ex;
            }
        }
        /// <summary>
        /// Metodo que ejecuta una consulta UPDATE en la tabla Usuario para Restablecer Contraseña
        /// </summary>
        public void RestablecerContraseña()
        {
            string query = "UPDATE Usuario set password = HASHBYTES('md5',@password),estadoPassword = 0 WHERE idUsuario = @idUsuario";
            try
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del Metodo de Restablecer Contraseña de Empleado Usuario", DateTime.Now));
                SqlCommand cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@password", user.Password).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@idUsuario", user.IdUsuario);
                Methods.ExecuteBasicCommand(cmd);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Contraseña Restablecida, Nombre Empleado: {1}, Usuario: {2}", DateTime.Now, user.GetFullName(), Sesion.usuarioSesion));
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Error al Restablecer Contraseña:  {1} Usuario: {2}", DateTime.Now, ex.Message, Sesion.usuarioSesion));
            }
        }
        /// <summary>
        /// Metodo que ejecuta una consulta UPDATE en la tabla Usuario para cambiar contraseña
        /// </summary>
        public void CambiarContraseña()
        {
            string query = "UPDATE Usuario set password = HASHBYTES('md5',@password),estadoPassword = 1 WHERE idUsuario = @idUsuario";
            try
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del Metodo de Cambiar Contraseña de Empleado Usuario", DateTime.Now));
                SqlCommand cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@password", user.Password).SqlDbType = SqlDbType.VarChar; ;
                cmd.Parameters.AddWithValue("@idUsuario", user.IdUsuario);

                Methods.ExecuteBasicCommand(cmd);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Contraseña Cambiada, Nombre Empleado: {1}, Usuario: {2}", DateTime.Now, user.GetFullName(), Sesion.usuarioSesion));
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Error al Cambiar Contraseña:  {1} Usuario: {2}", DateTime.Now, ex.Message, Sesion.usuarioSesion));
            }
        }
        /// <summary>
        /// Metodo que ejecuta una consulta UPDATE en la tabla Empleado para modificar los campos 
        /// </summary>
        public override void Update()
        {
            string query = "UPDATE Empleado SET nombres=@nombres, primerApellido=@primerApellido,segundoApellido=@segundoApellido,ci=@ci,sexo=@sexo,telefono=@telefono,latitud=@latitud,longitud=@longitud,foto=1,fUpdate=CURRENT_TIMESTAMP,idUsuario=@idUsuario WHERE tipoEmpleado = 1 AND idEmpleado = @idEmpleado";
            try
            {

                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del Metodo de Modificacion de Empleado Usuario", DateTime.Now));
                SqlCommand cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nombres", user.Nombres);
                cmd.Parameters.AddWithValue("@primerApellido", user.PrimerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", user.SegundoApellido);
                cmd.Parameters.AddWithValue("@ci", user.Ci);
                cmd.Parameters.AddWithValue("@sexo", user.Sexo);

                cmd.Parameters.AddWithValue("@telefono", user.Telefono);
                cmd.Parameters.AddWithValue("@latitud", user.Latitud);
                cmd.Parameters.AddWithValue("@longitud", user.Longitud);
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idSesion);
                cmd.Parameters.AddWithValue("@idEmpleado", user.IdUsuario);


                Methods.ExecuteBasicCommand(cmd);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Modificado, Nombre Empleado: {1}, Usuario: {2}", DateTime.Now, user.GetFullName(), Sesion.usuarioSesion));
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Error al Modificar Empleado Usuario:  {1} Usuario: {2}", DateTime.Now, ex.Message, Sesion.usuarioSesion));
            }
        }
        /// <summary>
        /// Metodo que ejecuta una consulta de eliminacion logica en la tabla Usuario
        /// </summary>
        public override void Delete()
        {
            string query = "UPDATE Usuario set estado=0  WHERE idUsuario = @idUsuario";
            try
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del Metodo de Eliminacion Logica de Usuario", DateTime.Now));
                SqlCommand cmd = Methods.CreateBasicCommand(query);

                cmd.Parameters.AddWithValue("@idUsuario", user.IdUsuario);
                Methods.ExecuteBasicCommand(cmd);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Elminado Logicamente, Nombre Empleado: {1}, Usuario: {2}", DateTime.Now, emplead.GetFullName(), Sesion.usuarioSesion));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Error al Eliminar Logicamente Empleado:  {1} Usuario: {2}", DateTime.Now, ex.Message, Sesion.usuarioSesion));
                //throw ex;
            }
        }
        /// <summary>
        /// Metodo que ejecuta una consulta SELECT en una vwUsuarioSelect que retorna un DataTable
        /// </summary>
        /// <returns></returns>
        public override DataTable Select()
        {
            DataTable res = new DataTable();
            string query = "SELECT * FROM vwUsuarioSelect ORDER BY 2";
            try
            {
                SqlCommand cmd = Methods.CreateBasicCommand(query);
                res = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }
        /// <summary>
        /// Metodo que ejecuta una consulta SELECT por nombre completo de Usuario, retorna un DataTable
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public DataTable SelectFullNameUsuario(string texto)
        {
            DataTable res = new DataTable();
            string query = "SELECT * FROM vwSelectNombreEmpleadoUsuario WHERE [Nombre Completo] LIKE @texto";
            try
            {
                SqlCommand cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
                res = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }

        /// <summary>
        /// Metodo que ejecuta una consulta SELECT en Empleado y Usuario y retorna un Objeto Usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public Usuario Get(short idUsuario)
        {
            Usuario res = null;
            SqlCommand cmd = null;
            SqlDataReader dataReader = null;
            string query = "SELECT U.idUsuario,E.nombres,E.primerApellido,E.segundoApellido,E.ci,E.sexo,E.fechaIngreso,E.telefono,E.tipoEmpleado,E.latitud,E.longitud,E.foto,E.estado,E.fUpdate,E.idUsuario,U.nombreUsuario,U.password,U.rol,U.estado, FROM Usuario U INNER JOIN Empleado E ON E.idEmpleado = U.idUsuario WHERE U.idUsuario=@id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                dataReader = Methods.ExecuteDataReaderCommand(cmd);
                while (dataReader.Read())
                {
                    res = new Usuario(short.Parse(dataReader[0].ToString()), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString(), DateTime.Parse(dataReader[6].ToString()), dataReader[7].ToString(), byte.Parse(dataReader[8].ToString()), double.Parse(dataReader[9].ToString()), double.Parse(dataReader[10].ToString()), byte.Parse(dataReader[11].ToString()), byte.Parse(dataReader[12].ToString()), DateTime.Parse(dataReader[13].ToString()), short.Parse(dataReader[14].ToString()), dataReader[15].ToString(), dataReader[16].ToString(), dataReader[17].ToString(), byte.Parse(dataReader[18].ToString()), byte.Parse(dataReader[19].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
                dataReader.Close();
            }
            return res;
        }

        /// <summary>
        /// Metodo que se utiliza para Iniciar Sesion en el programa
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DataTable Login(string usuario, string password)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = null;

            string query = "SELECT idUsuario,nombreUsuario,rol FROM Usuario WHERE estado = 1 and nombreUsuario = @nombreUsuario AND password = HASHBYTES('MD5',@password)";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario);
                cmd.Parameters.AddWithValue("@password", password).SqlDbType = SqlDbType.VarChar;
                dt = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return dt;
            //return res;
        }
        #endregion
    }
}
