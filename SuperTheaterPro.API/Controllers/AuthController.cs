using SuperTheaterPro.Business.BLL;
using SuperTheaterPro.Business.Contract.Auth;
using SuperTheaterPro.Business.Model;
using SuperTheaterPro.Business.Model.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperTheaterPro.API.Controllers
{
    public class AuthController : Logic.ApiControllerBase
    {
        private IAuthService authService = null;

        public AuthController(IAuthService auth)
        {
            authService = auth;
        }

        [HttpPost]
        public APIResultModel TokenVerify(MDA_IN_TokenVerify model)
        {
            if (ModelState.IsValid)
            {
                return new APIResultModel(authService.TokenIsValid(model.token, model.type));
            }
            return new APIResultModel(200) { code = (int)CommonEnumInternal.ProgErrorString.Key_999996 };
        }
    }
}
