using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using GoogleCast;

namespace GoogleCastiOSSample
{
	public class CastViewController : UIViewController
	{
		public GCKMediaControlChannel MediaControlChannel { get; set; }
		public GCKApplicationMetadata AppMetadata { get; set; }
		public GCKDevice SelectedDevice { get; set; }
		public GCKDeviceScanner DeviceScanner { get; set; }
		public UIButton castButton { get; set; }
		public GCKDeviceManager DeviceManager { get; set; }
		public GCKMediaInformation MediaInformation { get; private set; }
		public string SessionId { get; set; }

		UIImage castButtonImage;

		public CastViewController () : base ()
		{
			Initialize ();
		}

		public CastViewController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}

		void Initialize ()
		{
			Title = "Cast Sample";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Create the cast video button
			View.BackgroundColor = UIColor.White;
			var btnCastVideo = UIButton.FromType (UIButtonType.RoundedRect);
			btnCastVideo.Frame = new RectangleF (110, 90, 100, 30);
			btnCastVideo.SetTitle ("Cast Video", UIControlState.Normal);
			btnCastVideo.TouchUpInside += CastVideo;

			View.AddSubview (btnCastVideo);

			// Get cast button images
			castButtonImage = UIImage.FromBundle ("icon-cast-identified.png");

			// Create the cast button
			castButton = UIButton.FromType (UIButtonType.RoundedRect);
			castButton.Frame = new RectangleF (0, 0, castButtonImage.Size.Width, castButtonImage.Size.Height);
			castButton.SetImage (null, UIControlState.Normal);
			castButton.Hidden = true;
			castButton.TouchUpInside += ChooseDevice;

			// Add button to the navigation bar
			NavigationItem.RightBarButtonItem = new UIBarButtonItem (castButton);

			// Initialize the device scanner
			DeviceScanner = new GCKDeviceScanner ();
			DeviceScanner.AddListener (new DeviceScannerListener (this));
			DeviceScanner.StartScan ();
		}

		void CastVideo (object sender, EventArgs e)
		{
			// Show Alert if not connected
			if (DeviceManager == null || !DeviceManager.IsConnected) {
				new UIAlertView ("Not Connected", "Please connect to a cast device", null, "Ok", null).Show ();
				return;
			}

			// Define Media metadata
			var metadata = new GCKMediaMetadata ();
			metadata.SetString ("Big Buck Bunny (2008)", GCKMetadataKey.Title);
			metadata.SetString ("Big Buck Bunny tells the story of a giant rabbit with a heart bigger than " +
				"himself. When one sunny day three rodents rudely harass him, something " +
				"snaps... and the rabbit ain't no bunny anymore! In the typical cartoon " +
				"tradition he prepares the nasty rodents a comical revenge.", 
				GCKMetadataKey.Subtitle);
			metadata.AddImage (new GCKImage (new NSUrl ("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/images/BigBuckBunny.jpg"), 480, 360));

			// define Media information
			var mediaInformation = new GCKMediaInformation ("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4",
				                       GCKMediaStreamType.None, "video/mp4", metadata, 0, null);
			// cast video
			MediaControlChannel.LoadMedia (mediaInformation, true, 0);
		}

		void ChooseDevice (object sender, EventArgs e)
		{
			if (SelectedDevice == null) {
				// Select Device
				var selectionSheet = new UIActionSheet ("Connect to device");

				foreach (var device in DeviceScanner.Devices)
					selectionSheet.AddButton (device.FriendlyName);

				selectionSheet.AddButton ("Cancel");
				selectionSheet.CancelButtonIndex = selectionSheet.ButtonCount - 1;
				selectionSheet.Clicked += HandleSheetClicked;

				// Show the sheet
				selectionSheet.ShowInView (castButton);
			} else {
				// Gather stats from device.
				if (MediaControlChannel != null && DeviceManager.IsConnected) {
					MediaInformation = MediaControlChannel.MediaStatus.MediaInformation;
				}

				var friendlyName = "Casting to: " + SelectedDevice.FriendlyName;
				var mediaTitle = MediaInformation.Metadata.StringForKey (GCKMetadataKey.Title);

				var sheet = new UIActionSheet (friendlyName);
				if (mediaTitle != null) 
					sheet.AddButton (mediaTitle);

				// Offer disconnect option
				sheet.AddButton ("Disconnect");
				sheet.AddButton ("Cancel");
				sheet.DestructiveButtonIndex = mediaTitle != null ? 1 : 0;
				sheet.CancelButtonIndex = mediaTitle != null ? 2 : 1;
				sheet.Clicked += HandleSheetClicked;

				sheet.ShowInView (castButton);
			}
		}

		void HandleSheetClicked (object sender, UIButtonEventArgs e)
		{
			if (SelectedDevice == null) {
				if (e.ButtonIndex < DeviceScanner.Devices.Length) {
					SelectedDevice = DeviceScanner.Devices [e.ButtonIndex];
					Console.WriteLine ("Selecting Device: {0}", SelectedDevice.FriendlyName);
					ConnectToDevice ();
				}
			} else {
				if (e.ButtonIndex == 1) { // Disconnect button
					Console.WriteLine ("Disconecting Device: {0}", SelectedDevice.FriendlyName);
					DeviceManager.LeaveApplication ();
					// If you want to not stop the application, comment line below
					DeviceManager.StopApplication (SessionId);
					DeviceManager.Disconnect ();

					DeviceDisconnected ();
					UpdateButtonStates ();
				} else if (e.ButtonIndex == 0) {
					// Join the existing session.
				}
			} 
		}

		void ConnectToDevice () 
		{
			if (SelectedDevice == null)
				return;

			var info = NSBundle.MainBundle.InfoDictionary;
			DeviceManager = new GCKDeviceManager (SelectedDevice, info ["CFBundleIdentifier"].ToString ());
			DeviceManager.Delegate = new DeviceManagerDelegate (this);
			DeviceManager.Connect ();
		}

		public void DeviceDisconnected ()
		{
			MediaControlChannel = null;
			DeviceManager = null;
			SelectedDevice = null;
		}

		public void UpdateButtonStates ()
		{
			if (DeviceScanner.Devices.Length == 0) 
				// Hide the cast button
				castButton.Hidden = true;
			else {
				// Show cast button
				castButton.SetImage (castButtonImage, UIControlState.Normal);
				castButton.Hidden = false;

				if (DeviceManager != null && DeviceManager.IsConnected)
					// Show cast button in enabled state
					castButton.TintColor = UIColor.Blue;
				else
					// Show cast button in disabled state
					castButton.TintColor = UIColor.Gray;
			}
		}
	}
}

