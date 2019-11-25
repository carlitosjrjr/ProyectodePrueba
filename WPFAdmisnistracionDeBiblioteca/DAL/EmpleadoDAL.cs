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
    /// Lógica de interacción con la Base de Datos tabla Empleado
    /// </summary>
    public class EmpleadoDAL : AbstractDAL
    {
        #region atributos, propiedades y constructores
        private Empleado emplead;

        public Empleado Emplead
        {
            get { return emplead; }
            set { emplead = value; }
        }

        private Usuario user;

        public Usuario User
        {
            get { return user; }
            set { user = value; }
        }


        public EmpleadoDAL(Empleado emplead)
        {
            this.emplead = emplead;
        }

        public EmpleadoDAL(Empleado emplead, Usuario user)
        {
            this.emplead = emplead;
            this.user = user;
        }

        public EmpleadoDAL()
        {

        }
        #endregion

        /// <summary>
        /// metodo que ejecuta una consulta INSERT en la tabla Empleado
        /// </summary>
        public override void Insert()
        {
            string query = "INSERT INTO Empleado (nombres,primerApellido,segundoApellido,ci,sexo,fechaIngreso,telefono,tipoEmpleado,latitud,longitud,fechaNacimiento,idUsuario) VALUES (@nombres,@primerApellido,@segundoApellido,@ci,@sexo,@fechaIngreso,@telefono,@tipoEmpleado,@latitud,@longitud,@fechaNacimiento,@idUsuario)";
            try
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del Metodo de Insercion de Empleado", DateTime.Now));
                SqlCommand cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nombres", emplead.Nombres);
                cmd.Parameters.AddWithValue("@primerApellido", emplead.PrimerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", emplead.SegundoApellido);
                cmd.Parameters.AddWithValue("@ci", emplead.Ci);
                cmd.Parameters.AddWithValue("@sexo", emplead.Sexo);
                cmd.Parameters.AddWithValue("@fechaIngreso", emplead.FechaIngreso);
                cmd.Parameters.AddWithValue("@telefono", emplead.Telefono);
                cmd.Parameters.AddWithValue("@tipoEmpleado", emplead.TipoEmpleado);
                cmd.Parameters.AddWithValue("@latitud", emplead.Latitud);
                cmd.Parameters.AddWithValue("@longitud", emplead.Longitud);
                cmd.Parameters.AddWithValue("@fechaNacimiento", emplead.FechaNacimiento);
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idSesion);
                Methods.ExecuteBasicCommand(cmd);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro insertado, Nombre Empleado: {1}, Usuario: {2}", DateTime.Now, emplead.Nombres + " " + emplead.PrimerApellido, Sesion.usuarioSesion));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Error al Insertar Empleado:  {1} Usuario: {2}", DateTime.Now, ex.Message, Sesion.usuarioSesion));

            }
        }
        /// <summary>
        /// Metodo que ejecuta una consulta UPDATE en la tabla Empleado
        /// </summary>
        public override void Update()
        {
            string query = "UPDATE Empleado SET nombres=@nombres, primerApellido=@primerApellido,segundoApellido=@segundoApellido,ci=@ci,sexo=@sexo,telefono=@telefono,latitud=@latitud,longitud=@longitud,foto=1,fUpdate=CURRENT_TIMESTAMP,idUsuario=@idUsuario WHERE tipoEmpleado = 0 AND idEmpleado = @idEmpleado";
            try
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del Metodo de Modificacion de Empleado", DateTime.Now));
                SqlCommand cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@nombres", emplead.Nombres);
                cmd.Parameters.AddWithValue("@primerApellido", emplead.PrimerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", emplead.SegundoApellido);
                cmd.Parameters.AddWithValue("@ci", emplead.Ci);
                cmd.Parameters.AddWithValue("@sexo", emplead.Sexo);

                cmd.Parameters.AddWithValue("@telefono", emplead.Telefono);
                cmd.Parameters.AddWithValue("@latitud", emplead.Latitud);
                cmd.Parameters.AddWithValue("@longitud", emplead.Longitud);
                cmd.Parameters.AddWithValue("@idUsuario", Sesion.idSesion);
                cmd.Parameters.AddWithValue("@idEmpleado", emplead.IdEmpleado);


                Methods.ExecuteBasicCommand(cmd);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Modificado, Nombre Empleado: {1}, Usuario: {2}", DateTime.Now, emplead.GetFullName(), Sesion.usuarioSesion));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Error al Modificar Empleado:  {1} Usuario: {2}", DateTime.Now, ex.Message, Sesion.usuarioSesion));
                //throw ex;
            }
        }
        /// <summary>
        /// Metodo que ejecuta una consulta UPDATE "Eliminacion Logica" en la tabla Empleado
        /// </summary>
        public override void Delete()
        {
            string query = "UPDATE Empleado set estado=0,fUpdate =CURRENT_TIMESTAMP  WHERE idEmpleado = @idEmpleado";
            try
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del Metodo de Eliminacion Logica de Empleado", DateTime.Now));
                SqlCommand cmd = Methods.CreateBasicCommand(query);

                cmd.Parameters.AddWithValue("@idEmpleado", emplead.IdEmpleado);
                Methods.ExecuteBasicCommand(cmd);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro Elminado Logicamente, Nombre Empleado: {1}, Usuario: {2}", DateTime.Now, emplead.GetFullName(), Sesion.usuarioSesion));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Error al Eliminar Empleado:  {1} Usuario: {2}", DateTime.Now, ex.Message, Sesion.usuarioSesion));
                throw ex;
            }
        }

        public override DataTable Select()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Metodo que realiza una consulta SELECT retornando un DataTable, usando como parametro un string para realizar busqueda por nombre completo
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public DataTable SelectFullName(string texto)
        {
            DataTable res = new DataTable();
            string query = "SELECT * FROM vwSelectNombreEmpleado WHERE [Nombre Completo] LIKE @texto AND tipoEmpleado = 0";
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
        /// Metodo que ejecuta una consulta SELECT para recuperar los datos y cargarlos a un Objeto Empleado
        /// </summary>
        /// <param name="idEmpleado"></param>
        /// <returns></returns>
        public Empleado Get(short idEmpleado)
        {
            Empleado res = null;
            SqlCommand cmd = null;
            SqlDataReader dataReader = null;
            string query = "SELECT idEmpleado,nombres,primerApellido,segundoApellido,ci,sexo,fechaIngreso,telefono,tipoEmpleado,latitud,longitud,foto,estado,fUpdate,idUsuario FROM Empleado WHERE tipoEmpleado = 0 AND idEmpleado = @id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", idEmpleado);
                dataReader = Methods.ExecuteDataReaderCommand(cmd);

                while (dataReader.Read())
                {
                    res = new Empleado(short.Parse(dataReader[0].ToString()), dataReader[1].ToString(), dataReader[2].ToString(), dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString(), DateTime.Parse(dataReader[6].ToString()), dataReader[7].ToString(), byte.Parse(dataReader[8].ToString()), double.Parse(dataReader[9].ToString()), double.Parse(dataReader[10].ToString()), byte.Parse(dataReader[11].ToString()), byte.Parse(dataReader[12].ToString()), DateTime.Parse(dataReader[13].ToString()), short.Parse(dataReader[14].ToString()));
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

    }
}
