using SuperProducer.Core.Cache;
using SuperProducer.Core.Utility;
using SuperProducer.Framework.Model;
using SuperTheaterPro.Business.Model;

namespace SuperTheaterPro.Business.BLL
{
    public class HeaderContext : IClientContextInitialize
    {
        public static HeaderContext Current
        {
            get
            {
                return CacheHelper.GetItem<HeaderContext>();
            }
        }


        /// <summary>
        /// header名字
        /// </summary>
        public enum HeaderNames
        {
            identify = 1,
            lang = 2,
            token = 3,
        }

        private string GetHeaderName(HeaderNames name)
        {
            return string.Format("{0}", name.ToString());
        }

        /// <summary>
        /// 客户端识别Key
        /// </summary>
        public string ClientIdentify
        {
            get
            {
                return WebHeaderHelper.GetRequestHeader(GetHeaderName(HeaderNames.identify));
            }
            set { }
        }

        /// <summary>
        /// 客户端语言
        /// </summary>
        public string ClientLanguage
        {
            get
            {
                return WebHeaderHelper.GetRequestHeader(GetHeaderName(HeaderNames.lang));
            }
            set { }
        }

        /// <summary>
        /// 客户端令牌
        /// </summary>
        public string ClientToken
        {
            get
            {
                return WebHeaderHelper.GetRequestHeader(GetHeaderName(HeaderNames.token));
            }
            set { }
        }
    }
}
