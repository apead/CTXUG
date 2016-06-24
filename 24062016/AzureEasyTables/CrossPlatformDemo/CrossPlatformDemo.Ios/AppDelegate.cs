using CrossPlatformDemo.Core;
using CrossPlatformDemo.Core.Views;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace CrossPlatformDemo.Ios
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var tint = UIColor.FromRGB(255, 255, 255);
            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB(0, 148, 242); //bar background
            UINavigationBar.Appearance.TintColor = tint; //Tint color of button items
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                Font = UIFont.FromName("Avenir-Medium", 17f),
                TextColor = UIColor.Black
            });

            UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes
            {
                Font = UIFont.FromName("Avenir-Medium", 17f),
                ForegroundColor = UIColor.Black
            };

            UIBarButtonItem.Appearance.TintColor = tint; //Tint color of button items

            UIBarButtonItem.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                Font = UIFont.FromName("Avenir-Medium", 17f),
                TextColor = tint
            },
                UIControlState.Normal);

            UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes
            {
                Font = UIFont.FromName("Avenir-Book", 10f)
            }, UIControlState.Normal);

            UITabBar.Appearance.TintColor = tint;

            UISwitch.Appearance.OnTintColor = tint;

            global::Xamarin.Forms.Forms.Init();

            var app = new App();
            app.MainPage = new NavigationPage(new DotNetDevicesView());
            LoadApplication(app);

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            SQLitePCL.CurrentPlatform.Init();
            return base.FinishedLaunching(application, launchOptions);
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }
    }
}


