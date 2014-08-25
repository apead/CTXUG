using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using GoogleCast;

namespace GoogleCastiOSSample
{
	public class DeviceManagerDelegate : NSObject, IGCKDeviceManagerDelegate
	{
		CastViewController viewCtrl;

		public DeviceManagerDelegate (CastViewController ctrl) 
		{
			viewCtrl = ctrl;
		}

		[Export ("deviceManagerDidConnect:")]
		public void DidConnect (GoogleCast.GCKDeviceManager deviceManager)
		{
			Console.WriteLine ("Connected!!");
			viewCtrl.UpdateButtonStates ();
			viewCtrl.DeviceManager.LaunchApplication (AppDelegate.ReceiverApplicationId);
		}

		[Export ("deviceManager:didConnectToCastApplication:sessionID:launchedApplication:")]
		public void DidConnectToCastApplication (GoogleCast.GCKDeviceManager deviceManager, GoogleCast.GCKApplicationMetadata applicationMetadata, string sessionId, bool launchedApplication)
		{
			Console.WriteLine ("Application has launched");
			viewCtrl.MediaControlChannel = new GCKMediaControlChannel ();
			viewCtrl.MediaControlChannel.Delegate = new GCKMediaControlChannelDelegate ();
			viewCtrl.DeviceManager.AddChannel (viewCtrl.MediaControlChannel);
			viewCtrl.MediaControlChannel.RequestStatus ();

			viewCtrl.SessionId = sessionId;
		}

		[Export ("deviceManager:didFailToConnectToApplicationWithError:")]
		public void DidFailToConnectToApplication (GoogleCast.GCKDeviceManager deviceManager, MonoTouch.Foundation.NSError error)
		{
			ShowError (error);
			viewCtrl.DeviceDisconnected ();
			viewCtrl.UpdateButtonStates ();
		}

		[Export ("deviceManager:didFailToConnectWithError:")]
		public void DidFailToConnect (GoogleCast.GCKDeviceManager deviceManager, MonoTouch.Foundation.NSError error)
		{
			ShowError (error);
			viewCtrl.DeviceDisconnected ();
			viewCtrl.UpdateButtonStates ();
		}

		[Export ("deviceManager:didDisconnectWithError:")]
		public void DidDisconnect (GoogleCast.GCKDeviceManager deviceManager, MonoTouch.Foundation.NSError error)
		{
			Console.WriteLine ("Received notification that device disconnected");
			if (error != null)
				ShowError (error);

			viewCtrl.DeviceDisconnected ();
			viewCtrl.UpdateButtonStates ();
		}

		[Export ("deviceManager:didReceiveStatusForApplication:")]
		public void DidReceiveStatus (GoogleCast.GCKDeviceManager deviceManager, GoogleCast.GCKApplicationMetadata applicationMetadata)
		{
			viewCtrl.AppMetadata = applicationMetadata;
		}

		void ShowError (NSError error)
		{
			InvokeOnMainThread (() => new UIAlertView ("Error:", error.Description, null, "Ok", null).Show());
		}
	}
}

