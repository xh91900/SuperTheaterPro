using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace SuperTheaterPro.Business.Model
{
    public class UserBasicInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 性别(0-保密,1-男,2-女)
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// Wechat
        /// </summary>
        public string Wechat { get; set; }

        /// <summary>
        /// 平台类型
        /// </summary>
        public int PlatformType { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime LastModifyTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 软删除(0-未删除,1-已删除)
        /// </summary>
        public bool IsDel { get; set; }

    }
}

