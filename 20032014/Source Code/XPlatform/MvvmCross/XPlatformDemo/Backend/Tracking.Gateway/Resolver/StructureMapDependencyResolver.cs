namespace SocialMediaWebApiDemo.Resolver
{
    using System.Web.Http.Dependencies;

    using Big5ServicesGateway.Resolver;

    using StructureMap;

    public class StructureMapDependencyResolver : StructureMapScope, IDependencyResolver
    {
        private readonly IContainer container;

        public StructureMapDependencyResolver(IContainer container)
            : base(container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            var childContainer = this.container.GetNestedContainer();
            return new StructureMapScope(childContainer);
        }
    }
}