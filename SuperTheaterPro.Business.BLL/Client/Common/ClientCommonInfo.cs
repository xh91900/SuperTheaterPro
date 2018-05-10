using SuperProducer.Core.Utility;
using SuperProducer.Framework.BLL.ExtendType;
using SuperTheaterPro.Business.Model;

namespace SuperTheaterPro.Business.BLL.Client
{
    public static class ClientCommonInfo
    {
        /// <summary>
        /// 获取平台类型根据客户端识别码
        /// </summary>
        /// <param name="identifyKey">客户端识别码</param>
        /// <returns></returns>
        public static CommonEnumInternal.PlatformType GetPlatformType(string identifyKey)
        {
            if (!string.IsNullOrEmpty(identifyKey))
            {
                var data = ExtendTypeCommonInfo.GetSystemExtendTypeDataKeyByRemark((long)CommonEnumInternal.SystemExtendType.PlatformType, identifyKey);
                if (!string.IsNullOrEmpty(data))
                {
                    return (CommonEnumInternal.PlatformType)ConvertHelper.GetInt(data, 0);
                }
            }
            return CommonEnumInternal.PlatformType.Unknown;
        }
    }
}
