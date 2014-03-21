namespace AdSoftwareSystems.Tracking.Mobile.Ios
{
    using Cirrious.CrossCore;
    using Cirrious.MvvmCross.Touch.Platform;
    using Cirrious.MvvmCross.Touch.Views.Presenters;
    using Cirrious.MvvmCross.ViewModels;

    using MonoTouch.Foundation;
    using MonoTouch.UIKit;

    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        UIWindow _window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            this._window = new UIWindow(UIScreen.MainScreen.Bounds);

            var presenter = new MvxTouchViewPresenter(this, this._window);
            var setup = new Setup(this, presenter);
            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            this._window.MakeKeyAndVisible();

            return true;
        }
    }
}