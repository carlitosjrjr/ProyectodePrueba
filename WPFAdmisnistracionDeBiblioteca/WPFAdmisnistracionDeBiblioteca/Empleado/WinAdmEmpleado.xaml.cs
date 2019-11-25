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
using BRL;
using Common;
using System.Data;
using Microsoft.Maps.MapControl.WPF;

namespace WPFAdmisnistracionDeBiblioteca.Empleado
{
    /// <summary>
    /// Lógica de interacción para WinAdmEmpleado.xaml
    /// </summary>
    public partial class WinAdmEmpleado : Window
    {
        /// <summary>
        /// auxiliar que se utiliza para conocer que clave se esta restableciendo por el administrador
        /// </summary>
        string clave = string.Empty;

        /// <summary>
        /// Variable objeto de la clase Empleado donde se carga cuando se selecciona una fila en el datagrid
        /// </summary>
        Common.Empleado empleado = null;

        /// <summary>
        /// Variable objeto de la clase Usuario donde se llena el objeto cuando se realiza una seleccion
        /// </summary>
        Common.Usuario usuario = null;

        /// <summary>
        /// Variable objeto de la clase UsuarioBRL que se comunica con la base de datos
        /// </summary>
        UsuarioBRL brlUsuario;

        /// <summary>
        /// Variable objeto de la clase EmpleadoBRL que se comunica con la base de Datos
        /// </summary>
        EmpleadoBRL brlEmpleado;

