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
using System.IO;
using Microsoft.Win32;

namespace WPFAdmisnistracionDeBiblioteca.Libros
{
    /// <summary>
    /// Lógica de interacción para WinNuevoLibro.xaml
    /// </summary>
    public partial class WinNuevoLibro : Window
    {
        /// <summary>
        /// <code>opcion</code>
        /// </summary>
        byte opcion = 0;
        /// <summary>
        /// propiedad
        /// </summary>
        Common.Libros lib;
        /// <summary>
        /// propiedad brllibro
        /// </summary>
        BRL.LibroBRL libbrl;
        /// <summary>
        /// Auxiliares para comparar si la fotografia a cambiado
        /// </summary>
        string pathFotografia = string.Empty, pathFotoEmpleadoServer = string.Empty;

        public WinNuevoLibro()
        {
            InitializeComponent();
            tbkTItulo.Text = "Registrar Libros";
            opcion = 0;
        }
        public WinNuevoLibro(Common.Libros librooo)
        {
            InitializeComponent();
            this.lib = librooo;
            tbkTItulo.Text = "Actualizar Libros";
            opcion = 1;
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
                            lib = new Common.Libros(txtTitulo.Text, txtAutor.Text, txtAnoPublicacion.SelectedDate.Value, txtIsbn.Text, txtFechaRegistro.SelectedDate.Value);
                            libbrl = new LibroBRL(lib);
                            libbrl.Insert();

                            //capturamos la imagen

                           // short id = MethodsBRL.GetMaxIDTable("idLibro", "Libro");

                            //se copia la imagen
                           // File.Copy(pathFotografia, Config.pathFotoEmpleado + id + ".jpg");
                            MessageBox.Show("Correcto");
                            break;

                        case 1://modificacion
                            //asignacion de valores
                            lib.Titulo = txtTitulo.Text;
                            lib.Autor=txtAutor.Text;
                            lib.AnoPublicacion = txtAnoPublicacion.SelectedDate.Value;
                            lib.Isbn = txtIsbn.Text;
                            lib.FechaRegistro = txtFechaRegistro.SelectedDate.Value;
                            
                            //IMAGEN
                            if (pathFotografia != pathFotoEmpleadoServer)
                            {
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                if (lib.Foto == 1)
                                {
                                    File.Delete(pathFotoEmpleadoServer);
                                    File.Copy(pathFotografia, Config.pathFotoEmpleado + lib.IdLibro + ".jpg");
                                }
                                else
                                {
                                    File.Copy(pathFotografia, Config.pathFotoEmpleado + lib.IdLibro + ".jpg");
                                }
                                //File.Delete(pathFotoEmpleadoServer);
                                //File.Copy(pathFotografia, Config.pathFotoEmpleado + empleado.IdEmpleado + ".jpg");
                            }

                            libbrl = new LibroBRL(lib);
                            libbrl.Update();
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// De la administracion de Usuario al momento de modificar se carga los valores en esta ventana
        /// </summary>
        private void LoadDataEmpleado()
        {
            if (lib != null)
            {
                txtTitulo.Text = lib.Titulo;
                txtAutor.Text = lib.Autor;
                txtAnoPublicacion.Text = lib.AnoPublicacion.ToString();
                txtIsbn.Text = lib.Isbn;
                txtFechaRegistro.Text = lib.FechaRegistro.ToString();
               

                ////el mapa
                //puntoUbicacion = new Location(empleado.Latitud, empleado.Longitud);
                //miMapa.Children.Clear();
                //Pushpin marcado = new Pushpin();
                //marcado.Location = puntoUbicacion;
                //miMapa.Children.Add(marcado);
                //miMapa.SetView(puntoUbicacion, 14);

                //fotografia

                try
                {
                    if (lib.Foto == 1)
                    {
                        imgPersona.Source = new BitmapImage(new Uri(Config.pathFotoEmpleado + lib.IdLibro + ".jpg"));
                        pathFotografia = Config.pathFotoEmpleado + lib.IdLibro + ".jpg";
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
    }
}
