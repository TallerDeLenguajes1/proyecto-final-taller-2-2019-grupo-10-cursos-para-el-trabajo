﻿#pragma checksum "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6D55024643D34816F30D95C7F2CFB2CA0E4488CF9B90BBC43538A0AFC7BFBB80"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using AplicacionPrincipal.Vistas.VistasBeneficiario;
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


namespace AplicacionPrincipal.Vistas.VistasBeneficiario {
    
    
    /// <summary>
    /// MenuBeneficiario
    /// </summary>
    public partial class MenuBeneficiario : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitulo;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxBeneficiarios;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblListaBeneficiario;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAltaBeneficiario;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModificarBeneficiario;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminarBeneficiario;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSalir;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReporte;
        
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
            System.Uri resourceLocater = new System.Uri("/AplicacionPrincipal;component/vistas/vistasbeneficiario/menubeneficiario.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
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
            this.lblTitulo = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lbxBeneficiarios = ((System.Windows.Controls.ListBox)(target));
            
            #line 34 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
            this.lbxBeneficiarios.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbxBeneficiarios_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblListaBeneficiario = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btnAltaBeneficiario = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
            this.btnAltaBeneficiario.Click += new System.Windows.RoutedEventHandler(this.btnAltaBeneficiario_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnModificarBeneficiario = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
            this.btnModificarBeneficiario.Click += new System.Windows.RoutedEventHandler(this.btnModificarBeneficiario_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnEliminarBeneficiario = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
            this.btnEliminarBeneficiario.Click += new System.Windows.RoutedEventHandler(this.btnEliminarBeneficiario_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSalir = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
            this.btnSalir.Click += new System.Windows.RoutedEventHandler(this.btnSalir_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnReporte = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\Vistas\VistasBeneficiario\MenuBeneficiario.xaml"
            this.btnReporte.Click += new System.Windows.RoutedEventHandler(this.btnReporte_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

