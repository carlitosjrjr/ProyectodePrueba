using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BRL.email
{
    public class EmailBRL
    {
        public string recuperarPasswprd(string requestuser)
        {
            //return UsuarioDAL.RequestPassword(requestuser);
            UsuarioDAL a = new UsuarioDAL();
            return a.RequestPassword(requestuser);
        }
    }
}
