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
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Win32;
using System.IO;

namespace WPFAdmisnistracionDeBiblioteca.Empleado
{
    /// <summary>
    /// Lógica de interacción para WinNuevoUsuario.xaml
    /// </summary>
    public partial class WinNuevoUsuario : Window
    { /// <summary>
      /// auxiliar que se utiliza para determinar si se trata de una Insercion o Actualizacion de Usuario
      /// </summary>
        byte opcion = 0;

        /// <summary>
        /// Variable objeto de la clase Empleado que se utiliza para iniciar los parametros
        /// </summary>
        Common.Empleado empleado;

        /// <summary>
        /// Variable objeto de la clase Usuario que se utiliza para iniciar los parametros
        /// </summary>
        Common.Usuario usuario;

        /// <summary>
        /// Variable objeto de la clase UsuarioBRL que se comunica con la base de datos
        /// </summary>
        UsuarioBRL brl;

        /// <summary>
        /// Variable que se utiliza para cargar los puntos marcados en el mapa
        /// </summary>
        Location puntoUbicacion;

        /// <summary>
        /// auxiliares que se utilizaran para comparar si el pathFotografia ha cambiado
        /// </summary>
        string pathFotografia = string.Empty, pathFotoUsuarioServer = string.Empty;

        public WinNuevoUsuario()
        {
            InitializeComponent();
            tbkTitulo.Text = "Registro de Usuarios";
            opcion = 0;
        }

        /// <summary>
        /// Iniciamos la ventana con parametro Usuario para realizar una modificacion
        /// </summary>
        /// <param name="usuario"></param>
        public WinNuevoUsuario(Common.Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            LoadDataUsuario();
            tbkTitulo.Text = "Modificacion de Datos del Empleado Usuario";
            opcion = 1;
        }

        /// <summary>
        /// Cargamos los datos que nos llega en el objeto Usuario a los campos
        /// </summary>
        private void LoadDataUsuario()
        {
            if (usuario != null)
            {
                txtNombres.Text = usuario.Nombres;
                txtPrimerApellido.Text = usuario.PrimerApellido;
                txtSegundoApellido.Text = usuario.SegundoApellido;
                txtCI.Text = usuario.Ci;
                cbxSexo.Text = usuario.Sexo;
                txtTelefono.Text = usuario.Telefono;

                //el mapa
                puntoUbicacion = new Location(usuario.Latitud, usuario.Longitud);
                miMapa.Children.Clear();
                Pushpin marcado = new Pushpin();
                marcado.Location = puntoUbicacion;
                miMapa.Children.Add(marcado);
                miMapa.SetView(puntoUbicacion, 14);

                //fotografia

                try
                {
                    if (usuario.Foto == 1)
                    {
                        imgPersona.Source = new BitmapImage(new Uri(Config.pathFotoUsuario + usuario.IdUsuario + ".jpg"));
                        pathFotografia = Config.pathFotoUsuario + usuario.IdUsuario + ".jpg";
                        pathFotoUsuarioServer = pathFotografia;
                    }
                    else
                    {
                        imgPersona.Source = new BitmapImage(new Uri(Config.pathFotoUsuario + "0.jpg"));
                        pathFotografia = Config.pathFotoUsuario + "0.jpg";
                        pathFotoUsuarioServer = pathFotografia;
                    }
                }
                catch (Exception ex)
                {
                    imgPersona.Source = null;
                    pathFotografia = string.Empty;
                    MessageBox.Show(ex.Message);
                }

            }
        }

        /// <summary>
        /// Creamos una contraseña a partir del nombre y apellido
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="primerApellido"></param>
        /// <returns></returns>
        private string contraseña(string nombre, string primerApellido)
        {
            string cad = "";
            byte cont = 0;
            Random n = new Random();
            int x;
            while (cont < 3)
            {
                x = n.Next(1, nombre.Length - 1);
                if (nombre[x] == ' ')
                {
                    continue;
                }

                cad += nombre[x];
                cont++;
            }
            x = n.Next(1, 50);
            return cad + primerApellido.Substring(1, 3) + x.ToString();
        }

