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

namespace CastVideoDemo.Ios
{
	[Register ("CastVideoDemoIosViewController")]
	partial class CastVideoDemoIosViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton CastButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton PauseButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton PlayButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton StopButton { get; set; }

		[Action ("CastButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void CastButton_TouchUpInside (UIButton sender);

		[Action ("PauseButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void PauseButton_TouchUpInside (UIButton sender);

		[Action ("PlayButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void PlayButton_TouchUpInside (UIButton sender);

		[Action ("StopButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void StopButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (CastButton != null) {
				CastButton.Dispose ();
				CastButton = null;
			}
			if (PauseButton != null) {
				PauseButton.Dispose ();
				PauseButton = null;
			}
			if (PlayButton != null) {
				PlayButton.Dispose ();
				PlayButton = null;
			}
			if (StopButton != null) {
				StopButton.Dispose ();
				StopButton = null;
			}
		}
	}
}
