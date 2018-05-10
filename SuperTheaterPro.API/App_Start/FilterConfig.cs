using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace SuperTheaterPro.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            RegisterMvcFilters(GlobalFilters.Filters);
            RegisterApiFilters(GlobalConfiguration.Configuration.Filters);
        }

        public static void RegisterMvcFilters(GlobalFilterCollection filters)
        {

        }

        public static void RegisterApiFilters(HttpFilterCollection filters)
        {
            filters.Add(new Logic.GlobalApiExceptionFilter());
            filters.Add(new Logic.GlobalApiAuthorizationFilter());
            filters.Add(new Logic.GlobalApiRequestFilter());
        }
    }
}
