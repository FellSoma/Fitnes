﻿#pragma checksum "..\..\SiningMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E503DB58FC31C8B4C241BAFD6865A8D8946E0B1378E7C3C4155ABBEEE694EF43"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Fitnes;
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


namespace Fitnes {
    
    
    /// <summary>
    /// SiningMenu
    /// </summary>
    public partial class SiningMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 100 "..\..\SiningMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ToolBar;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\SiningMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Login;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\SiningMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBx;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\SiningMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TestDataGrid;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\SiningMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock WaterMark;
        
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
            System.Uri resourceLocater = new System.Uri("/Fitnes;component/siningmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SiningMenu.xaml"
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
            
            #line 15 "..\..\SiningMenu.xaml"
            ((Fitnes.SiningMenu)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 15 "..\..\SiningMenu.xaml"
            ((Fitnes.SiningMenu)(target)).Activated += new System.EventHandler(this.Window_Activated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ToolBar = ((System.Windows.Controls.Grid)(target));
            
            #line 101 "..\..\SiningMenu.xaml"
            this.ToolBar.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ToolBar_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 110 "..\..\SiningMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.close);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 118 "..\..\SiningMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.windowState);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Login = ((System.Windows.Controls.TextBox)(target));
            
            #line 147 "..\..\SiningMenu.xaml"
            this.Login.FocusableChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.emptyMethod);
            
            #line default
            #line hidden
            return;
            case 6:
            this.passwordBx = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 158 "..\..\SiningMenu.xaml"
            this.passwordBx.PasswordChanged += new System.Windows.RoutedEventHandler(this.onPasswordChenged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 170 "..\..\SiningMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.entrance);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 174 "..\..\SiningMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Loading);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TestDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.WaterMark = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

