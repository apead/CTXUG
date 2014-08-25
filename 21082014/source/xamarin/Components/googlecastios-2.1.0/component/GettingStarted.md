The Google Cast SDK uses the delegation pattern to inform the application of events and to move between various states of the Cast app life cycle.

### Application flow

The following sections cover the details of the typical execution flow for a sender application:

* Scan for devices
* Select device
* Launch application
* Work with media channels
* Load the media

### Scan for devices

In this step, the sender application searches the WiFi network for Google Cast receiver devices. This involves instantiating a device scanner, a delegate, and starting the scan. As the scanner discovers devices, it notifies the application via the delegate.

A Google Cast receiver device is represented by a `GCKDevice` class, which contains attributes like the device's IP address, friendly display name, model and manufacturer, and a URL to the device's display icon.

Typically, an application will run a scan for a fixed amount of time (for example, 5 seconds), and display a list of discovered devices to the user. The user will then select the device they wish to interact with from this list.

To scan for cast enabled devices you must define a device scanner and register the delegate, then start scanning.

**Device scanner**

```csharp
using GoogleCast;
//...
	
void StartScanning ()
{
	// Initialize the device scanner
	DeviceScanner = new GCKDeviceScanner ();
	// DeviceScannerListener class implements the interface `IGCKDeviceScannerListener`
	DeviceScanner.AddListener (new DeviceScannerListener ());
	// Start scanning for deviced
	DeviceScanner.StartScan ();
}
```


After scanning begins, your delegate will be notified when devices are discovered or go offline.

**Device scanner listener**


```csharp
using GoogleCast;
//...

public class DeviceScannerListener : NSObject, IGCKDeviceScannerListener
{
	[Export ("deviceDidComeOnline:")]
	public void DeviceDidComeOnline (GCKDevice device)
	{
		Console.WriteLine ("Device found: {0}", device.FriendlyName);
	}

	[Export ("deviceDidGoOffline:")]
	public void DeviceDidGoOffline (GoogleCast.GCKDevice device)
	{
		Console.WriteLine ("Device disappeared: {0}", device.FriendlyName);
	}
}
```

For convenience the device scanner keeps track of all known active devices. This can be used to create an UIActionSheet for deploying devices to the user.

**Device selection**

Once the user has selected a device you can connect to it. Start by creating a device manager and give it the selected device. Next you register a delegate to listen for the connection. Finally you connect to the device.

```csharp
using GoogleCast;
//...

void ConnectToDevice () 
{
	// selectedDevice comes from the user selection and its type is GCKDevice
	var info = NSBundle.MainBundle.InfoDictionary;
	var deviceManager = new GCKDeviceManager (selectedDevice, info ["CFBundleIdentifier"].ToString ());
	// DeviceManagerDelegate class implements the interface `IGCKDeviceManagerDelegate`
	deviceManager.Delegate = new DeviceManagerDelegate ();
	deviceManager.Connect ();
}
```

**Launch application**

Once you are connected to the receiver you will be notified. After successful connection you can launch your application.

```csharp
using GoogleCast;
//...
public class DeviceManagerDelegate : NSObject, IGCKDeviceManagerDelegate
{
	[Export ("deviceManagerDidConnect:")]
	public void DidConnect (GoogleCast.GCKDeviceManager deviceManager)
	{
		Console.WriteLine ("connected!!");
		DeviceManager.LaunchApplication ("APP_ID_HERE");
	}
		
	[Export ("deviceManager:didConnectToCastApplication:sessionID:launchedApplication:")]
	public void DidConnectToCastApplication (GoogleCast.GCKDeviceManager deviceManager, GoogleCast.GCKApplicationMetadata applicationMetadata, string sessionId, bool launchedApplication)
	{
		Console.WriteLine ("Application has launched");
		var mediaControlChannel = new GCKMediaControlChannel ();
		mediaControlChannel.Delegate = new GCKMediaControlChannelDelegate ();
		deviceManager.AddChannel (mediaControlChannel);
	}
}
```

**Media channels**

Media channels provide the means by which your sender app controls the playback on the receiver. You can also define a custom channels to send custom messages to the receiver.

**Media control channel**

The media control channel plays, pauses, seeks, and stops the media on a receiver application. The media channel has a well-known namespace of `urn:x-cast:com.google.cast.media.`

To use a media channel you must create an instance of `GCKMediaControlChannel` after you connect to the cast application as shown in the `DeviceManagerDelegate` above.

Next, you must define the media you would like to cast by using the `GCKMediaMetadata` class. 

**Media metadata**

Define the media you would like to cast by using the `GCKMediaMetadata` class.

```csharp
// Define Media metadata
var metadata = new GCKMediaMetadata ();
metadata.SetString ("The Cat", GCKMetadataKey.Title);
metadata.SetString ("soft kitty, warm kitty, little ball of fur sleepy kitty, happy kitty, purr, purr, purr.", GCKMetadataKey.Subtitle);
metadata.AddImage (new GCKImage (new NSUrl ("http://placekitten.com/480/360"), 480, 360));
```

Finally you are ready to cast the media. You must create a GCKMediaInformation that can be used to cast the media on the media control channel.

**Load media**

To load the media, do the following.

```csharp
// define Media information
var mediaInformation = new GCKMediaInformation ("http://dummyurl.com/kitten.mp4",
	                       GCKMediaStreamType.None, "video/mp4", metadata, 0, null);
// cast video
MediaControlChannel.LoadMedia (mediaInformation, true, 0);
```

## External Links

iOS Api: [https://developers.google.com/cast/docs/reference/ios/](https://developers.google.com/cast/docs/reference/ios/)

##### Portions of this page are modifications based on [work](https://developers.google.com/cast/docs/ios_sender) created and shared by [Google Inc.](http://google.com) and used according to terms described in the [Creative Commons 3.0 Attribution License](http://creativecommons.org/licenses/by/3.0/).
	