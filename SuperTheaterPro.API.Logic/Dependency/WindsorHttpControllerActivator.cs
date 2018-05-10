using Castle.Windsor;
using SuperProducer.Core.Service;
using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Linq;

namespace SuperTheaterPro.API.Logic
{
    public class WindsorHttpControllerActivator : IHttpControllerActivator
    {
        private IWindsorContainer _Container;

        protected IWindsorContainer Container
        {
            get { return _Container; }
        }

        public WindsorHttpControllerActivator(IWindsorContainer container)
        {
            this._Container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            try
            {
                return (IHttpController)this._Container.Resolve(controllerType);
            }
            catch { }
            return null;
        }
    }
}
