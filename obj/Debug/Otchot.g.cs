﻿#pragma checksum "..\..\Otchot.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B51481EA396DA49BECDC062BD2D161E1DAEFC94E7C9F17E392FB79A20ADA02E9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseLibrary;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace CourseLibrary {
    
    
    /// <summary>
    /// Otchot
    /// </summary>
    public partial class Otchot : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\Otchot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Printers;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Otchot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frmPrinter;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Otchot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button student;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\Otchot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button books;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Otchot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button accounting;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Otchot.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Printer;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseLibrary;component/otchot.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Otchot.xaml"
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
            this.Printers = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.frmPrinter = ((System.Windows.Controls.Frame)(target));
            return;
            case 3:
            this.student = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\Otchot.xaml"
            this.student.Click += new System.Windows.RoutedEventHandler(this.student_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.books = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\Otchot.xaml"
            this.books.Click += new System.Windows.RoutedEventHandler(this.books_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.accounting = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\Otchot.xaml"
            this.accounting.Click += new System.Windows.RoutedEventHandler(this.accounting_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Printer = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\Otchot.xaml"
            this.Printer.Click += new System.Windows.RoutedEventHandler(this.Printer_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

