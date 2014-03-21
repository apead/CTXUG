using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace SocialMediaWindowsStore
{
    using System.Net.Http;

    using Windows.Data.Xml.Dom;
    using Windows.UI.Notifications;

    using Newtonsoft.Json;

    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class SocialMediaItemsPage : SocialMediaWindowsStore.Common.LayoutAwarePage
    {
        public SocialMediaItemsPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            // TODO: Assign a bindable collection of items to this.DefaultViewModel["Items"]

            this.PopulateSocialItemsListView();

            var toastTemplate = ToastTemplateType.ToastText01;
            var toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            var toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode("Application Started"));
            var toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        private async void PopulateSocialItemsListView()
        {
            var client = new HttpClient();

            try
            {
                var response = client.GetStringAsync("http://azurexamarindem.cloudapp.net/webapidemo/api/SocialMedia/GetAllSocialMedia");

                var content = await response;

                var mediaPosts = JsonConvert.DeserializeObject<SightingsMediaPost[]>(content);

                var myItems = mediaPosts.Select(x => new  { Id = x.Id, Title = x.UserId, Subtitle = x.StatusUpdate, Image = x.Image }).ToList();

                this.DefaultViewModel["Items"] = myItems;
            }
            catch (Exception ex)
            {
                var toastTemplate = ToastTemplateType.ToastText01;
                var toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
                XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
                toastTextElements[0].AppendChild(toastXml.CreateTextNode(ex.Message));

            }
        }
    }
}
