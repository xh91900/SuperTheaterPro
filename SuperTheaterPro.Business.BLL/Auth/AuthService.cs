using SuperTheaterPro.Business.Contract.Auth;
using SuperTheaterPro.Business.Model;
using SuperTheaterPro.Business.Model.api;
using SuperTheaterPro.Framework.Utility.Config;
using System;
using System.Linq;

namespace SuperTheaterPro.Business.BLL.Auth
{
    public class AuthService : IAuthService
    {
        /// <summary>
        /// 校验用户Token
        /// </summary>
        public BusinessResultModel TokenIsValid(string token, byte platformType)
        {
            APIResultModel retVal = new APIResultModel(200000);
            retVal.code = 200001; // 令牌无效

            try
            {
                if (!string.IsNullOrEmpty(token))
                {
                    var loginTokenModel = DAL.Auth.UserLoginToken.GetUserLoginToken(token, platformType);
                    if (loginTokenModel != null)
                    {
                        retVal.code = 200002; // 令牌已超时
                        if (DateTime.Now.Subtract(loginTokenModel.LastLoginTime).TotalDays < CachedFileConfigContext.Current.SiteConfig.LoginTokenExpiresDays)
                        {
                            retVal.code = 200003; // 令牌已失效
                            var dataList = DAL.User.UserInfo.GetList(ids: loginTokenModel.UserID.ToString(), userStatus: (byte)CommonEnumInternal.UserStatus.Normal, platformType: ClientContext.Current.PlatformType);
                            if (dataList != null && dataList.Count == 1)
                            {
                                retVal.code = retVal.RightCode;
                                retVal.data = new MDA_OUT_AuthLogin()
                                {
                                    gid = dataList.FirstOrDefault().UserGuid.ToString(),
                                    token = token
                                };
                            }
                        }
                    }
                }
            }
            catch { retVal.code = (int)CommonEnumInternal.ProgErrorString.Key_999999; }
            return retVal;
        }
    }
}
