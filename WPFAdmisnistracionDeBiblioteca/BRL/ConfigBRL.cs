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
    /// Lógica de interacción con la Clase DALConfig 
    /// </summary>
    public sealed class ConfigBRL
    {
        private ConfigDAL dal;

        public ConfigDAL Dal
        {
            get { return dal; }
            set { dal = value; }
        }

        /// <summary>
        /// Metodo que realiza una llamada al metodo SELECT de la Clase DALConfig
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            dal = new ConfigDAL();
            return dal.Select();
        }
    }
}
