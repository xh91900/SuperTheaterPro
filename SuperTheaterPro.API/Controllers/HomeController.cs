using SuperTheaterPro.API.Logic;
using SuperTheaterPro.Business.Contract.Auth;
using System.Web.Mvc;

namespace SuperTheaterPro.API.Controllers
{
    public class HomeController : MvcControllerBase
    {
        protected override string PageTitle => "超级剧场";

        public HomeController(IAuthService authService)
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
