using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using System.Linq;
using Castle.Windsor;

namespace SuperTheaterPro.API.Logic
{
    public class WindsorDependencyScope : IDependencyScope
    {
        private IWindsorContainer _Container;

        protected IWindsorContainer Container
        {
            get { return _Container; }
        }

        public WindsorDependencyScope(IWindsorContainer container)
        {
            this._Container = container;
        }

        public object GetService(Type target)
        {
            try
            {
                return this._Container.Resolve(target);
            }
            catch { }
            return null;
        }

        public IEnumerable<object> GetServices(Type target)
        {
            return this._Container.ResolveAll(target).Cast<object>();
        }

        public void Dispose()
        {
            if (this._Container.Parent != null)
            {
                this._Container.Parent.RemoveChildContainer(this._Container);
            }
            this._Container.Dispose();
            this._Container = null;
        }
    }
}
