// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace FancyPhoto
{
	[Register ("FancyPhotoViewController")]
	partial class FancyPhotoViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIButton ButtonFilter { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UIImageView FancyImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		Xamarin.Controls.AutoImageSizer ImageCrop { get; set; }

		[Action ("ButtonFilter_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void ButtonFilter_TouchUpInside (MonoTouch.UIKit.UIButton sender);

		[Action ("UIButton1_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void UIButton1_TouchUpInside (MonoTouch.UIKit.UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (ButtonFilter != null) {
				ButtonFilter.Dispose ();
				ButtonFilter = null;
			}
			if (FancyImage != null) {
				FancyImage.Dispose ();
				FancyImage = null;
			}
			if (ImageCrop != null) {
				ImageCrop.Dispose ();
				ImageCrop = null;
			}
		}
	}
}
