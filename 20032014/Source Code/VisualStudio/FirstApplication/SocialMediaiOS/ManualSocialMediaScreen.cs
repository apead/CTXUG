using System;
using System.Drawing;

using MonoTouch.CoreFoundation;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace SocialMediaiOS
{
    using System.Net.Http;

    using Newtonsoft.Json;

    using Xamarin.Controls;

    [Register("ManualSocialMediaScreen")]
    public class ManualSocialMediaScreen : UITableViewController
    {
        private async void PopulateSocialItemsListView()
        {

            //Usage of Standard HttpClient 

            var client = new HttpClient();

            try
            {
                //Usage of Async Await to a WebAPI REST service

                var response = client.GetStringAsync("http://azurexamarindem.cloudapp.net/webapidemo/api/SocialMedia/GetAllSocialMedia");

                var content = await response;

                //Standard .NET libraries like JSON.NET
                TableView = new UITableView(Rectangle.Empty, UITableViewStyle.Plain); 

                var mediaPosts = JsonConvert.DeserializeObject<SightingsMediaPost[]>(content);
                TableView.Source = new SocialMediaTableViewSource(mediaPosts);

                AlertCenter.Default.PostMessage("Social Media", "Data Retrieved");

            }
            catch (Exception ex)
            {
                AlertCenter.Default.PostMessage("Oh Dear", ex.Message);
            }
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            TableView.ContentInset = new UIEdgeInsets(this.TopLayoutGuide.Length, 0, 0, 0);
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            PopulateSocialItemsListView();

            AlertCenter.Default.PostMessage("Social Media", "Fetching Data");
        }
    }
}