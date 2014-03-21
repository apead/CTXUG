  #if __ANDROID__
using Android.Widget;
using Android.App;
#endif

  #if __IOS__
using Xamarin.Controls;
#endif

namespace SocialMediaWindowsStore
{

    public class DemoFileLinking
    {
        public static void DoSomeSharedPlatformSpecificAction(object handle)
        {
            #if __ANDROID__
                // Android-specific code
                        var activty = handle as Activity;
                       var toast = Toast.MakeText(activty, "Application Started", ToastLength.Short);
                    toast.Show();
           #endif

              #if __IOS__
                // ios specific code
                AlertCenter.Default.PostMessage("Application Started", string.Empty);
            #endif
        }
    }
}
