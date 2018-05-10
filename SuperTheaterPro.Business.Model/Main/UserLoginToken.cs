using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SuperProducer.Framework.Model;

namespace SuperTheaterPro.Business.Model
{
    public class UserLoginToken : ModelBase
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// 登录令牌
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
    }
}

