using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using GoogleCast;

namespace GoogleCastiOSSample
{
	public class DeviceScannerListener : NSObject, IGCKDeviceScannerListener
	{
		CastViewController viewCtrl;
		public DeviceScannerListener (CastViewController ctrl)
		{
			viewCtrl = ctrl;
		}

		[Export ("deviceDidComeOnline:")]
		public void DeviceDidComeOnline (GCKDevice device)
		{
			Console.WriteLine ("Device found: {0}", device.FriendlyName);
			viewCtrl.UpdateButtonStates ();
		}

		[Export ("deviceDidGoOffline:")]
		public void DeviceDidGoOffline (GoogleCast.GCKDevice device)
		{
			viewCtrl.UpdateButtonStates ();
		}
	}
}

