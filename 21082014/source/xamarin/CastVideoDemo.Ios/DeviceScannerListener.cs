using System;
using GoogleCast;
using MonoTouch.Foundation;

namespace CastVideoDemo.Ios
{
	public class DeviceScannerListener : NSObject, IGCKDeviceScannerListener
	{
		CastVideoDemoIosViewController _controller;
        public DeviceScannerListener(CastVideoDemoIosViewController ctrl)
		{
			_controller = ctrl;
		}

		[Export ("deviceDidComeOnline:")]
		public void DeviceDidComeOnline (GCKDevice device)
		{
			Console.WriteLine ("Device found: {0}", device.FriendlyName);
			_controller.UpdateButtonStates ();
		}

		[Export ("deviceDidGoOffline:")]
		public void DeviceDidGoOffline (GCKDevice device)
		{
			_controller.UpdateButtonStates ();
		}
	}
}

