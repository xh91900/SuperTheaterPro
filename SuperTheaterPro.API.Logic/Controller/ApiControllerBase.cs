using SuperTheaterPro.Business.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace SuperTheaterPro.API.Logic
{
    public class ApiControllerBase : SuperProducer.Framework.Web.WebApiController
    {
        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            #region "客户端参数初始化"

            if (!string.IsNullOrEmpty(HeaderContext.Current.ClientIdentify))
            {
                ClientContext.Current.Initializer = HeaderContext.Current;
            }
            else if (!string.IsNullOrEmpty(CookieContext.Current.ClientIdentify))
            {
                ClientContext.Current.Initializer = CookieContext.Current;
            }

            #endregion

            return base.ExecuteAsync(controllerContext, cancellationToken);
        }
    }
}
