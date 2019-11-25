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
    /// Lógica de interacción con la Base de Datos tabla CONFIG Basicamente carga las configuraciones donde se maneja las Fotografias
    /// </summary>
    public sealed class ConfigDAL
    {
        /// <summary>
        /// Metodo que ejecuta una consulta SELECT en la Base de Datos tabla config
        /// </summary>
        /// <returns></returns>
        public DataTable Select()
        {
            DataTable res = new DataTable();
            string query = "SELECT pathFotoEmpleado,pathFotoUsuario FROM Config ";
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

    }
}
