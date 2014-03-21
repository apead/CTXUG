namespace SocialMediaWebApiDemo.Controllers
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    using AdSoftwareSystems.Tracking.Common.Core.Sightings;
    using AdSoftwareSystems.Tracking.Common.Core.SocialMedia;
    using Raven.Client;
    using SocialMediaWebApiDemo.Controllers.Base;

    public class SocialMediaController : BaseApiController
    {
        public SocialMediaController(IDocumentStore store) : base(store)
        {
          

        }

        public void CreateMockSightings()
        {
            using (IDocumentSession session = this.DocumentStore.OpenSession())
            {
                var imageBase = ConfigurationManager.AppSettings["ImageBase"];

                var rhinoCategory = new SightingsCategory { Id = "Rhino", Description = "Rhino" };
                var buffaloCategory = new SightingsCategory { Id = "Buffalo", Description = "Buffalo" };
                var springbokCategory = new SightingsCategory { Id = "SpringBok", Description = "SpringBok" };
                var lionCategory = new SightingsCategory { Id = "Lion", Description = "Lion" };

                var sighting = new SightingsMediaPost
                                   {
                                       Image = imageBase + "babyrhino.jpg",
                                       Description = "Baby Rhino spotted near the watering hole.",
                                       StatusUpdate =
                                           "Baby Rhino Spotted at Kruger near the watering hole #SanParks",
                                       Category = rhinoCategory,
                                       UserId = "@Mario123",
                                       UserName = "Mario"
                                   };

                session.Store(sighting);
                session.SaveChanges();

                 sighting = new SightingsMediaPost
                {
                    Image = imageBase + "buffalo.jpg",
                    Description = "Buffalo.",
                    StatusUpdate =
                        "Huge Buffalo charged the Truck!",
                    Category = buffaloCategory,
                    UserId = "@Bob16",
                    UserName = "Bob"
                };

                session.Store(sighting);
                session.SaveChanges();

                sighting = new SightingsMediaPost
                {
                    Image = imageBase + "Elephant.jpg",
                    Description = "Elephant on the run.",
                    StatusUpdate =
                        "Really loved the Elephants being so close to us. #awesome",
                    Category = buffaloCategory,
                    UserId = "@HappyTourist",
                    UserName = "HappyTourist"
                };

                session.Store(sighting);
                session.SaveChanges();

                session.Store(sighting);
                session.SaveChanges();

                sighting = new SightingsMediaPost
                {
                    Image = imageBase + "lions.jpg",
                    Description = "Sleepy lions.",
                    StatusUpdate =
                        "Looks like it's nap time for us and the lions.",
                    Category = lionCategory,
                    UserId = "@Lee52",
                    UserName = "Lee"
                };

                session.Store(sighting);
                session.SaveChanges();

                sighting = new SightingsMediaPost
                {
                    Image = imageBase + "Rhino.jpg",
                    Description = "Rhino",
                    StatusUpdate =
                        "Nice to see the rhinos without guards.",
                    Category = rhinoCategory,
                    UserId = "@Lee52",
                    UserName = "Lee"
                };

                session.Store(sighting);
                session.SaveChanges();

                sighting = new SightingsMediaPost
                {
                    Image = imageBase + "Rhino2.jpg",
                    Description = "Rhino",
                    StatusUpdate =
                        "Rhino up close.",
                    Category = rhinoCategory,
                    UserId = "@RhinoMad",
                    UserName = "Liezel"
                };

                session.Store(sighting);
                session.SaveChanges();

                sighting = new SightingsMediaPost
                {
                    Image = imageBase + "Springbok.jpg",
                    Description = "Springbok",
                    StatusUpdate =
                        "Springboks not playing rugby #bokke",
                    Category = springbokCategory,
                    UserId = "@TouristJoe",
                    UserName = "Joe"
                };

                session.Store(sighting);
                session.SaveChanges();
            }
        }

        public IEnumerable<SightingsMediaPost> GetAllSocialMedia()
        {
            SightingsMediaPost[] posts;
            using (IDocumentSession session = this.DocumentStore.OpenSession())
            {
                posts = session.Query<SightingsMediaPost>().Take(10).ToArray();
            }
            return posts;
        }
    }
}