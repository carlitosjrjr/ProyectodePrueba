using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Usuario:Empleado
    {
        #region Atributos y propiedades
        private short idUsuario;

        public short IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }


        private string nombreUsuario;

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string rol;

        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        private byte estadoUsuario;

        public byte EstadoUsuario
        {
            get { return estadoUsuario; }
            set { estadoUsuario = value; }
        }

        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }




        private byte estadoPassword;

        public byte EstadoPassword
        {
            get { return estadoPassword; }
            set { estadoPassword = value; }
        }



        #endregion

        #region Constructores

        public Usuario()
        {

        }

        /// <summary>
        /// Constructor que contiene todos los campos de la Tabla Usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="nombreUsuario"></param>
        /// <param name="password"></param>
        /// <param name="rol"></param>
        /// <param name="estado"></param>
        /// <param name="estadoPassword"></param>
        public Usuario(short idUsuario, string nombreUsuario, string password, string rol, byte estado, byte estadoPassword)
        {
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.password = password;
            this.rol = rol;
            this.estadoUsuario = estado;
            this.estadoPassword = estadoPassword;
        }

        /// <summary>
        /// Constructor para realizar el Insert
        /// </summary>
        public Usuario(string nombreUsuario, string password,string correo, string rol)
        {


            this.nombreUsuario = nombreUsuario;
            this.password = password;
            this.correo = correo;
            this.rol = rol;

        }
        /// <summary>
        /// Constructor para realizar el GET Empleado-Usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="nombres"></param>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <param name="ci"></param>
        /// <param name="sexo"></param>
        /// <param name="fechaIngreso"></param>
        /// <param name="telefono"></param>
        /// <param name="tipoEmpleado"></param>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <param name="foto"></param>
        /// <param name="estadoEmpleado"></param>
        /// <param name="fUpdate"></param>
        /// <param name="idUsuarioControl"></param>
        /// <param name="nombreUsuario"></param>
        /// <param name="password"></param>
        /// <param name="rol"></param>
        /// <param name="estadoUsuario"></param>
        /// <param name="estadoPassword"></param>
        public Usuario(short idUsuario, string nombres, string primerApellido, string segundoApellido, string ci, string sexo, DateTime fechaIngreso, string telefono, byte tipoEmpleado, double latitud, double longitud, byte foto, byte estadoEmpleado, DateTime fUpdate, short idUsuarioControl, string nombreUsuario, string password, string rol, byte estadoUsuario, byte estadoPassword)
            : base(idUsuario, nombres, primerApellido, segundoApellido, ci, sexo, fechaIngreso, telefono, tipoEmpleado, latitud, longitud, foto, estadoEmpleado, fUpdate, idUsuarioControl)
        {
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.password = password;
            this.rol = rol;
            this.estadoUsuario = estadoUsuario;
            this.estadoPassword = estadoPassword;

        }


        #endregion
    }
}
