using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPages.Tests
{
    using System;
    using NUnit.Framework;
    using Xamarin.UITest;
    using Xamarin.UITest.Android;
    [TestFixture]
    public class RecorderTest
    {
        public AndroidApp app;
        [SetUp]
        public void Setup()
        {
            app = ConfigureApp.Android.ApkFile("C:\\work\\samples\\xamarin-forms-samples\\Pages\\DataPagesDemo\\Droid\\bin\\Release\\com.companyname.datapagesdemo-Signed.apk").StartApp();
        }

        [Test]
        public void NewTest()
        {
            app.ScrollDown();
            app.Screenshot("Swiped up");
            app.Tap(x => x.Class("FormsImageView").Index(1));
            app.Screenshot("Tapped on view with class: FormsImageView");
            app.ScrollDown();
            app.Screenshot("Swiped up");
            app.ScrollDown();
            app.Screenshot("Swiped up");
            app.Tap(x => x.Marked("Navigate up"));
            app.Screenshot("Tapped on view with class: ImageButton marked: Navigate up");
            app.ScrollDownTo("Google Fit, Android Wear, and Xamarin");
            app.Screenshot("ScrollToEvent[AppView: Class=Xamarin.TestRecorder.Portable.Models.Class, Id=, Text=Google Fit, Android Wear, and Xamarin, Marked=, Css=, XPath=, IndexInTree=0, Rect=[Rectangle: Left=0, Top=0, CenterX=657, CenterY=1519, Width=1118, Height=90, Bottom=1564, Right=1216]]");
            app.Tap(x => x.Text("Google Fit, Android Wear, and Xamarin"));
            app.Screenshot("Tapped on view with class: FormsTextView");
            app.ScrollDown();
            app.Screenshot("Swiped up");
            app.Tap(x => x.Marked("Navigate up"));
            app.Screenshot("Tapped on view with class: ImageButton marked: Navigate up");
            app.ScrollDownTo("Best Practices for Effective iOS Memory Management");
            app.Screenshot("ScrollToEvent[AppView: Class=Xamarin.TestRecorder.Portable.Models.Class, Id=, Text=Best Practices for Effective iOS Memory Management, Marked=, Css=, XPath=, IndexInTree=0, Rect=[Rectangle: Left=0, Top=0, CenterX=720, CenterY=1505, Width=1244, Height=168, Bottom=1589, Right=1342]]");
            app.Tap(x => x.Text("Best Practices for Effective iOS Memory Management"));
            app.Screenshot("Tapped on view with class: FormsTextView");
            app.ScrollDown();
            app.Screenshot("Swiped up");
            app.Tap(x => x.Marked("Navigate up"));
            app.Screenshot("Tapped on view with class: ImageButton marked: Navigate up");
        }

    }

}
