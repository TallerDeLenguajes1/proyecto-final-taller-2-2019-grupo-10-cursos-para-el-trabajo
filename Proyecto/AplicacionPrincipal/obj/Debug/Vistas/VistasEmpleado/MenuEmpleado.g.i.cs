﻿#pragma checksum "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7D906380A12477AEAB35CC7795391036B7369E70CA169FA2EE511564583896B1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using AplicacionPrincipal.Vistas.VistasEmpleado;
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


namespace AplicacionPrincipal.Vistas.VistasEmpleado {
    
    
    /// <summary>
    /// MenuEmpleado
    /// </summary>
    public partial class MenuEmpleado : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitulo;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxEmpleados;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblListaEmpleado;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAltaEmpleado;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModificarEmpleado;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEliminarEmpleado;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSalir;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
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
            System.Uri resourceLocater = new System.Uri("/AplicacionPrincipal;component/vistas/vistasempleado/menuempleado.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
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
            this.lbxEmpleados = ((System.Windows.Controls.ListBox)(target));
            
            #line 25 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
            this.lbxEmpleados.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lbxEmpleados_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblListaEmpleado = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btnAltaEmpleado = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
            this.btnAltaEmpleado.Click += new System.Windows.RoutedEventHandler(this.btnAltaEmpleado_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnModificarEmpleado = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
            this.btnModificarEmpleado.Click += new System.Windows.RoutedEventHandler(this.btnModificarEmpleado_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnEliminarEmpleado = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
            this.btnEliminarEmpleado.Click += new System.Windows.RoutedEventHandler(this.btnEliminarEmpleado_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSalir = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
            this.btnSalir.Click += new System.Windows.RoutedEventHandler(this.btnSalir_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnReporte = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\..\Vistas\VistasEmpleado\MenuEmpleado.xaml"
            this.btnReporte.Click += new System.Windows.RoutedEventHandler(this.btnReporte_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

