using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace SuperTheaterPro.Business.Model
{
    public class UserWallet
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
        /// 剩余金额(可提现)
        /// </summary>
        public decimal LeftMoney { get; set; }

        /// <summary>
        /// 消费金额(不可提现)
        /// </summary>
        public decimal ConsumeMoney { get; set; }

        /// <summary>
        /// 冻结的剩余金额(可提现)
        /// </summary>
        public decimal FrozenLeftMoney { get; set; }

        /// <summary>
        /// 冻结的消费金额(不可提现)
        /// </summary>
        public decimal FrozenConsumeMoney { get; set; }

        /// <summary>
        /// 已使用的金额
        /// </summary>
        public decimal UsedMoney { get; set; }

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

        /// <summary>
        /// 版本代码
        /// </summary>
        public DateTime VersionCode { get; set; }

    }
}

