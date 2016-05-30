using Acr.UserDialogs;
using Android.App;
using Android.OS;
using FormsMapsSample.Core.Views;
using Xamarin.Forms.Platform.Android;

namespace FormsMapsSample.Droid
{
    [Activity(Label = "Where is Disney?", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : FormsApplicationActivity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            UserDialogs.Init(() => (Activity)Xamarin.Forms.Forms.Context);

            Xamarin.FormsMaps.Init(this, bundle);

            var app = new Core.App();
            app.MainPage = new MapView();
            LoadApplication(app);
        }
    }
}

