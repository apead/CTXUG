namespace SocialMediaWebApiDemo.Controllers.Base
{
    using System.Web.Http;

    using Raven.Client;

    public class BaseApiController : ApiController
    {
        protected IDocumentStore DocumentStore { get; set; }

        public BaseApiController()
        {
            
        }

        public BaseApiController(IDocumentStore store)
        {
            this.DocumentStore = store;
        }
    }
}