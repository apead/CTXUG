using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformDemo.Core.Models
{
    public class Device
    {
        [Newtonsoft.Json.JsonProperty("Id")]
        public string Id { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        public string DeviceName { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string LogoUrl { get; set; }

        public string ThumbnailUrl { get; set; }
        public string WebsiteUrl { get; set; }
    }


}
