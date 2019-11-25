using BRL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Common;
using BRL;

namespace WPFAdmisnistracionDeBiblioteca.Usuario
{
    /// <summary>
    /// Lógica de interacción para WinContraseña.xaml
    /// </summary>
    public partial class WinContraseña : Window
    {
        /// <summary>
        /// Auxiliar que se utiliza para obtener el id de Sesion
        /// </summary>
        short id = 0;

        /// <summary>
        /// Objeto User que se enviara para cambiar la contraseña si esque el estadoPassword = 0
        /// </summary>
        Common.Usuario user = new Common.Usuario();
        UsuarioBRL brlUsuario;
        public WinContraseña()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Cargamos el ID
        /// </summary>
        /// <param name="id"></param>
        public WinContraseña(short id)
        {
            InitializeComponent();
            this.id = id;

            user.IdUsuario = id;
        }

        private void btnCambiarContraseña_Click(object sender, RoutedEventArgs e)
        {
            BRL.email.EmailBRL mail = new BRL.email.EmailBRL();
            var resul= mail.recuperarPasswprd(txtCorreo.Text);
            lblcorreo.DataContext = resul;

            //lcorreo.te = result;
            //if (txtPassword.Password == txtConfirmarPassword.Password)
            //{
            //    user.Password = txtPassword.Password;
            //    brlUsuario = new UsuarioBRL(user);
            //    brlUsuario.CambiarContraseña();
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Ambos campos deben coincidir");
            //}

        }

        private void txtPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }

        private void txtConfirmarPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PackIcon_TextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
