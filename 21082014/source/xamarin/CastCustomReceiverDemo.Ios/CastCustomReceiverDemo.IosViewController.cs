using System;
using System.Drawing;
using GoogleCast;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CastCustomReceiverDemo.Ios
{
    public partial class CastCustomReceiverDemoIosViewController : UIViewController
    {
        public UIImage CastButtonImage;

        public GCKMediaControlChannel MediaControlChannel { get; set; }
        public GCKApplicationMetadata AppMetadata { get; set; }
        public GCKDevice SelectedDevice { get; set; }
        public GCKDeviceScanner DeviceScanner { get; set; }
        public GCKDeviceManager DeviceManager { get; set; }
        public GCKMediaInformation MediaInformation { get; private set; }
        public string SessionId { get; set; }
        public GCKCastChannel TextChannel { get; set; }

        public CastCustomReceiverDemoIosViewController(IntPtr handle)
            : base(handle)
        {
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Get cast button images
            CastButtonImage = UIImage.FromBundle("icon-cast-identified.png");


            CastButton.Frame = new RectangleF(0, 0, CastButtonImage.Size.Width, CastButtonImage.Size.Height);
            CastButton.SetImage(null, UIControlState.Normal);
            CastButton.Hidden = true;
            CastButton.SetTitle("", UIControlState.Normal);

            NavigationItem.RightBarButtonItem = new UIBarButtonItem(CastButton);

            DeviceScanner = new GCKDeviceScanner();
            DeviceScanner.AddListener(new DeviceScannerListener(this));
            DeviceScanner.StartScan();


            // Perform any additional setup after loading the view, typically from a nib.
        }

        #endregion

        public void DeviceDisconnected()
        {
            MediaControlChannel = null;
            DeviceManager = null;
            SelectedDevice = null;
        }


        public void UpdateButtonStates()
        {
            if (DeviceScanner.Devices.Length == 0)
                CastButton.Hidden = true;
            else
            {
                CastButton.SetImage(CastButtonImage, UIControlState.Normal);
                CastButton.Hidden = false;

                if (DeviceManager != null && DeviceManager.IsConnected)
                    CastButton.TintColor = UIColor.Blue;
                else
                    CastButton.TintColor = UIColor.Gray;
            }
        }


        partial void CastButton_TouchUpInside(UIButton sender)
        {
            if (SelectedDevice == null)
            {
                var selectionSheet = new UIActionSheet("Connect to device");

                foreach (var device in DeviceScanner.Devices)
                    selectionSheet.AddButton(device.FriendlyName);

                selectionSheet.AddButton("Cancel");
                selectionSheet.CancelButtonIndex = selectionSheet.ButtonCount - 1;
                selectionSheet.Clicked += ConnectToDeviceClicked;

                selectionSheet.ShowInView(CastButton);
            }
            else
            {
                if (MediaControlChannel != null && DeviceManager.IsConnected)
                {
                    MediaInformation = MediaControlChannel.MediaStatus.MediaInformation;
                }

                var friendlyName = "Casting to: " + SelectedDevice.FriendlyName;
                var mediaTitle = MediaInformation.Metadata.StringForKey(GCKMetadataKey.Title);

                var sheet = new UIActionSheet(friendlyName);
                if (mediaTitle != null)
                    sheet.AddButton(mediaTitle);

                sheet.AddButton("Disconnect");
                sheet.AddButton("Cancel");
                sheet.DestructiveButtonIndex = mediaTitle != null ? 1 : 0;
                sheet.CancelButtonIndex = mediaTitle != null ? 2 : 1;
                sheet.Clicked += ConnectToDeviceClicked;

                sheet.ShowInView(CastButton);


            }

        }

        void ConnectToDeviceClicked(object sender, UIButtonEventArgs e)
        {
            if (SelectedDevice == null)
            {
                if (e.ButtonIndex < DeviceScanner.Devices.Length)
                {
                    SelectedDevice = DeviceScanner.Devices[e.ButtonIndex];
                    Console.WriteLine("Selecting Device: {0}", SelectedDevice.FriendlyName);
                    ConnectToDevice();
                }
            }
            else
            {
                if (e.ButtonIndex == 1)
                {
                    Console.WriteLine("Disconecting Device: {0}", SelectedDevice.FriendlyName);
                    DeviceManager.LeaveApplication();

                    DeviceManager.StopApplication(SessionId);
                    DeviceManager.Disconnect();

                    DeviceDisconnected();
                    UpdateButtonStates();
                }
                else if (e.ButtonIndex == 0)
                {

                }
            }
        }

        void ConnectToDevice()
        {
            if (SelectedDevice == null)
                return;

            var info = NSBundle.MainBundle.InfoDictionary;
            DeviceManager = new GCKDeviceManager(SelectedDevice, info["CFBundleIdentifier"].ToString())
            {
                Delegate = new DeviceManagerDelegate(this)
            };
            DeviceManager.Connect();
        }


        partial void SendButton_TouchUpInside(UIButton sender)
        {
            if (CastConnected())
            {
                TextChannel.SendTextMessage(MessageInput.Text);
            }
        }

        private bool CastConnected()
        {
            if (DeviceManager == null || !DeviceManager.IsConnected)
            {
                new UIAlertView("Not Connected", "Please connect to a cast device", null, "Ok", null).Show();
                return false;
            }


            return true;
        }

    }
}