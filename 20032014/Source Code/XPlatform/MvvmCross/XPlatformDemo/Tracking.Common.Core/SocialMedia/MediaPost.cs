namespace AdSoftwareSystems.Tracking.Common.Core.SocialMedia
{
    using System;

    public class MediaPost
    {
        public MediaPost()
        {
            this.TimeStamp = DateTime.Now;
        }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string StatusUpdate { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}