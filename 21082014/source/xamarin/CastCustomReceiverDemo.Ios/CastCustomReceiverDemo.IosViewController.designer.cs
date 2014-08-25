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

namespace CastCustomReceiverDemo.Ios
{
	[Register ("CastCustomReceiverDemoIosViewController")]
	partial class CastCustomReceiverDemoIosViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton CastButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField MessageInput { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SendButton { get; set; }

		[Action ("CastButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void CastButton_TouchUpInside (UIButton sender);

		[Action ("SendButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void SendButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (CastButton != null) {
				CastButton.Dispose ();
				CastButton = null;
			}
			if (MessageInput != null) {
				MessageInput.Dispose ();
				MessageInput = null;
			}
			if (SendButton != null) {
				SendButton.Dispose ();
				SendButton = null;
			}
		}
	}
}
