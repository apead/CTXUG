using System;
using System.Drawing;
using GoogleCast;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CastVideoDemo.Ios
{
    public partial class CastVideoDemoIosViewController : UIViewController
    {
        public UIImage CastButtonImage;

        public GCKMediaControlChannel MediaControlChannel { get; set; }
        public GCKApplicationMetadata AppMetadata { get; set; }
        public GCKDevice SelectedDevice { get; set; }
        public GCKDeviceScanner DeviceScanner { get; set; }
        public GCKDeviceManager DeviceManager { get; set; }
        public GCKMediaInformation MediaInformation { get; private set; }
        public string SessionId { get; set; }

        public GCKMediaMetadata MediaMetadata { get; set; }



        public CastVideoDemoIosViewController(IntPtr handle)
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
            CastButton.SetTitle("",UIControlState.Normal);

            NavigationItem.RightBarButtonItem = new UIBarButtonItem(CastButton);

            DeviceScanner = new GCKDeviceScanner();
            DeviceScanner.AddListener(new DeviceScannerListener(this));
            DeviceScanner.StartScan();

        }

        #endregion

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



        private bool CastValidate()
        {
            if (DeviceManager == null || !DeviceManager.IsConnected)
            {
                new UIAlertView("Not Connected", "Please connect to a cast device", null, "Ok", null).Show();
                return false;
            }


            return true;
        }

        partial void PlayButton_TouchUpInside(UIButton sender)
        {
            if (CastValidate())
            {
                CreateMedia();
                if (MediaControlChannel == null || MediaControlChannel.MediaStatus == null) return;
                if (MediaControlChannel.MediaStatus.PlayerState == GCKMediaPlayerState.Paused)
                    MediaControlChannel.Play();

                PlayButton.Hidden = true;
                PauseButton.Hidden = false;

            }

        }

        partial void PauseButton_TouchUpInside(UIButton sender)
        {
            if (CastValidate())
            {
                if (MediaMetadata == null)
                {
                    new UIAlertView("No Media Loaded", "Please Press Play", null, "Ok", null).Show();
                  
                }

                MediaControlChannel.Pause();

                PlayButton.Hidden = false;
                PauseButton.Hidden = true;

            }
        }

        partial void StopButton_TouchUpInside(UIButton sender)
        {
            if (CastValidate())
            {
                if (MediaMetadata == null)
                {
                    new UIAlertView("No Media Loaded", "Please Press Play", null, "Ok", null).Show();
                    
                }
                MediaControlChannel.Stop();
                MediaMetadata = null;

            }
        }

        private void CreateMedia()
        {
            if (MediaMetadata == null)
            {
                MediaMetadata = new GCKMediaMetadata();
                MediaMetadata.SetString("Channel 9", GCKMetadataKey.Title);
                MediaMetadata.SetString("This is the first of a four part series on building cross platform apps using Xamarin and C#.  " +
"In this episode Robert is joined by James Montemagno, a developer evangelist at Xamarin, who discusses how to create Android, iOS and Windows Phone applications in C# from inside Visual Studio with Xamarin. " +
"We will see how to get started with Xamarin and how to share 60 to 90% of your code between Android, iOS, Windows Phone, and Windows 8 applications. ",
                    GCKMetadataKey.Subtitle);
                MediaMetadata.AddImage(
                    new GCKImage(
                        new NSUrl(
                            "http://channel9.msdn.com/styles/images/ogImage.png"),
                        480, 360));

                var mediaInformation =
                    new GCKMediaInformation(
                        "http://video.ch9.ms/ch9/b898/279e7f2a-5b64-4deb-949a-775acd4db898/VSToolbox90_high.mp4",
                        GCKMediaStreamType.None, "video/mp4", MediaMetadata, 0, null);

                MediaControlChannel.LoadMedia(mediaInformation, true, 0);
            }
        }
    }
}