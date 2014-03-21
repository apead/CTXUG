namespace AdSoftwareSystems.Tracking.Common.Core.Sightings
{
    using AdSoftwareSystems.Tracking.Common.Core.GeoLocation;

    public class SightingsItem
    {
        public string Id { get; set; }
        public SightingsCategory Category { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public Location Position { get; set; }
    }
}
