﻿#pragma checksum "..\..\..\Libros\WinNuevoLibro.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2D110DBA2FCA084554DF107EDD539FC8503C6164"
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
using WPFAdmisnistracionDeBiblioteca.Libros;


namespace WPFAdmisnistracionDeBiblioteca.Libros {
    
    
    /// <summary>
    /// WinNuevoLibro
    /// </summary>
    public partial class WinNuevoLibro : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Libros\WinNuevoLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbkTItulo;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Libros\WinNuevoLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Libros\WinNuevoLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTitulo;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Libros\WinNuevoLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAutor;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Libros\WinNuevoLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txtAnoPublicacion;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Libros\WinNuevoLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIsbn;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\Libros\WinNuevoLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txtFechaRegistro;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Libros\WinNuevoLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFotografia;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Libros\WinNuevoLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgPersona;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Libros\WinNuevoLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGuardar;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\Libros\WinNuevoLibro.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFAdmisnistracionDeBiblioteca;component/libros/winnuevolibro.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Libros\WinNuevoLibro.xaml"
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
            this.tbkTItulo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Libros\WinNuevoLibro.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtTitulo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtAutor = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtAnoPublicacion = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.txtIsbn = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtFechaRegistro = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.btnFotografia = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\Libros\WinNuevoLibro.xaml"
            this.btnFotografia.Click += new System.Windows.RoutedEventHandler(this.btnFotografia_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.imgPersona = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.btnGuardar = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\Libros\WinNuevoLibro.xaml"
            this.btnGuardar.Click += new System.Windows.RoutedEventHandler(this.btnGuardar_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\Libros\WinNuevoLibro.xaml"
            this.btnCancelar.Click += new System.Windows.RoutedEventHandler(this.btnCancelar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

