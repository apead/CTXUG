using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CrossPlatformDemo.Core;
using CrossPlatformDemo.Core.Views;

namespace CrossPlatformDemo.Droid
{
    [Activity(Label = "Where is .NET?", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
           FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            var app = new App();
            app.MainPage = new NavigationPage(new DotNetDevicesView())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#0094f2")
            };
            LoadApplication(app);
        }
    }
}

