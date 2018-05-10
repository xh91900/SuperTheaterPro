using Newtonsoft.Json;
using SuperProducer.Framework.Model;
using System.Collections.Generic;

namespace SuperTheaterPro.Business.Model
{
    public class BusinessResultModel : IResultModel
    {
        public int code { get; set; }

        public string msg { get; set; }

        public object data { get; set; }


        public BusinessResultModel(int rightCode = 0)
        {
            this.code = rightCode;

            this.RightCode = rightCode;
            this.MsgFormatParameter = new List<object>();
            this.AutoChangeMsg = true;
            this.AutoChangeCode = true;
        }

        public BusinessResultModel(BusinessResultModel result)
        {
            this.code = result.code;

            this.RightCode = result.RightCode;
            this.MsgFormatParameter = result.MsgFormatParameter;
            this.AutoChangeMsg = result.AutoChangeMsg;
            this.AutoChangeCode = result.AutoChangeCode;
        }

        public virtual void Refresh() { }



        #region "内部属性"

        /// <summary>
        /// 消息字段格式化所需的参数列表
        /// </summary>
        [JsonIgnore]
        public List<object> MsgFormatParameter { get; set; }

        /// <summary>
        /// 程序执行结果正确时的结果码
        /// </summary>
        [JsonIgnore]
        public int RightCode { get; set; }

        /// <summary>
        /// 是否自动更改msg
        /// </summary>
        [JsonIgnore]
        public bool AutoChangeMsg { get; set; }

        /// <summary>
        /// 自动更改code
        /// </summary>
        [JsonIgnore]
        public bool AutoChangeCode { get; set; }

        #endregion
    }
}
