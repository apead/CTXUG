﻿

#pragma checksum "C:\Work\projects\ctxug\20032014\XPlatform\MvvmCross\XPlatformDemo\Tracking.Mobile.Store\Views\SocialMediaView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "66BC16E81DF689C77F16E359275A7F2B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdSoftwareSystems.Tracking.Mobile.Store.Views
{
    partial class SocialMediaView : global::AdSoftwareSystems.Tracking.Mobile.Store.Common.LayoutAwarePage, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 61 "..\..\Views\SocialMediaView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.ItemListView_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 44 "..\..\Views\SocialMediaView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoBack;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


