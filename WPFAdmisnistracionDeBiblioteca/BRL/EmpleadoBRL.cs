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
    /// Lógica de interacción con la Clase DAL Tabla Empleado
    /// </summary>
    public class EmpleadoBRL : AbstractBRL
    {

        #region Atributos, Propiedades y Contructores de esta CLASE

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

        private EmpleadoDAL dalEmpleado;

        public EmpleadoDAL DalEmpleado
        {
            get { return dalEmpleado; }
            set { dalEmpleado = value; }
        }
        public EmpleadoBRL()
        {

        }
        public EmpleadoBRL(Empleado emplead)
        {
            this.emplead = emplead;
            dalEmpleado = new EmpleadoDAL(emplead);
        }
        public EmpleadoBRL(Empleado emplead, Usuario user)
        {
            this.emplead = emplead;
            this.user = user;
            dalEmpleado = new EmpleadoDAL(emplead, user);
        }


        #endregion

        #region Metodos de la Clase
        /// <summary>
        /// Metodo que realiza una llamada al metodo INSERT de la clase EmpleadoDAL
        /// </summary>
        public override void Insert()
        {
            dalEmpleado.Insert();
        }
        /// <summary>
        /// Metodo que realiza una llamada al metodo UPDATE de la clase EmpleadoDAL
        /// </summary>
        public override void Update()
        {
            dalEmpleado.Update();
        }
        /// <summary>
        /// Metodo que realiza una llamada al metodo DELETE Logico de la clase EmpleadoDAL
        /// </summary>
        public override void Delete()
        {
            dalEmpleado.Delete();
        }

        public override DataTable Select()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Metodo que realiza una llamada el metodo SelectFullName de la clase EmpleadoDAl para realizar busqueda de empleado
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public DataTable SelectFullName(string texto)
        {
            dalEmpleado = new EmpleadoDAL();
            return dalEmpleado.SelectFullName(texto);
        }
        /// <summary>
        /// Metodo que realiza una llamada al metodo get de la clase EmpleadoDAL para recuperar un objeto
        /// </summary>
        /// <param name="idEmpleado"></param>
        /// <returns></returns>
        public Empleado Get(short idEmpleado)
        {
            dalEmpleado = new EmpleadoDAL();
            return dalEmpleado.Get(idEmpleado);
        }
        #endregion

    }
}
