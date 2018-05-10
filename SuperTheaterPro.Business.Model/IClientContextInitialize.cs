using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTheaterPro.Business.Model
{
    public interface IClientContextInitialize
    {
        /// <summary>
        /// 客户端识别码
        /// </summary>
        string ClientIdentify { get; set; }

        /// <summary>
        /// 客户端语言
        /// </summary>
        string ClientLanguage { get; set; }

        /// <summary>
        /// 客户端令牌
        /// </summary>
        string ClientToken { get; set; }
    }
}
