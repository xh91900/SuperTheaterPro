using System;
using SuperProducer.Framework.Model;

namespace SuperTheaterPro.Business.Model
{
    public class CommonEnumInternal : CommonEnum
    {
        /// <summary>
        /// 系统扩展枚举类型
        /// </summary>
        public enum SystemExtendType
        {
            #region "基础数据(1-9999)"

            PlatformType = 1,
            LanguageType = 2,
            ProgErrorRankType = 3,
            ProgErrorNotifyType = 4,

            #endregion

            #region "业务数据(10000-49999)"

            UserStatus = 10000,
            SendLogType = 10001,


            #region "订单数据(40000-49999)"

            OrderType = 40000,

            #endregion

            #endregion
        }

        #region "扩展类型枚举"

        public enum PlatformType
        {
            Unknown = 0,
            Api = 1,
            Android = 2,
            IOS = 3,
            Admin = 99
        }

        public enum ProgErrorRankType
        {
            Rank_1 = 1,
            Rank_2 = 2,
            Rank_3 = 3,
            Rank_4 = 4,
            Rank_5 = 5,
        }

        public enum ProgErrorNotifyType
        {
            Sms = 1,
            Email = 2
        }

        public enum UserStatus
        {
            Freeze = 1,
            Normal = 99
        }

        public enum SendLogType
        {
            Sms = 1,
            Email = 2
        }

        public enum OrderType
        {
            Recharge = 1,
            Withdraw = 2,
            Refund = 3,
            Buy = 50,
            Activity = 200
        }

        #endregion
    }
}
