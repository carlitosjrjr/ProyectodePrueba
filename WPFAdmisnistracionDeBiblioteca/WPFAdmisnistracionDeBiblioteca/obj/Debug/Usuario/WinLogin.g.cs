﻿#pragma checksum "..\..\..\Usuario\WinLogin.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3AC1CE8428DCDC64CCB33B1F86CFDE176A580C94"
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
using WPFAdmisnistracionDeBiblioteca.Usuario;


namespace WPFAdmisnistracionDeBiblioteca.Usuario {
    
    
    /// <summary>
    /// WinLogin
    /// </summary>
    public partial class WinLogin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\Usuario\WinLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Usuario\WinLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNombreUsuario;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Usuario\WinLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Usuario\WinLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblcorreo;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Usuario\WinLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIngresar;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Usuario\WinLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSalir;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Usuario\WinLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.Card cardInfo;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Usuario\WinLogin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbkDetalle;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFAdmisnistracionDeBiblioteca;component/usuario/winlogin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Usuario\WinLogin.xaml"
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
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\Usuario\WinLogin.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtNombreUsuario = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\Usuario\WinLogin.xaml"
            this.txtNombreUsuario.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.txtNombreUsuario_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 37 "..\..\..\Usuario\WinLogin.xaml"
            this.txtPassword.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.txtPassword_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 40 "..\..\..\Usuario\WinLogin.xaml"
            ((MaterialDesignThemes.Wpf.PackIcon)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.click_llamarContra);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblcorreo = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btnIngresar = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\Usuario\WinLogin.xaml"
            this.btnIngresar.Click += new System.Windows.RoutedEventHandler(this.btnIngresar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSalir = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\Usuario\WinLogin.xaml"
            this.btnSalir.Click += new System.Windows.RoutedEventHandler(this.btnSalir_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cardInfo = ((MaterialDesignThemes.Wpf.Card)(target));
            return;
            case 9:
            this.tbkDetalle = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

