﻿#pragma checksum "C:\Users\arnau\Source\Repos\smartchuwp-aout2\smartchUWP\View\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2CD828EC01C582998B6D70EB43882509"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace smartchUWP.View
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // View\MainPage.xaml line 16
                {
                    this.NavView = (global::Windows.UI.Xaml.Controls.NavigationView)(target);
                }
                break;
            case 3: // View\MainPage.xaml line 89
                {
                    this.ContentFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 4: // View\MainPage.xaml line 66
                {
                    this.FadeIn = (global::Microsoft.Toolkit.Uwp.UI.Animations.Behaviors.Fade)(target);
                }
                break;
            case 5: // View\MainPage.xaml line 67
                {
                    this.FadeOut = (global::Microsoft.Toolkit.Uwp.UI.Animations.Behaviors.Fade)(target);
                }
                break;
            case 6: // View\MainPage.xaml line 79
                {
                    this.errorMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

