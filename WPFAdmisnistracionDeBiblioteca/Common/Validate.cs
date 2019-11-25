using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Clase que contiene metodos de validacion para los distintos campos
    /// </summary>
    public class Validate
    {
        /// <summary>
        /// Metodo que solo permite letras y un espacio
        /// </summary>
        /// <param name="cad"></param>
        /// <returns></returns>
        public static string OnlyLettersAndSpaces(string cad)
        {
            string res = " ";
            cad = cad.Trim();
            for (int i = 0; i < cad.Length; i++)
            {
                if (!((cad[i] == ' ') && (cad[i + 1] == ' ')))
                {
                    res += cad[i];
                }
            }
            return res.Trim();
        }
        /// <summary>
        /// metodo que verifica si la cadena tiene numeros
        /// </summary>
        /// <param name="cad"></param>
        /// <returns></returns>
        public static bool Numbers(string cad)
        {
            foreach (char c in cad)
            {
                if (!char.IsNumber(c) && c != ',')
                    return false;
            }
            return true;
        }

        /// <summary>
        ///  Metodo que verifica solo letras y espacios
        /// </summary>
        /// <param name="cad"></param>
        /// <returns></returns>
        public static bool LettersAndSpaces(string cad)
        {
            foreach (char c in cad)
            {
                if (!char.IsLetter(c) && c != ' ')
                    return false;
            }
            return true;

        }




    }
}
