using SuperProducer.Core.Config;
using System;

namespace SuperTheaterPro.Framework.Utility.Config.Model
{
    #region "SiteConfig"

    /// <summary>
    /// 业务级配置
    /// </summary>
    [Serializable]
    public class SiteConfig : ConfigFileBase
    {
        /// <summary>
        /// 主站域名
        /// </summary>
        public string MainSiteDomain { get; set; }

        /// <summary>
        /// 客服电话[多个以|分隔]
        /// </summary>
        public string ServiceTel { get; set; }

        /// <summary>
        /// 平台类型
        /// </summary>
        public byte PlatformType { get; set; }

        /// <summary>
        /// Cookie前缀
        /// </summary>
        public string CookiePrefix { get; set; }

        /// <summary>
        /// Cookie过期时间[分]
        /// </summary>
        public int CookieExpiresMinute { get; set; }

        /// <summary>
        /// 登录令牌过期时间[天]
        /// </summary>
        public int LoginTokenExpiresDays { get; set; }

        /// <summary>
        /// 忽略认证的Url列表[逗号分隔]
        /// </summary>
        public string IgnoreAuthorizationUrls { get; set; }

        /// <summary>
        /// 用户对于本站的每次请求是否记录日志[0-不记录,1-记录]
        /// </summary>
        public bool ClientRequestWriteLog { get; set; }
    }

    #endregion
}
