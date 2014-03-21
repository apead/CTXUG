namespace AdSoftwareSystems.Tracking.Common.Core.SocialMedia
{
    using AdSoftwareSystems.Tracking.Common.Core.GeoLocation;
    using AdSoftwareSystems.Tracking.Common.Core.Sightings;

    public class SightingsMediaPost : MediaPost
    {
        public string Id { get; set; }
        public SightingsCategory Category { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public Location Position { get; set; }
    }
}
