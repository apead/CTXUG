namespace AdSoftwareSystems.Tracking.Mobile.Core.Services.SocialMedia
{
    using System;
    using System.Collections.Generic;

    using AdSoftwareSystems.Tracking.Common.Core.SocialMedia;

    public interface ISocialMediaService
    {
        void GetLatestSightingPostsAsync(Action<List<SightingsMediaPost>> success, Action<Exception> error);
    }
}
