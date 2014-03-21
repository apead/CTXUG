namespace AdSoftwareSystems.Tracking.Mobile.Ios.Views
{
    using AdSoftwareSystems.Tracking.Mobile.Core.ViewModels;

    using Cirrious.MvvmCross.Binding.BindingContext;
    using Cirrious.MvvmCross.Binding.Touch.Views;
    using Cirrious.MvvmCross.Touch.Views;

    using MonoTouch.Foundation;
    using MonoTouch.ObjCRuntime;
    using MonoTouch.UIKit;

    [Register("SocialView")]
    public class SocialMediaView : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // ios7 layout
            if (this.RespondsToSelector(new Selector("edgesForExtendedLayout")))
                this.EdgesForExtendedLayout = UIRectEdge.None;

            var source = new MvxStandardTableViewSource(this.TableView, "TitleText StatusUpdate;ImageUrl Image");
            this.TableView.Source = source;

            var set = this.CreateBindingSet<SocialMediaView, SocialMediaViewModel>();
            set.Bind(source).To(vm => vm.SightingsMediaPosts);
            set.Apply();

            this.TableView.ReloadData();
        }
    }
}