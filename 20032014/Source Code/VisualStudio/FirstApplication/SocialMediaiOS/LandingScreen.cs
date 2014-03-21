using System;
using System.Drawing;

using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace SocialMediaiOS
{
    using MonoTouch.CoreGraphics;

    using SocialMediaWindowsStore;

    public class LandingScreen : UIViewController
    {
        private UIButton manualButton;
        private UIButton designedButton;

        private ManualSocialMediaScreen manualSocialMediaScreen;
		private DesignerSocialMediaScreen designerSocialMediaScreen;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            DemoFileLinking.DoSomeSharedPlatformSpecificAction(null);

            View.Frame = UIScreen.MainScreen.Bounds;

            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            manualButton = UIButton.FromType(UIButtonType.RoundedRect);

            manualButton.Frame = new RectangleF(
                View.Frame.Width / 2 - 200 / 2,
                150,
                200,
                30);

            manualButton.SetTitle("Manual Design", UIControlState.Normal);
            manualButton.Layer.BorderWidth = 2f;
            manualButton.Layer.CornerRadius = 10;
            manualButton.Layer.BorderColor = manualButton.TitleColor(UIControlState.Normal).CGColor;


            manualButton.TouchUpInside += (sender, e) =>
            {
                if (manualSocialMediaScreen == null)
                { manualSocialMediaScreen = new ManualSocialMediaScreen(); }
                NavigationController.PushViewController(manualSocialMediaScreen, true);
            };


            View.AddSubview(manualButton);


            designedButton = UIButton.FromType(UIButtonType.RoundedRect);

            designedButton.Frame = new RectangleF(
                View.Frame.Width / 2 - 200 / 2,
                250,
                200,
                30);

            designedButton.SetTitle("Designer Design", UIControlState.Normal);
            designedButton.Layer.BorderWidth = 2f;
            designedButton.Layer.CornerRadius = 10;
            designedButton.Layer.BorderColor = manualButton.TitleColor(UIControlState.Normal).CGColor;

			designedButton.TouchUpInside += (sender, e) => {
				if (designerSocialMediaScreen == null) {
					designerSocialMediaScreen = new DesignerSocialMediaScreen ();
				}
				NavigationController.PushViewController (designerSocialMediaScreen, true);
			};


            View.AddSubview(designedButton);
         
        }
    }
}