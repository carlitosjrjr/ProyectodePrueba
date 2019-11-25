using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Common;
using System.Windows;

namespace DAL.Email
{
    public abstract class EmailServicesDAL
    {
        #region
        //private Usuario user;

        //public Usuario User
        //{
        //    get { return user; }
        //    set { user = value; }
        //}

        //List<Usuario> correos = new List<Usuario>();



        //public EmailServicesDAL(Usuario user)
        //{
        //    this.user = user;
        //}

        #endregion

        //private  string pass;

        //public abstract string Pass
        //{
        //    get { return pass; }
        //    set { pass = value; }
        //}


        private SmtpClient smptclient;
        public string  pass;
        public string smail;
        public string host;
        public int puerto;
        public bool ssl;

        public void iniciarSmtp()
        {
            smptclient = new SmtpClient();
            smptclient.Credentials = new NetworkCredential(smail, pass);
            smptclient.Host = host;
            smptclient.Port = puerto;
            smptclient.EnableSsl = ssl;
        }


        public void enviarCorreo(string cabeza, string body, List<string> corrreo)
        {
            var mensaje = new MailMessage();
            try
            {
                mensaje.From = new MailAddress(smail);

                foreach (string correos in corrreo)
                {
                    mensaje.To.Add(correos);
                }
                mensaje.Subject = cabeza;
                mensaje.Body = body;
                mensaje.Priority = MailPriority.Normal;

                smptclient.Send(mensaje);

            }
            catch (Exception err)
            {
                MessageBox.Show("Error al insertar el cliente" + err);
                throw err;
            }
        }
    }
}
