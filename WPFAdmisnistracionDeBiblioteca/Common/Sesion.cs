using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase que inicia las variables de Sesion de la tabla Usuario 
    /// </summary>
    public static class Sesion
    {
        public static short idSesion;
        public static string usuarioSesion;
        public static string rolSesion;
        public static byte estadoPassword;

        public static string Info()
        {
            return "Usuario: " + usuarioSesion + ", Rol: " + rolSesion;
        }
    }
}
