namespace AdSoftwareSystems.Tracking.Mobile.Ios
{
    using Cirrious.MvvmCross.Touch.Platform;
    using Cirrious.MvvmCross.Touch.Views.Presenters;

    public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
			: base(applicationDelegate, presenter)
		{
		}

		protected override Cirrious.MvvmCross.ViewModels.IMvxApplication CreateApp ()
		{
            return new Core.App();
		}
	}
}