        /// <summary>
        /// Auxiliar que identifica por que tipo de empleado se realizara la busqueda
        /// </summary>
        byte busquedaEmpleado;
        public WinAdmEmpleado()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Carga los datos de Usuario en el DataGrid
        /// </summary>
        private void LoadDataGridUsuario()
        {
            try
            {
                if (txtBusquedaNombre.Text != string.Empty && txtBusquedaNombre.Text.Length > 2)
                {
                    brlUsuario = new UsuarioBRL();
                    dtgData.ItemsSource = brlUsuario.SelectFullNameUsuario(txtBusquedaNombre.Text).DefaultView;
                    dtgData.Columns[0].Visibility = Visibility.Hidden;

                    lblInfo.Content = dtgData.Items.Count + " Registros Encontrados";
                    //if (dtgData.Items.Count > 0)
                    //{
                    //    dtgData.SelectedItem = dtgData.Items[0];
                    //}
                }
                else
                {
                    dtgData.ItemsSource = null;
                    lblInfo.Content = "No se encontro ningun registro";
                    ClearDataEmpleado();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Carga los datos de Empleado en el DataGrid
        /// </summary>
        private void LoadDataGridEmpleado()
        {
            try
            {
                if (txtBusquedaNombre.Text != string.Empty && txtBusquedaNombre.Text.Length > 2)
                {
                    brlEmpleado = new EmpleadoBRL();
                    dtgData.ItemsSource = brlEmpleado.SelectFullName(txtBusquedaNombre.Text).DefaultView;
                    dtgData.Columns[0].Visibility = Visibility.Hidden;
                    dtgData.Columns[3].Visibility = Visibility.Hidden;
                    lblInfo.Content = dtgData.Items.Count + " Registros Encontrados";
                    //if (dtgData.Items.Count>0)
                    //{
                    //    dtgData.SelectedItem = dtgData.Items[0];
                    //}
                }
                else
                {
                    dtgData.ItemsSource = null;
                    lblInfo.Content = "No se encontro ningun registro";
                    ClearDataEmpleado();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cmbOpcion_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (cmbOpcion.SelectedItem != null)
            {
                if (cmbOpcion.SelectedIndex == 0)
                {
                    busquedaEmpleado = 0;
                    mitRestablecerClave.Visibility = Visibility.Collapsed;
                }
                else
                {
                    busquedaEmpleado = 1;
                    mitRestablecerClave.Visibility = Visibility.Visible;
                }
                if (txtBusquedaNombre.IsEnabled == false)
                {
                    txtBusquedaNombre.IsEnabled = true;
                }
                if (txtBusquedaNombre.Text != string.Empty)
                {
                    txtBusquedaNombre.Clear();
                    txtBusquedaNombre.Focus();
                }
                //dositem.Visibility = Visibility.Visible;
                //txtBusquedaNombre.IsEnabled = true;
                // txtBusquedaNombre.Clear();
                //txtBusquedaNombre.Focus();
            }
        }
        /// <summary>
        /// Evento que determina la busqueda si es por Empleado o Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBusquedaNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (busquedaEmpleado == 0)
            {
                LoadDataGridEmpleado();
            }
            else
                LoadDataGridUsuario();
        }

        private void dtgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgData.Items.Count > 0 && dtgData.SelectedItem != null)
            {
                if (busquedaEmpleado == 1)
                {
                    try
                    {
                        usuario = null;
                        DataRowView dataRow = (DataRowView)dtgData.SelectedItem;
                        short id = short.Parse(dataRow.Row.ItemArray[0].ToString());
                        brlUsuario = new UsuarioBRL();
                        usuario = brlUsuario.Get(id);

                        LoadDatosUsuario();

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Error al insertar el cliente" + err);
                        throw err;
                    }
                }
                else
                {
                    try
                    {
                        empleado = null;
                        DataRowView dataRow = (DataRowView)dtgData.SelectedItem;
                        short id = short.Parse(dataRow.Row.ItemArray[0].ToString());
                        brlEmpleado = new EmpleadoBRL();
                        empleado = brlEmpleado.Get(id);

                        LoadDatosEmpleado();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }

            }
            else
            {
                ClearDataEmpleado();
            }
        }
        /// <summary>
        /// Cargamos los datos de busqueda de Empleado en los campos
        /// </summary>
        private void LoadDatosEmpleado()
        {
            if (empleado != null)
            {
                //mostramos los datos
                gridDatosPersonales.Visibility = Visibility.Visible;
                lblNombreCompleto.Content = "Nombre Completo: " + empleado.GetFullName();
                lblCi.Content = "CI: " + empleado.Ci;
                lblSexo.Content = "Sexo: " + empleado.Sexo;
                lblTelefono.Content = "Telefono: " + empleado.Telefono;

                //mostramos la foto
                //try
                //{
                //    if (empleado.Foto == 1)
                //    {
                //        imgEmpleado.Source = new BitmapImage(new Uri(Config.pathFotoEmpleado + empleado.IdEmpleado + ".jpg"));
                //    }
                //    else
                //    {
                //        imgEmpleado.Source = new BitmapImage(new Uri(Config.pathFotoEmpleado + "0.jpg"));
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Ocurrio un error" + ex.Message);
                //    imgEmpleado.Source = null;
                //}
                //mostramos el mapa
                miMapa.Children.Clear();
                Pushpin marcador = new Pushpin();
                Location punto = new Location(empleado.Latitud, empleado.Longitud);
                marcador.Location = punto;
                miMapa.Children.Add(marcador);
                miMapa.SetView(punto, 16);
            }
            else
            {
                gridDatosPersonales.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// Cuando se borra el campo de busqueda se oculta el datagrid y se limpia el mapa
        /// </summary>
        private void ClearDataEmpleado()
        {
            gridDatosPersonales.Visibility = Visibility.Hidden;
            miMapa.Children.Clear();
        }
        /// <summary>
        /// Cargamos los datos de busqueda de Usuario en los campos
        /// </summary>
        private void LoadDatosUsuario()
        {
            if (usuario != null)
            {
                //mostramos los datos

                gridDatosPersonales.Visibility = Visibility.Visible;
                lblNombreCompleto.Content = "Nombre Completo: " + usuario.GetFullName();
                lblCi.Content = "CI: " + usuario.Ci;
                lblSexo.Content = "Sexo: " + usuario.Sexo;
                lblTelefono.Content = "Telefono: " + usuario.Telefono;

            
                //mostramos la foto
                //try
                //{
                //    if (usuario.Foto == 1)
                //    {
                //        imgEmpleado.Source = new BitmapImage(new Uri(Config.pathFotoUsuario + usuario.IdUsuario + ".jpg"));
                //    }
                //    else
                //    {
                //        imgEmpleado.Source = new BitmapImage(new Uri(Config.pathFotoUsuario + "0.jpg"));
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Ocurrio un error comuniquese con el adm" + ex.Message);
                //    imgEmpleado.Source = null;
                //}
                //mostramos el mapa
                miMapa.Children.Clear();
                Pushpin marcador = new Pushpin();
                Location punto = new Location(usuario.Latitud, usuario.Longitud);
                marcador.Location = punto;
                miMapa.Children.Add(marcador);
                miMapa.SetView(punto, 16);
            }
            else
            {
                gridDatosPersonales.Visibility = Visibility.Hidden;
            }
        }
        /// <summary>
        /// Cuando se quere modificar enviamos un objeto a la ventana nuevo empleado donde se cargara los valores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mitModificar_Click(object sender, RoutedEventArgs e)
        {
            if (busquedaEmpleado == 0)
            {
                if (dtgData.SelectedItem != null && empleado != null)
                {
                    imgEmpleado.Source = null;
                    Empleado.WinNuevoEmpleado win = new Empleado.WinNuevoEmpleado(empleado);
                    win.ShowDialog();

                }
            }
            else
            {
                if (dtgData.SelectedItem != null && usuario != null)
                {
                    imgEmpleado.Source = null;
                    Empleado.WinNuevoUsuario win = new Empleado.WinNuevoUsuario(usuario);
                    win.ShowDialog();

                }
            }
        }

        private void mitDarBaja_Click(object sender, RoutedEventArgs e)
        {
            if (dtgData.Items.Count > 0 && dtgData.SelectedItem != null)
            {
                if (busquedaEmpleado == 1)
                {
                    if (MessageBox.Show("Esta seguro de eliminar al Usuario", "Dar de Baja", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            brlUsuario = new UsuarioBRL(usuario);
                            brlUsuario.Delete();
                            MessageBox.Show("Registro Eliminado");
                            LoadDataGridUsuario();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Esta seguro de eliminar al Empleado", "Dar de Baja", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            brlEmpleado = new EmpleadoBRL(empleado);
                            brlEmpleado.Delete();
                            MessageBox.Show("Registro Eliminado");
                            LoadDataGridEmpleado();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void mitRestablecerClave_Click(object sender, RoutedEventArgs e)
        {
            if (dtgData.SelectedItem != null && usuario != null)
            {
                clave = contraseña(usuario.Nombres, usuario.PrimerApellido);
                MessageBox.Show(clave);

                usuario.Password = clave;

                brlUsuario = new UsuarioBRL(usuario);
                brlUsuario.RestablecerContraseña();

            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (busquedaEmpleado == 0)
            {
                LoadDataGridEmpleado();
            }
            else
            {
                LoadDataGridUsuario();
            }
        }
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
                cont++;
                cad += nombre[x];

            }
            x = n.Next(1, 50);
            return "res" + cad + primerApellido.Substring(1, 3) + x.ToString();
        }
    }
}
