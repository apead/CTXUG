namespace AdSoftwareSystems.Tracking.Mobile.Droid
{
    using AdSoftwareSystems.Tracking.Mobile.Android;

    using Cirrious.CrossCore.Platform;
    using Cirrious.MvvmCross.Droid.Platform;
    using Cirrious.MvvmCross.ViewModels;

    using global::Android.Content;

    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}