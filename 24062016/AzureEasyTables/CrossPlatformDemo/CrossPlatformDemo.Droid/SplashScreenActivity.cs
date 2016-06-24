using Android.App;
using Android.Content;
using Android.OS;

namespace CrossPlatformDemo.Droid
{
    [Activity(Label = "Where is .NET?", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash")]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }
    }
}

