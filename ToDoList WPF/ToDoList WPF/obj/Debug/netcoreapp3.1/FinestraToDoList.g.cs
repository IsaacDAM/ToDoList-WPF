﻿#pragma checksum "..\..\..\FinestraToDoList.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F01D33095EE72D393AC5FEB7D59B7BBDC114A8FD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using ToDoList_WPF;


namespace ToDoList_WPF {
    
    
    /// <summary>
    /// Finestra_ToDoList
    /// </summary>
    public partial class Finestra_ToDoList : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\FinestraToDoList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotoModTasca;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\FinestraToDoList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotoGuardar;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\FinestraToDoList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BotoTreballadors;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\FinestraToDoList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LlistaToDo;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\FinestraToDoList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LlistaDoing;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\FinestraToDoList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LlistaDone;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ToDoList WPF;component/finestratodolist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\FinestraToDoList.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BotoModTasca = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\FinestraToDoList.xaml"
            this.BotoModTasca.Click += new System.Windows.RoutedEventHandler(this.BotoModTasca_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BotoGuardar = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\FinestraToDoList.xaml"
            this.BotoGuardar.Click += new System.Windows.RoutedEventHandler(this.BotoGuardar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BotoTreballadors = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\FinestraToDoList.xaml"
            this.BotoTreballadors.Click += new System.Windows.RoutedEventHandler(this.BotoTreballadors_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LlistaToDo = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.LlistaDoing = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.LlistaDone = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
