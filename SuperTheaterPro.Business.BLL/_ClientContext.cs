using SuperProducer.Core.Cache;
using SuperProducer.Core.Utility;
using SuperProducer.Framework.Model;
using SuperTheaterPro.Business.Contract.Auth;
using SuperTheaterPro.Business.Model;
using SuperTheaterPro.Business.Model.Ext;
using System;
using System.Linq;

namespace SuperTheaterPro.Business.BLL
{
    public class ClientContext : IClientContext
    {
        public static ClientContext Current
        {
            get
            {
                return (ClientContext)CacheHelper.GetItem<IClientContext>(() =>
                {
                    return new ClientContext();
                });
            }
        }

        public MDE_LoginUserInfo UserInfo { get; set; }

        public CommonEnum.LanguageType ClientLanguage { get; set; }

        public byte PlatformType { get; set; }



        #region "Initialize"

        private IClientContextInitialize _Initializer;
        public IClientContextInitialize Initializer
        {
            get
            {
                return _Initializer;
            }
            set
            {
                _Initializer = value;
                this.Initialize();
            }
        }

        public void Initialize()
        {
            #region "ClientLanguage"

            if (!string.IsNullOrEmpty(this.Initializer.ClientLanguage))
            {
                var clientLangage = CommonEnumInternal.LanguageType.zhcn;
                var dataList = EnumHelper.GetEnumValueByEnumTitle<CommonEnumInternal.LanguageType>(this.Initializer.ClientLanguage);
                if (EnumHelper.IsDefined(typeof(CommonEnumInternal.LanguageType), dataList))
                {
                    clientLangage = dataList;
                }
                this.ClientLanguage = clientLangage;
            }

            #endregion

            #region "PlatformType"

            if (!string.IsNullOrEmpty(this.Initializer.ClientIdentify))
            {
                var clientIdentify = 0;
                var dataList = Client.ClientCommonInfo.GetPlatformType(this.Initializer.ClientIdentify);
                if (EnumHelper.IsDefined(typeof(CommonEnumInternal.PlatformType), dataList) && dataList != CommonEnumInternal.PlatformType.Unknown)
                {
                    clientIdentify = (int)dataList;
                }
                this.PlatformType = (byte)clientIdentify;
            }

            #endregion

            #region "UserInfo"

            if (!string.IsNullOrEmpty(this.Initializer.ClientToken) && this.PlatformType > 0)
            {
                var authService = Container.Current.Resolve<IAuthService>(findAllContainer: true);
                if (authService != null)
                {
                    var resultModel = authService.TokenIsValid(this.Initializer.ClientToken, this.PlatformType);
                    if (resultModel.code == resultModel.RightCode && resultModel.data is MDE_LoginUserInfo user)
                    {
                        this.UserInfo = user;
                    }
                }
            }

            #endregion
        }

        #endregion
    }
}
