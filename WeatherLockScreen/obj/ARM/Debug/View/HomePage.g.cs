﻿#pragma checksum "C:\Users\Avi\git\WeatherLockScreenApp\WeatherLockScreen\View\HomePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "539B25BF00DAD09B3657AC63BE66D0E1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeatherLockScreen.View
{
    partial class HomePage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.MainGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 2:
                {
                    this.LoadingInfo = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3:
                {
                    this.TurnOnLocationPopup = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 4:
                {
                    this.TurnOnLocationPopupButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 42 "..\..\..\View\HomePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.TurnOnLocationPopupButton).Click += this.TurnOnLocationPopupButton_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.GetWeatherButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 31 "..\..\..\View\HomePage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.GetWeatherButton).Click += this.GetWeatherButton_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.GetWeatherProgressBar = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            case 7:
                {
                    this.LockScreenSettingsLink = (global::Windows.UI.Xaml.Controls.HyperlinkButton)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

