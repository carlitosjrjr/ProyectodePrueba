﻿#pragma checksum "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A1598BCBBB22268A4FA64F4CC255841B09B20F49"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WPFAdmisnistracionDeBiblioteca.Reserva_De_Libros;


namespace WPFAdmisnistracionDeBiblioteca.Reserva_De_Libros {
    
    
    /// <summary>
    /// WinReservarLibro
    /// </summary>
    public partial class WinReservarLibro : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBusquedaNombre;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtgData;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtglibros;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReserva;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFAdmisnistracionDeBiblioteca;component/reserva_de_libros/winreservarlibro.xaml" +
                    "", System.UriKind.Relative);
            
            #line 1 "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml"
            ((WPFAdmisnistracionDeBiblioteca.Reserva_De_Libros.WinReservarLibro)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtBusquedaNombre = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml"
            this.txtBusquedaNombre.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtBusquedaNombre_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dtgData = ((System.Windows.Controls.DataGrid)(target));
            
            #line 37 "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml"
            this.dtgData.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dtgData_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dtglibros = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btnReserva = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml"
            this.btnReserva.Click += new System.Windows.RoutedEventHandler(this.btnReserva_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnEliminar = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\Reserva_De_Libros\WinReservarLibro.xaml"
            this.btnEliminar.Click += new System.Windows.RoutedEventHandler(this.btnEliminar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

