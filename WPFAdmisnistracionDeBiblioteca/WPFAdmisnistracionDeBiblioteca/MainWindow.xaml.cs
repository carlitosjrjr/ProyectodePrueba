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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common;
using BRL;

namespace WPFAdmisnistracionDeBiblioteca
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Objeto de la Ventana WinLogin
        /// </summary>
        Usuario.WinLogin win = new Usuario.WinLogin();
        public MainWindow()
        {
            InitializeComponent();
            tbkUsuario.Text = Sesion.Info();
            ////imgLogin.ImageSource = new BitmapImage(new Uri(Config.pathFotoUsuario + Sesion.idSesion + ".jpg"));
            switch (Sesion.rolSesion)
            {
                case "Administrador":

                    break;

                case "Empleado":
                    itemHome.Visibility = Visibility.Collapsed;
                    //itemAlimentos.Visibility = Visibility.Collapsed;
                    itemEmpleado.Visibility = Visibility.Collapsed;
                    itemReporte.Visibility = Visibility.Collapsed;
                    itemLibros.Visibility = Visibility.Collapsed;
                    break;
                case "Cliente":
                    itemHome.Visibility = Visibility.Collapsed;
                    //itemAlimentos.Visibility = Visibility.Collapsed;
                    itemEmpleado.Visibility = Visibility.Collapsed;
                    itemReporte.Visibility = Visibility.Collapsed;
                    itemPrestamo.Visibility = Visibility.Collapsed;
                    itemLibros.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void btnCollapseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCollapseMenu.Visibility = Visibility.Collapsed;
            btnOpenMenu.Visibility = Visibility.Visible;
            imgLogo.Visibility = Visibility.Collapsed;
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCollapseMenu.Visibility = Visibility.Visible;
            btnOpenMenu.Visibility = Visibility.Collapsed;
            imgLogo.Visibility = Visibility.Visible;
        }

        private void lvwMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            Window ma = null;
            GridMain.Children.Clear();
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                //case "itemHome":
                //    usc = new UserControlHome();

                //    break;
                case "itemAlimentos":
                    //usc = new ingredientes.UserControlIngrediente();
                    break;

                case "itemEmpleado":
                    usc = new Empleado.EmployeeControl();
                    break;
                case "itemAgregarLibro":
                    ma = new Libros.WinNuevoLibro();
                    ma.ShowDialog();
                    break;
                case "itemPrestamo":
                    // usc = new Venta.UserControlVenta();
                    ma = new Reserva_De_Libros.WinReservarLibro();
                    ma.ShowDialog();
                    break;

            }
            
            
            if (usc != null)
                GridMain.Children.Add(usc);


        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCambiar_Click(object sender, RoutedEventArgs e)
        {
            Sesion.idSesion = 0;
            Sesion.usuarioSesion = null;
            Sesion.rolSesion = null;
            win.Visibility = Visibility.Visible;
            imgLogin.ImageSource = null;
            this.Close();


        }
    }
}
