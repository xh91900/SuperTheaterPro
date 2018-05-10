using Castle.Windsor;
using SuperProducer.Core.Service;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SuperTheaterPro.API.Logic
{
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private IWindsorContainer _Container;

        protected IWindsorContainer Container
        {
            get { return _Container; }
        }

        public WindsorControllerFactory(IWindsorContainer container)
        {
            this._Container = container;
        }

        public override void ReleaseController(IController controller)
        {
            this._Container.Release(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
            {
                return (IController)this._Container.Resolve(controllerType);
            }
            throw new HttpException((int)HttpStatusCode.NotFound, "Page Not Found.");
        }
    }

}
