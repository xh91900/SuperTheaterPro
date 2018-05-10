using SuperProducer.Core.Cache;
using SuperProducer.Core.Utility;
using SuperTheaterPro.Business.Model;
using SuperTheaterPro.Framework.Utility.Config;

namespace SuperTheaterPro.Business.BLL
{
    public class CookieContext : IClientContextInitialize
    {
        public static CookieContext Current
        {
            get
            {
                return CacheHelper.GetItem<CookieContext>();
            }
        }


        /// <summary>
        /// cookie名字
        /// </summary>
        public enum CookieNames
        {
            identify = 1,
            lang = 2,
            token = 3,
        }

        private string Prefix
        {
            get { return CachedFileConfigContext.Current.SiteConfig.CookiePrefix; }
        }

        private int Expires
        {
            get { return CachedFileConfigContext.Current.SiteConfig.CookieExpiresMinute; }
        }

        private string GetCookieName(CookieNames name)
        {
            return string.Format("{0}{1}", this.Prefix, name.ToString());
        }

        /// <summary>
        /// 客户端识别码
        /// </summary>
        public string ClientIdentify
        {
            get
            {
                return WebCookieHelper.GetValue(GetCookieName(CookieNames.identify));
            }
            set
            {
                WebCookieHelper.Save(GetCookieName(CookieNames.identify), value, Expires);
            }
        }

        /// <summary>
        /// 客户端语言
        /// </summary>
        public string ClientLanguage
        {
            get
            {
                return WebCookieHelper.GetValue(GetCookieName(CookieNames.lang));
            }
            set
            {
                WebCookieHelper.Save(GetCookieName(CookieNames.lang), value, Expires);
            }
        }

        /// <summary>
        /// 客户端令牌
        /// </summary>
        public string ClientToken
        {
            get
            {
                return WebCookieHelper.GetValue(GetCookieName(CookieNames.token));
            }
            set
            {
                WebCookieHelper.Save(GetCookieName(CookieNames.token), value, Expires);
            }
        }

        #region "Cookie操作"

        /// <summary>
        /// 移除单个客户端Cookie
        /// </summary>
        public void Remove(CookieNames key)
        {
            WebCookieHelper.Save(GetCookieName(key), string.Empty, -1);
        }

        /// <summary>
        /// 移除所有客户端Cookie
        /// </summary>
        public void RemoveAll()
        {
            RemoveAll(null);
        }

        /// <summary>
        /// 移除所有客户端Cookie
        /// </summary>
        public void RemoveAll(params CookieNames[] ignoreItem)
        {
            var enumItems = EnumHelper.GetAllItem<CookieNames>();

            if (ignoreItem != null && ignoreItem.Length > 0)
            {
                foreach (var item in ignoreItem)
                    enumItems.Remove(item);
            }

            foreach (var item in enumItems)
            {
                Remove(item);
            }
        }

        #endregion
    }
}
