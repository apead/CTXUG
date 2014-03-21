namespace AdSoftwareSystems.Tracking.Mobile.Droid.Views
{
    using AdSoftwareSystems.Tracking.Mobile.Droid;

    using Cirrious.MvvmCross.Droid.Views;

    using global::Android.App;

    [Activity(Label = "View for SocialMediaView")]
    public class SocialMediaView : MvxActivity
    {
        protected override void OnCreate(global::Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.SocialMediaView);
        }
    }
}