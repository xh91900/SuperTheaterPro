using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using SuperProducer.Framework.Model;

namespace SuperTheaterPro.Business.Model
{
    public class UserInfo : ModelBase
    {
        /// <summary>
        /// 用户唯一标识符
        /// </summary>
        public Guid UserGuid { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPass { get; set; }

        /// <summary>
        /// 密码混合加密随机串
        /// </summary>
        public string UserPassSalt { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string UserMobile { get; set; }

        /// <summary>
        /// 手机号码是否已激活
        /// </summary>
        public bool UserMobileActive { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// 电子邮箱是否已激活
        /// </summary>
        public bool UserEmailActive { get; set; }

        /// <summary>
        /// 用户状态(1-冻结,99-正常)
        /// </summary>
        public int UserStatus { get; set; }

        /// <summary>
        /// Remark
        /// </summary>
        public string Remark { get; set; }

    }
}

