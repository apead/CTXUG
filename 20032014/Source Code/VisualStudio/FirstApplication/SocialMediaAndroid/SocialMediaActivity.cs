namespace SocialMediaAndroid
{
    using System;
    using System.Linq;
    using System.Net.Http;

    using Android.App;
    using Android.OS;
    using Android.Widget;

    using Newtonsoft.Json;

    [Activity(Label = "Social Media")]
    public class SocialMediaActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.SocialMediaActivityLayout);

            this.PopulateSocialItemsListView();

            //Async Illustration

            var toast = Toast.MakeText(this, "Application Started", ToastLength.Short);
            toast.Show();
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

                //Standard .NET libraries like JSON.NET

                var mediaPosts = JsonConvert.DeserializeObject<SightingsMediaPost[]>(content);

                var listview = this.FindViewById<ListView>(Resource.Id.MySocialPostListView);

                // LINQ with a projection

                var myItems = mediaPosts.Select(x => new SocialMediaListItem { Id = x.Id, Title = x.UserId, SubTitle = x.StatusUpdate, Image = x.Image}).ToList();

                listview.Adapter = new SocialListViewAdapter(this, myItems, Resource.Layout.SocialMediaListViewLayout);
            }
            catch (Exception ex)
            {
                var myToast = Toast.MakeText(this, ex.Message, ToastLength.Short);
                     myToast.Show();
            }
        }
    }
}