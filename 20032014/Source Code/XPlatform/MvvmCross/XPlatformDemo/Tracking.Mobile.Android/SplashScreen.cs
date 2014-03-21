namespace AdSoftwareSystems.Tracking.Mobile.Droid
{
    using Cirrious.MvvmCross.Droid.Views;

    using global::Android.App;
    using global::Android.Content.PM;

    [Activity(
		Label = "AdSoftwareSystems.Tracking.Mobile.Android"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}