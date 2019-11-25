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

namespace WPFAdmisnistracionDeBiblioteca.Empleado
{
    /// <summary>
    /// Lógica de interacción para EmployeeControl.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl
    {
        
        public EmployeeControl()
        {
            InitializeComponent();
        }

        private void cardAdmNuevosEmpleados_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WinNuevoEmpleado win = new WinNuevoEmpleado();
            win.ShowDialog();
        }

        private void cardAdmEmpleados_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (Sesion.rolSesion == "Administrado")
           // {
                WinAdmEmpleado win = new WinAdmEmpleado();
                win.ShowDialog();
           // }
            
        }

        private void cardAdmNuevosUsuarios_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WinNuevoUsuario win = new WinNuevoUsuario();
            win.ShowDialog();
        }
    }
}
