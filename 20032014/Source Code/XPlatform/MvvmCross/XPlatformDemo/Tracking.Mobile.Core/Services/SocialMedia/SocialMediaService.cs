using System.Collections.Generic;

namespace AdSoftwareSystems.Tracking.Mobile.Core.Services.SocialMedia
{
    using System;

    using AdSoftwareSystems.Tracking.Common.Core.SocialMedia;
    using AdSoftwareSystems.Tracking.Mobile.Core.Services.Rest;

    public class SocialMediaService : ISocialMediaService
    {
        private ISimpleRestService _simpleRestService;

        public SocialMediaService(ISimpleRestService simpleRestService)
        {
            _simpleRestService = simpleRestService;
        }

        public void GetLatestSightingPostsAsync(Action<List<SightingsMediaPost>> success, Action<Exception> error)
        {
            var address = "http://azurexamarindem.cloudapp.net/webapidemo/api/SocialMedia/GetAllSocialMedia";
            
            _simpleRestService.MakeRequest(address,
                "GET", success, error);
        }
    }
}
