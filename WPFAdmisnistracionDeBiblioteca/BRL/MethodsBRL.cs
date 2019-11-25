using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRL
{
    /// <summary>
    /// Lógica de interacción con la Clase Methods
    /// </summary>
    public class MethodsBRL
    {
        /// <summary>
        /// Metodo que devuelve el maximo id de una Tabla, utilizado para guardar las imagenes por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public static short GetMaxIDTable(string id, string tabla)
        {
            return Methods.GetMaxIDTable(id, tabla);
        }

        public static int GetMaxIDTableInt(string id, string tabla)
        {
            return Methods.GetMaxIDTableInt(id, tabla);
        }
    }
}
