using BRL;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WPFAdmisnistracionDeBiblioteca.Usuario
{
    /// <summary>
    /// Lógica de interacción para WinLogin.xaml
    /// </summary>
    public partial class WinLogin : Window
    {
        /// <summary>
        /// Auxiliar que se utiliza para almacenar el IdSesion y enviarlo a otra ventana en caso de que el estadoPassword = 0
        /// </summary>
        short idAux = 0;

        /// <summary>
        /// Variable de objeto UsuarioBRL el cual es la clase logica que realiza las invocaciones a los metodos de interaccion con la base de datos para realizar el logeo
        /// </summary>
        UsuarioBRL brl;
        byte cont = 0;
        public WinLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombreUsuario.Text != "" && txtPassword.Password != "")
            {
                try
                {
                    brl = new UsuarioBRL();
                    DataTable dt = brl.Login(txtNombreUsuario.Text, txtPassword.Password);
                    if (dt.Rows.Count > 0)
                    {

                        Sesion.idSesion = short.Parse(dt.Rows[0][0].ToString());
                        Sesion.usuarioSesion = dt.Rows[0][1].ToString();
                        Sesion.rolSesion = dt.Rows[0][2].ToString();
                     //   Sesion.estadoPassword = byte.Parse(dt.Rows[0][3].ToString());
                        idAux = Sesion.idSesion;

                        ///Se lanzara esta ventana para cambiar la contraseña
                        //if (Sesion.estadoPassword == 0)
                        //{
                        //    Usuario.WinContraseña winC = new Usuario.WinContraseña(idAux);
                        //    winC.ShowDialog();
                        //}

                        //variables de Configuracion
                        //ConfigBRL configBRL = new ConfigBRL();
                        //DataTable dtConfig = configBRL.Select();
                       // Config.pathFotoEmpleado = dtConfig.Rows[0][0].ToString();
                        //.pathFotoUsuario = dtConfig.Rows[0][1].ToString();
                       // Config.pathFotoPlato = dtConfig.Rows[0][2].ToString();
                       // Config.pathFotoRefresco = dtConfig.Rows[0][3].ToString();
                        this.Visibility = Visibility.Hidden;
                        MainWindow win = new MainWindow();
                        win.Show();
                    }
                    else
                    {
                        cont++;
                        txtNombreUsuario.Clear();
                        txtPassword.Clear();
                        tbkDetalle.Text = "Incorrecto: " + cont + " Intento(s)";
                        if (cont > 3)
                        {
                            this.Close();
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show("Error al insertar el empleado" + err);
                    throw err;
                }

            }
            else
            {
                tbkDetalle.Text = "Es necesario llenar los campos";
                cont++;
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtNombreUsuario_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            else
                e.Handled = false;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtNombreUsuario.Text = "admin";
            txtPassword.Password = "admin123";
        }

        private void click_llamarContra(object sender, MouseButtonEventArgs e)
        {
            Usuario.WinContraseña log = new Usuario.WinContraseña();
            log.ShowDialog();
        }
    }
}
