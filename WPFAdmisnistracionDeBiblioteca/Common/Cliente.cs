using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase Cliente que tiene atributos y propiedades y constructor de la misma para crear objetos que contengan los parametros para enviarlos en las consultas
    /// </summary>
    public class Cliente
    {
        private int idCliente;

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        private string nombreCliente;

        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }

        /// <summary>
        /// constructor con todos los parametros
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="nombreCliente"></param>
        public Cliente(int idCliente, string nombreCliente)
        {
            this.idCliente = idCliente;
            this.nombreCliente = nombreCliente;
        }
        /// <summary>
        /// Constructor para el insert
        /// </summary>
        /// <param name="nombreCliente"></param>
        public Cliente(string nombreCliente)
        {
            this.nombreCliente = nombreCliente;
        }

    }
}
