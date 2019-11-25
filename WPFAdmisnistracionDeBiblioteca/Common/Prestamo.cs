using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Prestamo
    {
        private int idPrestamo;

        public int IdPrestamo
        {
            get { return idPrestamo; }
            set { idPrestamo = value; }
        }

        private DateTime fechaPrestamo;

        public DateTime FechaPrestamo
        {
            get { return fechaPrestamo; }
            set { fechaPrestamo = value; }
        }

        private DateTime fechaDevolucion;

        public DateTime FechaDevolucion
        {
            get { return fechaDevolucion; }
            set { fechaDevolucion = value; }
        }


        private int cantidad;

        public int Catidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private int reserva;

        public int Reserva
        {
            get { return reserva; }
            set { reserva = value; }
        }


        /// <summary>
        /// Identificador de persona
        /// </summary>
        public Int16 IdUsuario { get; set; }

        /// <summary>
        /// Identificador de libro
        /// </summary>
        public int IdLibro { get; set; }




    }
}
