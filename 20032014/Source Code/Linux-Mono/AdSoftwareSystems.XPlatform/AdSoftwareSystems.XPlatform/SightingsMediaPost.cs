namespace GtkApplication.Dto
{
    using System;

    public class SightingsMediaPost : MediaPost
    {
        public string Id { get; set; }
        public SightingsCategory Category { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public GeoPosition Position { get; set; }
    }

    public class SightingsCategory
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }

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

    public class Location
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }

    public class LinearPosition
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
    }

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
