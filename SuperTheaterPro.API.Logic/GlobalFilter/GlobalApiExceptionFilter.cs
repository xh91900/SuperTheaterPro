using SuperProducer.Core.Log;
using SuperProducer.Core.Service;
using SuperTheaterPro.Business.BLL;
using SuperTheaterPro.Business.Model;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;

namespace SuperTheaterPro.API.Logic
{
    public class GlobalApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Log4NetHelper.Error(LoggerType.WebExceptionLog, null, actionExecutedContext.Exception);

            if (actionExecutedContext.Response == null)
            {
                actionExecutedContext.Response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<APIResultModel>(new APIResultModel()
                    {
                        code = (int)CommonEnumInternal.ProgErrorString.Key_999998,
                    }, new JsonMediaTypeFormatter())
                };
            }
            base.OnException(actionExecutedContext);
        }
    }
}
