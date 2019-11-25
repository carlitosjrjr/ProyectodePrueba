using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    /// <summary>
    /// Lógica de interacción con la Clase UsuarioDAL
    /// </summary>
    public class UsuarioBRL : AbstractBRL
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

        private UsuarioDAL userDal;

        public UsuarioDAL UserDal
        {
            get { return userDal; }
            set { userDal = value; }
        }
        public UsuarioBRL()
        {

        }
        public UsuarioBRL(Usuario user)
        {
            this.user = user;
            userDal = new UsuarioDAL(user);
        }

        public UsuarioBRL(Empleado emplead, Usuario user)
        {
            this.emplead = emplead;
            this.user = user;

            userDal = new UsuarioDAL(emplead, user);
        }
        #endregion




        #region Metodos de la Clase
        /// <summary>
        /// Metodo que realiza una llamada al metodo INSERT de la clase UsuarioDAL
        /// </summary>
        public override void Insert()
        {
            userDal.Insert();
        }
        /// <summary>
        /// Metodo que realiza una llamada al metodo UPDATE de la clase UsuarioDAL
        /// </summary>
        public override void Update()
        {
            userDal.Update();
        }
        /// <summary>
        /// Metodo que realiza una llamada al metodo DELETE Logico de la clase UsuarioDAL
        /// </summary>
        public override void Delete()
        {
            userDal.Delete();
        }
        /// <summary>
        /// Metodo que realiza una llamada al metodo SELECT de la clase UsuarioDAL
        /// </summary>
        /// <returns></returns>
        public override DataTable Select()
        {
            userDal = new UsuarioDAL();
            return userDal.Select();
        }
        /// <summary>
        /// Metodo que realiza una llamada al metodo LOGIN de la clase UsuarioDAl para iniciar una sesion
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DataTable Login(string usuario, string password)
        {
            userDal = new UsuarioDAL();
            return userDal.Login(usuario, password);
        }
        /// <summary>
        /// Metodo que realiza una llamada al metodo GET de la clase UsuarioDAL retorna un objeto Usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public Usuario Get(short idUsuario)
        {
            userDal = new UsuarioDAL();
            return userDal.Get(idUsuario);
        }
        /// <summary>
        /// Metodo que realiza una llamada al metodo SelectFullNameUsuario de la clase UsuarioDAL como parametro un string
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public DataTable SelectFullNameUsuario(string texto)
        {
            userDal = new UsuarioDAL();
            return userDal.SelectFullNameUsuario(texto);
        }
        /// <summary>
        /// Metodo que realiza una llamada al metodo Restablecer Contraseña de la clase UsuarioDAL
        /// </summary>
        public void RestablecerContraseña()
        {
            userDal.RestablecerContraseña();
        }
        /// <summary>
        /// Metodo que realiza una llamada al metodo Cambiar Contraseña de la clase UsuarioDAL
        /// </summary>
        public void CambiarContraseña()
        {
            userDal.CambiarContraseña();
        }

        #endregion
    }
}
