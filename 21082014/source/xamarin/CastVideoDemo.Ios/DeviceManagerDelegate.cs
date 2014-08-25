using System;
using GoogleCast;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CastVideoDemo.Ios
{
	public class DeviceManagerDelegate : NSObject, IGCKDeviceManagerDelegate
	{
		private CastVideoDemoIosViewController _controller;

        public DeviceManagerDelegate(CastVideoDemoIosViewController ctrl) 
		{
			_controller = ctrl;
		}

		[Export ("deviceManagerDidConnect:")]
		public void DidConnect (GCKDeviceManager deviceManager)
		{
			Console.WriteLine ("Connected!!");
			_controller.UpdateButtonStates ();
			_controller.DeviceManager.LaunchApplication (AppDelegate.ReceiverApplicationId);
		}

		[Export ("deviceManager:didConnectToCastApplication:sessionID:launchedApplication:")]
		public void DidConnectToCastApplication (GCKDeviceManager deviceManager, GCKApplicationMetadata applicationMetadata, string sessionId, bool launchedApplication)
		{
			Console.WriteLine ("Application has launched");
			_controller.MediaControlChannel = new GCKMediaControlChannel {Delegate = new GCKMediaControlChannelDelegate()};
		    _controller.DeviceManager.AddChannel (_controller.MediaControlChannel);
			_controller.MediaControlChannel.RequestStatus ();

			_controller.SessionId = sessionId;
		}

		[Export ("deviceManager:didFailToConnectToApplicationWithError:")]
		public void DidFailToConnectToApplication (GCKDeviceManager deviceManager, NSError error)
		{
			ShowError (error);
			_controller.DeviceDisconnected ();
			_controller.UpdateButtonStates ();
		}

		[Export ("deviceManager:didFailToConnectWithError:")]
		public void DidFailToConnect (GCKDeviceManager deviceManager, NSError error)
		{
			ShowError (error);
			_controller.DeviceDisconnected ();
			_controller.UpdateButtonStates ();
		}

		[Export ("deviceManager:didDisconnectWithError:")]
		public void DidDisconnect (GCKDeviceManager deviceManager, NSError error)
		{
			Console.WriteLine ("Received notification that device disconnected");
			if (error != null)
				ShowError (error);

			_controller.DeviceDisconnected ();
			_controller.UpdateButtonStates ();
		}

		[Export ("deviceManager:didReceiveStatusForApplication:")]
		public void DidReceiveStatus (GCKDeviceManager deviceManager, GCKApplicationMetadata applicationMetadata)
		{
			_controller.AppMetadata = applicationMetadata;
		}

		void ShowError (NSError error)
		{
			InvokeOnMainThread (() => new UIAlertView ("Error:", error.Description, null, "Ok", null).Show());
		}
	}
}

