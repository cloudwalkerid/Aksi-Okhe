﻿#pragma checksum "..\..\..\3.1. Client-Login\Database.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9836BBE71E03B3FABAA5B872320A82DC2FC12A1981D064F97ADB26C89E8256F9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Akhi_Okhee._3._1._Client_Login;
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


namespace Akhi_Okhee._3._1._Client_Login {
    
    
    /// <summary>
    /// Database
    /// </summary>
    public partial class Database : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\3.1. Client-Login\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ip_server;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\3.1. Client-Login\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox database;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\3.1. Client-Login\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox username;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\3.1. Client-Login\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox password;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\3.1. Client-Login\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Simpan_button;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\3.1. Client-Login\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button konfigurasi;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\3.1. Client-Login\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backup;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\3.1. Client-Login\Database.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button restore;
        
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
            System.Uri resourceLocater = new System.Uri("/Akhi Okhee;component/3.1.%20client-login/database.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\3.1. Client-Login\Database.xaml"
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
            this.ip_server = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\3.1. Client-Login\Database.xaml"
            this.ip_server.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.ip_server_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.database = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.username = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.password = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            
            #line 23 "..\..\..\3.1. Client-Login\Database.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.tes_koneksi);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Simpan_button = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\3.1. Client-Login\Database.xaml"
            this.Simpan_button.Click += new System.Windows.RoutedEventHandler(this.simpan);
            
            #line default
            #line hidden
            return;
            case 7:
            this.konfigurasi = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\3.1. Client-Login\Database.xaml"
            this.konfigurasi.Click += new System.Windows.RoutedEventHandler(this.aksi_konfigure_buat);
            
            #line default
            #line hidden
            return;
            case 8:
            this.backup = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\3.1. Client-Login\Database.xaml"
            this.backup.Click += new System.Windows.RoutedEventHandler(this.aksi_database_backup);
            
            #line default
            #line hidden
            return;
            case 9:
            this.restore = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\3.1. Client-Login\Database.xaml"
            this.restore.Click += new System.Windows.RoutedEventHandler(this.aksi_database_restore);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

