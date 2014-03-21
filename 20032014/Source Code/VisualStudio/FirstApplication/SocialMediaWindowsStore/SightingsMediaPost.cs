namespace SocialMediaWindowsStore
{
    public class SightingsMediaPost : MediaPost
    {
        public string Id { get; set; }
        public SightingsCategory Category { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public GeoPosition Position { get; set; }
    }
}
