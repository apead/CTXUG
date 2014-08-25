using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CastVideoDemo.Ios
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // CHANGE RECEIVER APP ID

        public static string ReceiverApplicationId = "[Insert App ID Here]";

        public override UIWindow Window
        {
            get;
            set;
        }

        public override void OnResignActivation(UIApplication application)
        {
        }

        public override void DidEnterBackground(UIApplication application)
        {
        }

        public override void WillEnterForeground(UIApplication application)
        {
        }

        public override void WillTerminate(UIApplication application)
        {
        }
    }
}