using Castle.Windsor;
using System.Web.Http.Dependencies;

namespace SuperTheaterPro.API.Logic
{
    public class WindsorDependencyResolver : WindsorDependencyScope, IDependencyResolver
    {
        public WindsorDependencyResolver(IWindsorContainer container) : base(container) { }

        public IDependencyScope BeginScope()
        {
            var childContainer = new WindsorContainer();
            this.Container.AddChildContainer(childContainer);
            return new WindsorDependencyScope(childContainer);
        }
    }
}
