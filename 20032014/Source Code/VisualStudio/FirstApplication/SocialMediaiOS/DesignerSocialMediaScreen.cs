using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace SocialMediaiOS
{
    using System.Net.Http;

    using Newtonsoft.Json;

    using Xamarin.Controls;

    public partial class DesignerSocialMediaScreen : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public DesignerSocialMediaScreen ()
			: base (UserInterfaceIdiomIsPhone ? "DesignerSocialMediaScreen_iPhone" : "DesignerSocialMediaScreen_iPad", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

        private async void PopulateSocialItemsListView()
        {

            //Usage of Standard HttpClient 

            var client = new HttpClient();

            try
            {
                //Usage of Async Await to a WebAPI REST service

                var response = client.GetStringAsync("http://azurexamarindem.cloudapp.net/webapidemo/api/SocialMedia/GetAllSocialMedia");

                var content = await response;

                var mediaPosts = JsonConvert.DeserializeObject<SightingsMediaPost[]>(content);
                var source = new SocialMediaCollectionViewSource(mediaPosts);

                SocialMediaCollectionView.CollectionViewLayout = new UICollectionViewFlowLayout()
                                                                     {
                                                                         SectionInset =
                                                                             new UIEdgeInsets
                                                                             (20, 5, 10, 5),
                                                                         MinimumInteritemSpacing
                                                                             = 5,
                                                                         MinimumLineSpacing
                                                                             = 5,
                                                                         ItemSize =
                                                                             new System.
                                                                             Drawing.SizeF(
                                                                             200,
                                                                             100)
                                                                     };

                SocialMediaCollectionView.Source = source;
                SocialMediaCollectionView.ReloadData();
                AlertCenter.Default.PostMessage("Social Media", "Data Retrieved");

            }
            catch (Exception ex)
            {
                AlertCenter.Default.PostMessage("Oh Dear", ex.Message);
            }
        }

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            SocialMediaCollectionView.RegisterClassForCell(typeof(ImageCell), SocialMediaCollectionViewSource.cellIdentifier);

			SocialMediaRefreshButton.TouchUpInside += (object sender, EventArgs e) => {

                this.PopulateSocialItemsListView();
			};

            SocialMediaCollectionView.BackgroundColor = UIColor.White;


            this.PopulateSocialItemsListView();
		}
	}
}

