using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SuperTheaterPro.API.Logic
{
    public class MvcControllerBase : SuperProducer.Framework.Web.WebMvcController
    {
        protected virtual string PageTitle { get; }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!string.IsNullOrEmpty(this.PageTitle))
            {
                ViewBag.Title = this.PageTitle;
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
