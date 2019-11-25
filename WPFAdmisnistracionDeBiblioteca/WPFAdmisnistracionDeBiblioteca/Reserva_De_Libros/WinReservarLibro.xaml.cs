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
using BRL;

namespace WPFAdmisnistracionDeBiblioteca.Reserva_De_Libros
{
    /// <summary>
    /// Lógica de interacción para WinReservarLibro.xaml
    /// </summary>
    public partial class WinReservarLibro : Window
    {
        /// <summary>
        /// propiedad de libro 
        /// </summary>
        Common.Libros lib;

        /// <summary>
        /// propiedad reserva 
        /// </summary>
        Common.Prestamo pres;

        /// <summary>
        /// brl de  prestam
        /// </summary>

        BRL.LibroBRL libbrl;

        /// <summary>
        /// instancia de reervabrl
        /// </summary>
        BRL.ReservacionBRL reserbaBrl;


        /// <summary>
        /// instancia de prestamo brl
        /// </summary>
        PrestamoBRL prestamobrl;


        byte idLibro;

        string nombreLibro;
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public WinReservarLibro()
        {
            InitializeComponent();
            reserbaBrl = new ReservacionBRL();
            Contar();
        }
        private void Contar()
        {
            DataTable dt = reserbaBrl.Contar(Sesion.idSesion);
            if (int.Parse(dt.Rows[0][0].ToString()) >= 3)
            {
                btnReserva.IsEnabled = false;
            }
            else
            {
                btnReserva.IsEnabled = true;
            }
        }
        public void CargarDataGrid()
        {
            try
            {
                libbrl = new BRL.LibroBRL();
                dtgData.ItemsSource = libbrl.SelectLikeFullLibro(txtBusquedaNombre.Text).DefaultView;
                dtgData.Columns[0].Visibility = Visibility.Hidden;
                dtgData.Columns[6].Visibility = Visibility.Hidden;
                dtgData.Columns[7].Visibility = Visibility.Hidden;
                dtgData.Columns[8].Visibility = Visibility.Hidden;
                dtgData.Columns[9].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargarDataGridLibroR()
        {
            try
            {
                reserbaBrl = new BRL.ReservacionBRL();

                dtglibros.ItemsSource = reserbaBrl.SelectReservaLibro(Sesion.idSesion).DefaultView;
                dtgData.Columns[0].Visibility = Visibility.Hidden;
                dtgData.Columns[1].Visibility = Visibility.Hidden;
                dtgData.Columns[2].Visibility = Visibility.Hidden;
                dtgData.Columns[3].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //    private void btnGuardar_Click(object sender, RoutedEventArgs e)
        //{
        //    if (dgvDatos.SelectedItem != null)
        //    {
        //        try
        //        {
        //            Insertar();
        //            CargarDataGridLibroR();
        //            Contar();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Tienes que seleccionar un libro");
        //    }
        //}

        private void Insertar()
        {
            //Operaciones.WriteLogsDebug("InsertarPersona", "btnCrear_Click", string.Format("{0} Info: {1}",
            //DateTime.Now.ToLongDateString(),
            //"Empezando a ejecutar el metodo de la capa de presentacion para crear un empleado"));

            try
            {
                Common.Prestamo id = PrestamoBRL.ObtenerID();
                int contadorcirijillo = id.IdPrestamo;
                contadorcirijillo++;
                Common.Prestamo reserba = new Common.Prestamo();
                reserba.IdPrestamo = contadorcirijillo;
                reserba.Reserva = 1;
                //reserba.Multas = 0;
               // reserba.Monto_multas = 0;
                reserba.IdUsuario = Sesion.idSesion;
                reserba.IdLibro = idLibro;
                ReservacionBRL.Insertar(reserba);
            }
            catch (Exception ex)
            {
                //Operaciones.WriteLogsRelease("InsertarPrestamo", "btnCrear_Click", string.Format("{0} Error: {1}",
                // DateTime.Now.ToShortDateString(), ex.Message));
                MessageBoxResult result = MessageBox.Show("Existe un problema, por favor contactese con su administrador",
                                       "Confirmation", MessageBoxButton.OK,
                                       MessageBoxImage.Error);
                if (result == MessageBoxResult.OK)
                {
                    Application.Current.Shutdown();
                }
            }

            //Operaciones.WriteLogsDebug("InsertarEmpleado", "btnCrear_Click", string.Format("{0} Info: {1}",
            //  DateTime.Now.ToShortDateString(),
            //   "Termino a ejecutar el metodo de la capa de presentacion para crear un empleado"));
        }

        //private void btnCancelar_Click(object sender, RoutedEventArgs e)
        //    {

        //    }

            private void btnClose_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }

        private void dtgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgData.Items.Count > 0)
            {
                if (dtgData.SelectedItem != null)
                {
                    try
                    {
                        DataRowView dataRow = (DataRowView)dtgData.SelectedItem;
                        idLibro = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                        nombreLibro = dataRow.Row.ItemArray[1].ToString();
                        //imgLibro.Source = new BitmapImage(new Uri(Configuracion.configRutaFoto + idLibro + "Libro.jpg"));
                       // lblDescripcion.Content = dataRow.Row.ItemArray[6].ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dtglibros.Items.Count > 0)
            {
                if (dtglibros.SelectedItem != null)
                {
                    try
                    {
                        DataRowView dataRow = (DataRowView)dtglibros.SelectedItem;
                        int idReserva = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                        nombreLibro = dataRow.Row.ItemArray[4].ToString();
                        ReservacionBRL.Eliminar(idReserva);
                        CargarDataGridLibroR();
                        Contar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Tienes que seleccionar un libro de reserva");
                }
            }
        }

        private void btnReserva_Click(object sender, RoutedEventArgs e)
        {
            if (dtgData.SelectedItem != null)
            {
                try
                {
                    Insertar();
                    CargarDataGridLibroR();
                    Contar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Tienes que seleccionar un libro");
            }
        }

        private void txtBusquedaNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            CargarDataGrid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDataGrid();
            CargarDataGridLibroR();
        }
    }
 }

