using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Email
{
    public class EmailSoporteDAL:EmailServicesDAL
    {
       
        public EmailSoporteDAL()
        {         
            smail = "sergiolara4238296@gmail.com";
            pass = "sergio_423";
            host = "smtp.gmail.com";
            puerto = 587 ;
            ssl = true;
            iniciarSmtp();
           
        }

        public void notificaciones()
        {

        }
    }
}
