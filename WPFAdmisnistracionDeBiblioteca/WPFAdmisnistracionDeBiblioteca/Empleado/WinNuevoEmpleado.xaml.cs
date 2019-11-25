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
using System.IO;
using Microsoft.Win32;

namespace WPFAdmisnistracionDeBiblioteca.Empleado
{
    /// <summary>
    /// Lógica de interacción para WinNuevoEmpleado.xaml
    /// </summary>
    public partial class WinNuevoEmpleado : Window
    {

        /// <summary>
        /// 0 insert, 1 update
        /// </summary>
        byte opcion = 0;

        /// <summary>
        /// Variable de objeto de la Clase empleado para inicializar los parametros
        /// </summary>
        Common.Empleado empleado;

        /// <summary>
        /// Variable de objeto EmpleadoBRL el cual es la clase logica que realiza las invocaciones a los metodos de interaccion con la base de datos
        /// </summary>
        EmpleadoBRL brlEmpleado;

        /// <summary>
        /// Variable para trabajar con el punto de ubicacion del mapa
        /// </summary>
        Location puntoUbicacion;

        /// <summary>
        /// Auxiliares para comparar si la fotografia a cambiado
        /// </summary>
        string pathFotografia = string.Empty, pathFotoEmpleadoServer = string.Empty;
        public WinNuevoEmpleado()
        {
            InitializeComponent();
            tbkTItulo.Text = "Registro de Empleados";
            opcion = 0;
        }

        public WinNuevoEmpleado(Common.Empleado empleado)
        {
            InitializeComponent();
            this.empleado = empleado;
            LoadDataEmpleado();
            tbkTItulo.Text = "Modificacion de Datos del Empleado";
            opcion = 1;
        }

        /// <summary>
        /// De la administracion de Usuario al momento de modificar se carga los valores en esta ventana
        /// </summary>
        private void LoadDataEmpleado()
        {
            if (empleado != null)
            {
                txtNombres.Text = empleado.Nombres;
                txtPrimerApellido.Text = empleado.PrimerApellido;
                txtSegundoApellido.Text = empleado.SegundoApellido;
                txtCI.Text = empleado.Ci;
                cbxSexo.Text = empleado.Sexo;
                txtTelefono.Text = empleado.Telefono;

                //el mapa
                puntoUbicacion = new Location(empleado.Latitud, empleado.Longitud);
                miMapa.Children.Clear();
                Pushpin marcado = new Pushpin();
                marcado.Location = puntoUbicacion;
                miMapa.Children.Add(marcado);
                miMapa.SetView(puntoUbicacion, 14);

                //fotografia

                try
                {
                    if (empleado.Foto == 1)
                    {
                        imgPersona.Source = new BitmapImage(new Uri(Config.pathFotoEmpleado + empleado.IdEmpleado + ".jpg"));
                        pathFotografia = Config.pathFotoEmpleado + empleado.IdEmpleado + ".jpg";
                        pathFotoEmpleadoServer = pathFotografia;
                    }
                    else
                    {
                        imgPersona.Source = new BitmapImage(new Uri(Config.pathFotoEmpleado + "0.jpg"));
                        pathFotografia = Config.pathFotoEmpleado + "0.jpg";
                        pathFotoEmpleadoServer = pathFotografia;
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
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (pathFotografia != string.Empty)
                {
                    switch (opcion)
                    {
                        case 0: //insertamos
                            empleado = new Common.Empleado(txtNombres.Text, txtPrimerApellido.Text, txtSegundoApellido.Text, txtCI.Text, cbxSexo.Text, DateTime.Now, txtTelefono.Text, 0, puntoUbicacion.Latitude, puntoUbicacion.Longitude,txtFechaNacimiento.SelectedDate.Value, Sesion.idSesion);
                            brlEmpleado = new EmpleadoBRL(empleado);
                            brlEmpleado.Insert();

                            //capturamos la imagen

                            short id = MethodsBRL.GetMaxIDTable("idEmpleado", "Empleado");

                            //se copia la imagen
                            File.Copy(pathFotografia, Config.pathFotoEmpleado + id + ".jpg");
                            MessageBox.Show("Correcto");
                            break;

                        case 1://modificacion
                            //asignacion de valores
                            empleado.Nombres = txtNombres.Text;
                            empleado.PrimerApellido = txtPrimerApellido.Text;
                            empleado.SegundoApellido = txtSegundoApellido.Text;
                            empleado.Ci = txtCI.Text;
                            empleado.Sexo = cbxSexo.Text;
                            empleado.Telefono = txtTelefono.Text;
                            empleado.Latitud = puntoUbicacion.Latitude;
                            empleado.Longitud = puntoUbicacion.Longitude;
                            empleado.FechaNacimiento = txtFechaNacimiento.SelectedDate.Value;

                            //IMAGEN
                            if (pathFotografia != pathFotoEmpleadoServer)
                            {
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                if (empleado.Foto == 1)
                                {
                                    File.Delete(pathFotoEmpleadoServer);
                                    File.Copy(pathFotografia, Config.pathFotoEmpleado + empleado.IdEmpleado + ".jpg");
                                }
                                else
                                {
                                    File.Copy(pathFotografia, Config.pathFotoEmpleado + empleado.IdEmpleado + ".jpg");
                                }
                                //File.Delete(pathFotoEmpleadoServer);
                                //File.Copy(pathFotografia, Config.pathFotoEmpleado + empleado.IdEmpleado + ".jpg");
                            }

                            brlEmpleado = new EmpleadoBRL(empleado);
                            brlEmpleado.Update();
                            MessageBox.Show("El registro se modifico con exito");

                            this.Close();
                            break;
                        default:
                            break;
                    }
                }
                else
                    MessageBox.Show("Es necesario elegir una fotografia del empleado");
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al insertar el cliente" + err);
                throw err;
            }

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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

