using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Threading;
using System.Web.Http.Controllers;
using SuperProducer.Core.Utility;
using SuperTheaterPro.Business.BLL;
using System.Net.Http;
using System.Net.Http.Formatting;
using SuperTheaterPro.Business.Model;
using System.Collections.Generic;
using System;
using SuperProducer.Core.Log;
using System.Web;
using SuperProducer.Framework.Model.Log;
using SuperTheaterPro.Framework.Utility.Config;

namespace SuperTheaterPro.API.Logic
{
    public class GlobalApiRequestFilter : ActionFilterAttribute
    {
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var model = new APIResultModel(200);

            if (!EnumHelper.IsDefined(typeof(CommonEnumInternal.LanguageType), ClientContext.Current.ClientLanguage))
            {
                model.code = 1000002; // 客户端语言设置错误
            }

            if (!EnumHelper.IsDefined(typeof(CommonEnumInternal.PlatformType), ClientContext.Current.PlatformType) ||
                ClientContext.Current.PlatformType == (byte)CommonEnumInternal.PlatformType.Unknown)
            {
                model.code = 1000003; // 客户端识别码设置错误
            }

            if (model.code == model.RightCode)
            {
                #region "过滤器代码区"

                // TO DO

                #region "请求日志"

                if (CachedFileConfigContext.Current.SiteConfig.ClientRequestWriteLog)
                {
                    var message = new ClientRequestLog
                    {
                        Url = HttpContext.Current.Request.Url.ToString(),
                        QueryParas = SerializationHelper.Newtonsoft_Serialize(HttpContext.Current.Request.QueryString),
                        FormParas = SerializationHelper.Newtonsoft_Serialize(HttpContext.Current.Request.Form),
                        HeaderParas = SerializationHelper.Newtonsoft_Serialize(HttpContext.Current.Request.Headers),
                        IPAddress = WebHelper.UserIPAddress,
                        UserID = ClientContext.Current.UserInfo != null ? ClientContext.Current.UserInfo.UserID : 0,
                        PlatformType = ClientContext.Current.PlatformType
                    };
                    Log4NetHelper.Info(LoggerType.ClientRequestLog, message, null);
                }

                #endregion

                #region "参数解密"

                #endregion

                #region "签名校验"

                #endregion

                #region "参数过滤"

                if (!actionContext.Request.Content.IsMimeMultipartContent())
                {
                    var actionParas = new Dictionary<string, object>(actionContext.ActionArguments);
                    actionContext.ActionArguments.Clear();
                    foreach (var item in actionParas)
                    {
                        if (item.Value != null)
                        {
                            if (item.Value.IsReferenceObject())
                            {
                                item.Value.ReplaceSQLKeywords();
                                actionContext.ActionArguments.Add(item.Key, item.Value);
                            }
                            else
                            {
                                actionContext.ActionArguments.Add(item.Key, ConvertHelper.GetString(item.Value).ReplaceSQLKeywords());
                            }
                        }
                    }
                }

                #endregion

                #endregion
            }

            if (model.code != model.RightCode)
            {
                actionContext.Response = new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new ObjectContent<APIResultModel>(model, new JsonMediaTypeFormatter())
                };
            }

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            try
            {
                if (actionExecutedContext.Response != null && actionExecutedContext.Response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var request = actionExecutedContext.Request;
                    var response = actionExecutedContext.Response;

                    response.Headers.Add("Access-Control-Allow-Origin", "*");
                    response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
                    response.Headers.Add("Access-Control-Allow-Credentials", "true");
                }
            }
            catch { }

            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
    }
}
