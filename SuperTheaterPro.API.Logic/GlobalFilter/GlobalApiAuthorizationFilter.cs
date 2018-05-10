using SuperProducer.Core.Utility;
using SuperTheaterPro.Business.BLL;
using SuperTheaterPro.Business.Model;
using SuperTheaterPro.Framework.Utility.Config;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SuperTheaterPro.API.Logic
{
    public class GlobalApiAuthorizationFilter : AuthorizationFilterAttribute
    {
        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var model = new APIResultModel(200);

            var controller = ConvertHelper.GetString(actionContext.ControllerContext.RouteData.Values["controller"]);
            var action = ConvertHelper.GetString(actionContext.ControllerContext.RouteData.Values["action"]);

            var ignoreAuthorizeUrls = CachedFileConfigContext.Current.SiteConfig.IgnoreAuthorizationUrls.Replace("\r", "").Replace("\n", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (ignoreAuthorizeUrls == null)
                ignoreAuthorizeUrls = new string[] { };

            if (ignoreAuthorizeUrls.Where(item =>
                (item.Trim().ToLower() == string.Format("/{0}/*", controller.ToLower())) ||
                (item.Trim().ToLower() == string.Format("/{0}/{1}", controller.ToLower(), action.ToLower()))
                ).FirstOrDefault() == null)
            {
                model.code = (int)CommonEnumInternal.ProgErrorString.Key_100001;

                if (ClientContext.Current.UserInfo != null && ClientContext.Current.UserInfo.UserID > 0 && ClientContext.Current.UserInfo.UserGuid != Guid.Empty)
                {
                    model.code = model.RightCode;
                }
            }

            model.code = model.RightCode;

            if (model.code != model.RightCode)
            {
                actionContext.Response = new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new ObjectContent<APIResultModel>(model, new JsonMediaTypeFormatter())
                };
            }

            return base.OnAuthorizationAsync(actionContext, cancellationToken);
        }
    }
}
