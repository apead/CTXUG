using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreImage;
using System.Threading.Tasks;

namespace FancyPhoto
{
	public partial class FancyPhotoViewController : UIViewController
	{
		public FancyPhotoViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		async public  override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion
	
		async partial void UIButton1_TouchUpInside (UIButton sender)
		{
			var picker = new UIImagePickerController();

			picker.FinishedPickingMedia += async (sender2, e) => 
			{
				await DismissViewControllerAsync(true);
				var image = e.OriginalImage;
				ImageCrop.Image = image;

			};

			await PresentViewControllerAsync(picker, true);

		}

		async partial void ButtonFilter_TouchUpInside (UIButton sender)
		{
			ImageCrop.SepiaFilter = !ImageCrop.SepiaFilter;


		}

	}
}

