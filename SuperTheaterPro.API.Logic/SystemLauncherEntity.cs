using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using SuperProducer.Core.Utility;
using SuperTheaterPro.Framework.Utility.Config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Linq;

namespace SuperTheaterPro.API.Logic
{
    public interface ISubscriber
    {
        void Notify(ISubject sender, int flag);
    }

    public interface ISubject
    {
        void Add(ISubscriber sub);
        void Delete(ISubscriber sub);
        void Notify(int flag);
    }

    internal class SystemLauncherEntity : ISubject
    {
        private List<ISubscriber> allSubscriber = new List<ISubscriber>();

        public void Add(ISubscriber sub)
        {
            if (sub != null && !allSubscriber.Contains(sub))
            {
                allSubscriber.Add(sub);
            }
        }

        public void Delete(ISubscriber sub)
        {
            if (sub != null && allSubscriber.Contains(sub))
            {
                allSubscriber.Remove(sub);
            }
        }

        public void Notify(int flag)
        {
            if (allSubscriber.Count > 0)
            {
                foreach (var item in allSubscriber)
                {
                    item.Notify(this, flag);
                }
            }
        }
    }

    internal class BasicConfigSubscriber : ISubscriber
    {
        public void Notify(ISubject sender, int flag)
        {
            if (flag == 1) // 启动
            {
                //GlobalConfiguration.Configuration.Formatters.JsonFormatter.AddQueryStringMapping("format", "json", "application/json");
                //GlobalConfiguration.Configuration.Formatters.JsonFormatter.AddQueryStringMapping("format", "xml", "application/xml");
                GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

                ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(Container.Current.DefaultContainer));
                //DependencyResolver.SetResolver(new WindsorDependencyResolver(Container.Current.DefaultContainer));
                GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorHttpControllerActivator(Container.Current.DefaultContainer));
                //GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(Container.Current.DefaultContainer);
            }
            else if (flag == 2) // 停止
            {

            }
        }
    }

    internal class SqlDependencySubscriber : ISubscriber
    {
        public void Notify(ISubject sender, int flag)
        {
            if (flag == 1) // 启动
            {
                SqlDependency.Stop(CachedFileConfigContext.Current.DaoConfig.Main);
                SqlDependency.Start(CachedFileConfigContext.Current.DaoConfig.Main);
            }
            else if (flag == 2) // 停止
            {
                SqlDependency.Stop(CachedFileConfigContext.Current.DaoConfig.Main);
            }
        }
    }

    internal class ContainerSubscriber : ISubscriber
    {
        public void Notify(ISubject sender, int flag)
        {
            if (flag == 1) // 启动
            {
                Container.Current.AddInstaller(null, new InterceptorContainer());
                Container.Current.AddInstaller(null, new MvcControllerContainer());
                Container.Current.AddInstaller(null, new ApiControllerContainer());
                Container.Current.AddInstaller(null, new BusinessContainer());
            }
            else if (flag == 2) // 停止
            {

            }
        }

        public class InterceptorContainer : Container.BaseWindsorInstaller
        {
            protected override string AssemblyName => "SuperProducer.Core.Service";

            protected override Func<FromAssemblyDescriptor, BasedOnDescriptor> BasicDescriptor => item => item.BasedOn<IInterceptor>();

            protected override Func<ServiceDescriptor, BasedOnDescriptor> WithServiceDescriptor => item => item.FirstInterface();

            protected override Action<ComponentRegistration> Configurer => item => item.LifestylePerWebRequest();
        }

        public class MvcControllerContainer : Container.BaseWindsorInstaller
        {
            protected override string AssemblyName => "SuperTheaterPro.API";

            protected override Func<FromAssemblyDescriptor, BasedOnDescriptor> BasicDescriptor => item => item.BasedOn<IController>();

            protected override Func<ServiceDescriptor, BasedOnDescriptor> WithServiceDescriptor => base.WithServiceDescriptor;

            protected override Action<ComponentRegistration> Configurer => item => item.LifestyleTransient();
        }

        public class ApiControllerContainer : Container.BaseWindsorInstaller
        {
            protected override string AssemblyName => "SuperTheaterPro.API";

            protected override Func<FromAssemblyDescriptor, BasedOnDescriptor> BasicDescriptor => item => item.BasedOn<IHttpController>();

            protected override Func<ServiceDescriptor, BasedOnDescriptor> WithServiceDescriptor => base.WithServiceDescriptor;

            protected override Action<ComponentRegistration> Configurer => item => item.LifestyleTransient();
        }

        public class BusinessContainer : Container.BaseWindsorInstaller
        {
            protected override string AssemblyName => "SuperTheaterPro.Business.BLL";

            protected override Func<FromAssemblyDescriptor, BasedOnDescriptor> BasicDescriptor => item => item.Where(value => value.Name.EndsWith("Service"));

            protected override Func<ServiceDescriptor, BasedOnDescriptor> WithServiceDescriptor => item => item.FirstInterface();

            protected override Action<ComponentRegistration> Configurer => item => item.LifestylePerWebRequest().Interceptors(typeof(IInterceptor));
        }
    }
}