        /// <summary>
        /// Creamos un nombre de usuario a partir del nmbre y primer apellido
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="primerApellido"></param>
        /// <returns></returns>
        private string nombreUsuario(string nombre, string primerApellido)
        {
            string cad = "";
            Random n = new Random();
            int x = n.Next(1, 200);
            if (nombre.Length <= 7 || primerApellido.Length <= 7)
            {
                cad = nombre.Substring(0, 3) + primerApellido.Substring(1, 3);

            }
            else

                cad = nombre.Substring(0, 2) + primerApellido.Substring(1, 2);


            return cad + x.ToString();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void btnFotografia_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de Imagenes|*.jpg";
            if (ofd.ShowDialog() == true)
            {
                imgPersona.Source = new BitmapImage(new Uri(ofd.FileName));
                pathFotografia = ofd.FileName;
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (pathFotografia != string.Empty)
                {
                    switch (opcion)
                    {
                        case 0:
                            empleado = new Common.Empleado(txtNombres.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, txtCI.Text, cbxSexo.Text, DateTime.Now, txtTelefono.Text, 1, puntoUbicacion.Latitude, puntoUbicacion.Longitude, txtFechaNacimiento.SelectedDate.Value,Sesion.idSesion);
                           // string usua = nombreUsuario(txtNombres.Text, txtPrimerApellido.Text);
                            //string clave = contraseña(txtNombres.Text, txtPrimerApellido.Text);
                           // MessageBox.Show("Usuario: " + usua + " Password: " + clave);
                            usuario = new Common.Usuario(txtUsuario.Text, txtPasssword.Password,txtCorreo.Text, cbxRol.Text);
                            MessageBox.Show("Usuario: " + txtUsuario.Text + " Password: " + txtPasssword.Password);
                            brl = new UsuarioBRL(empleado, usuario);
                            brl.Insert();

                            short id = MethodsBRL.GetMaxIDTable("idEmpleado", "Empleado");

                            //se copia la imagen
                            File.Copy(pathFotografia, Config.pathFotoUsuario + id + ".jpg");
                            MessageBox.Show("Correcto");
                            break;
                        case 1: //Modificacion
                            usuario.Nombres = txtNombres.Text;
                            usuario.PrimerApellido = txtPrimerApellido.Text;
                            usuario.SegundoApellido = txtSegundoApellido.Text;
                            usuario.Ci = txtCI.Text;
                            usuario.Sexo = cbxSexo.Text;
                            usuario.Telefono = txtTelefono.Text;
                            usuario.Latitud = puntoUbicacion.Latitude;
                            usuario.Longitud = puntoUbicacion.Longitude;

                            //IMAGEN
                            if (pathFotografia != pathFotoUsuarioServer)
                            {
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                if (usuario.Foto == 1)
                                {
                                    File.Delete(pathFotoUsuarioServer);
                                    File.Copy(pathFotografia, Config.pathFotoUsuario + usuario.IdUsuario + ".jpg");
                                }
                                else
                                {
                                    File.Copy(pathFotografia, Config.pathFotoUsuario + usuario.IdUsuario + ".jpg");
                                }
                                //File.Delete(pathFotoEmpleadoServer);
                                //File.Copy(pathFotografia, Config.pathFotoEmpleado + empleado.IdEmpleado + ".jpg");
                            }

                            brl = new UsuarioBRL(usuario);
                            brl.Update();
                            MessageBox.Show("El registro se modifico con exito");

                            this.Close();
                            break;
                    }
                }
                else
                    MessageBox.Show("Es necesario registrar una fotografia");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSatelite_Click(object sender, RoutedEventArgs e)
        {
            miMapa.Focus();
            miMapa.Mode = new AerialMode(true);
        }

        private void btnCalle_Click(object sender, RoutedEventArgs e)
        {
            miMapa.Focus();
            miMapa.Mode = new RoadMode();
        }

        private void btnAcercar_Click(object sender, RoutedEventArgs e)
        {
            miMapa.Focus();
            miMapa.ZoomLevel++;
        }

        private void btnAlejar_Click(object sender, RoutedEventArgs e)
        {
            miMapa.Focus();
            miMapa.ZoomLevel--;
        }

        private void miMapa_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            var mousePosicion = e.GetPosition((UIElement)sender);

            puntoUbicacion = miMapa.ViewportPointToLocation(mousePosicion);

            Pushpin marcador = new Pushpin();
            marcador.Location = puntoUbicacion;

            miMapa.Children.Clear();
            miMapa.Children.Add(marcador);
        }
    }
}

