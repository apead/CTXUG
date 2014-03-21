using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SocialMediaiOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;
        LandingScreen viewController;

        private UINavigationController navigationController;


        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            navigationController = new UINavigationController();
            viewController = new LandingScreen();


            navigationController.PushViewController(viewController,true);

            window.RootViewController = navigationController;

            window.MakeKeyAndVisible();

            return true;
        }
    }
}

