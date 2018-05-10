using SuperProducer.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SuperTheaterPro.Business.Model.Ext
{
    [Serializable]
    public class MDE_LoginUserInfo
    {
        public long UserID { get; set; }

        public Guid UserGuid { get; set; }

        public Dictionary<string, object> OtherParas { get; set; }


        #region "OtherParas"

        public virtual void SetOtherParas(OtherParasKeys key, object value)
        {
            this.SetOtherParas(key.ToString(), value);
        }

        private void SetOtherParas(string key, object value)
        {
            this.OtherParas.UpdateItem(key, value);
        }

        public virtual object GetOtherParas(OtherParasKeys key)
        {
            return this.GetOtherParas(key.ToString());
        }

        public virtual T GetOtherParas<T>(OtherParasKeys key)
        {
            return this.GetOtherParas<T>(key.ToString(), default(T));
        }

        public virtual T GetOtherParas<T>(OtherParasKeys key, T defaultValue)
        {
            return this.GetOtherParas<T>(key.ToString(), defaultValue);
        }

        private object GetOtherParas(string key)
        {
            if (this.OtherParas != null && this.OtherParas.ContainsKey(key))
            {
                return this.OtherParas[key];
            }
            return null;
        }

        private T GetOtherParas<T>(string key, T defaultValue)
        {
            if (this.OtherParas != null && this.OtherParas.ContainsKey(key))
            {
                return ConvertHelper.ChangeType<T>(this.OtherParas[key]);
            }
            return default(T);
        }

        #endregion


        /// <summary>
        /// 标准的额外参数字典Key
        /// </summary>
        public enum OtherParasKeys
        {
            UserMobile = 1,
            UserWechatOpenID = 2,
            UserReferrerNo = 3,
            PageSize = 4,
            PageIndex = 5,
        }
    }
}
