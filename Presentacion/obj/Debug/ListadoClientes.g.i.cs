﻿#pragma checksum "..\..\ListadoClientes.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E6C75896825C52BE0FFF323356F0F1650534AFC6D2FBF0C2602A301DF28468DD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using OnBreakEventos;
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


namespace OnBreakEventos {
    
    
    /// <summary>
    /// ListadoClientes
    /// </summary>
    public partial class ListadoClientes : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_clientes;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_filtro;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmb_tipoFiltro;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_filtro;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_refrescarContratos;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\ListadoClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_seleccionar;
        
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
            System.Uri resourceLocater = new System.Uri("/OnBreakEventos;component/listadoclientes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ListadoClientes.xaml"
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
            this.dg_clientes = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.lbl_filtro = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.cmb_tipoFiltro = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.txt_filtro = ((System.Windows.Controls.TextBox)(target));
            
            #line 42 "..\..\ListadoClientes.xaml"
            this.txt_filtro.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Txt_filtro_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_refrescarContratos = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\ListadoClientes.xaml"
            this.btn_refrescarContratos.Click += new System.Windows.RoutedEventHandler(this.Btn_refrescarContratos_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_seleccionar = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\ListadoClientes.xaml"
            this.btn_seleccionar.Click += new System.Windows.RoutedEventHandler(this.Btn_seleccionar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

