﻿#pragma checksum "..\..\..\..\..\Vistas\VistasEmpresa\VistaContratacion\ABMAltaContratacion.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E4D607789EB115C3785D72DCA5FB22562CF5DC830DD67479057714912DDDD144"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using AplicacionPrincipal.Vistas.VistasEmpresa.VistaContratacion;
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


namespace AplicacionPrincipal.Vistas.VistasEmpresa.VistaContratacion {
    
    
    /// <summary>
    /// ABMAltaContratacion
    /// </summary>
    public partial class ABMAltaContratacion : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\..\Vistas\VistasEmpresa\VistaContratacion\ABMAltaContratacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTitulo;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\Vistas\VistasEmpresa\VistaContratacion\ABMAltaContratacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxCandidatos;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\Vistas\VistasEmpresa\VistaContratacion\ABMAltaContratacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblListaCandidatos;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\Vistas\VistasEmpresa\VistaContratacion\ABMAltaContratacion.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAceptar;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Vistas\VistasEmpresa\VistaContratacion\ABMAltaContratacion.xaml"
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
            System.Uri resourceLocater = new System.Uri("/AplicacionPrincipal;component/vistas/vistasempresa/vistacontratacion/abmaltacont" +
                    "ratacion.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Vistas\VistasEmpresa\VistaContratacion\ABMAltaContratacion.xaml"
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
            this.lbxCandidatos = ((System.Windows.Controls.ListBox)(target));
            
            #line 25 "..\..\..\..\..\Vistas\VistasEmpresa\VistaContratacion\ABMAltaContratacion.xaml"
            this.lbxCandidatos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LbxCandidatos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblListaCandidatos = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btnAceptar = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\..\Vistas\VistasEmpresa\VistaContratacion\ABMAltaContratacion.xaml"
            this.btnAceptar.Click += new System.Windows.RoutedEventHandler(this.BtnAceptar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\..\Vistas\VistasEmpresa\VistaContratacion\ABMAltaContratacion.xaml"
            this.btnCancelar.Click += new System.Windows.RoutedEventHandler(this.BtnCancelar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

