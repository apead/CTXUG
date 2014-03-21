namespace SocialMediaAndroid
{
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Widget;

    using SocialMediaWindowsStore;

    [Activity(Label = "Main Activity", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            this.SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = this.FindViewById<Button>(Resource.Id.SocialMediaButton);

            var intent = new Intent(this, typeof(SocialMediaActivity));

            DemoFileLinking.DoSomeSharedPlatformSpecificAction(this);

            button.Click += (sender, args) => this.StartActivity(intent);
        }
    }
}

