namespace SocialMediaWindowsStore
{
    public class GeoPosition
    {
        public GeoCoordinate Longitude { get; set; }
        public GeoCoordinate Latitude { get; set; }
    }

    public class GeoCoordinate
    {
         public GeoCoordinate(double degrees)
        {
            this.Degrees = degrees;
        }

        public double Degrees { get; private set; }
    }
}
