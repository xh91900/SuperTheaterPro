using SuperProducer.Core.Utility;
using SuperProducer.Framework.BLL.ExtendType;
using SuperTheaterPro.Business.Model;

namespace SuperTheaterPro.Business.BLL.Client.Common
{
    public static class LanguageCommonInfo
    {
        /// <summary>
        /// 获取语言类型根据客户端语言
        /// </summary>
        /// <param name="language">客户端语言</param>
        /// <returns></returns>
        public static CommonEnumInternal.LanguageType GetLanguageType(string language)
        {
            if (!string.IsNullOrEmpty(language))
            {
                var data = ExtendTypeCommonInfo.GetSystemExtendTypeDataKeyByRemark((long)CommonEnumInternal.SystemExtendType.LanguageType, language);
                if (!string.IsNullOrEmpty(data))
                {
                    return (CommonEnumInternal.LanguageType)ConvertHelper.GetInt(data, 1);
                }
            }
            return CommonEnumInternal.LanguageType.zhcn;
        }
    }
}
