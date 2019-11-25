using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Empleado
    {
        #region Atributos y Propiedades

        private short idEmpleado;

        public short IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }





        private string nombres;

        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }


        private string primerApellido;

        public string PrimerApellido
        {
            get { return primerApellido; }
            set { primerApellido = value; }
        }

        private string segundoApellido;

        public string SegundoApellido
        {
            get { return segundoApellido; }
            set { segundoApellido = value; }
        }

        private string ci;

        public string Ci
        {
            get { return ci; }
            set { ci = value; }
        }

        private string sexo;

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }


        private DateTime fechaIngreso;

        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }


        private byte tipoEmpleado;

        public byte TipoEmpleado
        {
            get { return tipoEmpleado; }
            set { tipoEmpleado = value; }
        }
        private double latitud;

        public double Latitud
        {
            get { return latitud; }
            set { latitud = value; }
        }


        private double longitud;

        public double Longitud
        {
            get { return longitud; }
            set { longitud = value; }
        }
        private byte foto;

        public byte Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        private byte estado;

        public byte Estado
        {
            get { return estado; }
            set { estado = value; }
        }


        private DateTime fUpdate;

        public DateTime FUpdate
        {
            get { return fUpdate; }
            set { fUpdate = value; }
        }


        private DateTime fechaNacimiento;

        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }



        private short idUsuario;

        public short IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }



        #endregion

        #region Constructores

        public Empleado()
        {

        }
        /// <summary>
        /// Constructor que tiene todos los campos de la Tabla Empleado
        /// </summary>
        /// <param name="idEmpleado"></param>
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
        /// <param name="estado"></param>
        /// <param name="fUpdate"></param>
        /// <param name="idUsuario"></param>
        public Empleado(short idEmpleado, string nombres, string primerApellido, string segundoApellido, string ci, string sexo, DateTime fechaIngreso, string telefono, byte tipoEmpleado, double latitud, double longitud, byte foto, byte estado, DateTime fUpdate, short idUsuario)
        {
            this.idEmpleado = idEmpleado;
            this.nombres = nombres;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.ci = ci;
            this.sexo = sexo;
            this.fechaIngreso = fechaIngreso;
            this.telefono = telefono;
            this.tipoEmpleado = tipoEmpleado;
            this.latitud = latitud;
            this.longitud = longitud;
            this.foto = foto;
            this.estado = estado;
            this.fUpdate = fUpdate;
            this.idUsuario = idUsuario;
        }

        /// <summary>
        /// CONSTRUCTOR PARA EL INSERT
        /// </summary>
        /// <param name="nombres"></param>
        /// <param name="primerApellido"></param>
        /// <param name="segundoApellido"></param>
        /// <param name="ci"></param>
        /// <param name="sexo"></param>
        /// <param name="fechaIngreso"></param>
        /// <param name="telefono"></param>
        /// <param name="tipoEmpleado"></param>
        /// <param name="idUsuario"></param>
        public Empleado(string nombres, string primerApellido, string segundoApellido, string ci, string sexo, DateTime fechaIngreso, string telefono, byte tipoEmpleado, double latitud, double longitud,DateTime fechaNacimiento ,short idUsuario)
        {
            this.nombres = nombres;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
            this.ci = ci;
            this.sexo = sexo;
            this.fechaIngreso = fechaIngreso;
            this.telefono = telefono;
            this.tipoEmpleado = tipoEmpleado;
            this.latitud = latitud;
            this.longitud = longitud;
            this.fechaNacimiento = fechaNacimiento;
            this.idUsuario = idUsuario;
        }

        public string GetFullName()
        {
            return Nombres + " " + PrimerApellido + " " + SegundoApellido;
        }

        #endregion 
    }
}
