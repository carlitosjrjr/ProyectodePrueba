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

namespace WPFAdmisnistracionDeBiblioteca.Libros
{
    /// <summary>
    /// Lógica de interacción para WinAdmLibros.xaml
    /// </summary>
    public partial class WinAdmLibros : Window
    {
        /// <summary>
        /// propiedad libro
        /// </summary>
        Common.Libros lib;

        /// <summary>
        /// intancia  de brl libro
        /// </summary>
        BRL.LibroBRL libbrl;

        public WinAdmLibros()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga los datos de del en el DataGrid
        /// </summary>
        private void LoadDataGridUsuario()
        {
            try
            {
                if (txtBusquedaNombre.Text != string.Empty && txtBusquedaNombre.Text.Length > 2)
                {
                    libbrl = new BRL.LibroBRL();
                    //dtgData.ItemsSource = BRL.LibroBRL.SelectFullNameUsuario(txtBusquedaNombre.Text).DefaultView;
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
                    //ClearDataEmpleado();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbOpcion_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtBusquedaNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dtgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mitModificar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mitDarBaja_Click(object sender, RoutedEventArgs e)
        {

        }
    }

   
}
