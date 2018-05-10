using SuperProducer.Framework.BLL.ProgString;
using SuperProducer.Framework.Model;
using SuperTheaterPro.Framework.Utility.Config;
using System.Text.RegularExpressions;

namespace SuperTheaterPro.Business.BLL
{
    public class APIResultModel : Model.BusinessResultModel
    {
        public APIResultModel(CommonEnum.ProgErrorString enumKey) : base((int)enumKey) { }

        public APIResultModel(int rightCode = 0) : base(rightCode) { }

        public APIResultModel(Model.BusinessResultModel result) : base(result) { }

        public override void Refresh()
        {
            if (this.AutoChangeMsg)
            {
                var platformType = CachedFileConfigContext.Current.SiteConfig.PlatformType;
                if (platformType > 0 && this.code > 0)
                {
                    var progStringValue = ProgStringCommonInfo.GetProgStringValue(platformType, this.code.ToString());
                    if (!string.IsNullOrEmpty(progStringValue))
                    {
                        this.msg = progStringValue;

                        var formatRegx = @"\{[0-9]{1,2}\}"; // 支持连续的0-99个参数{0},{1}...
                        var needFormat = Regex.IsMatch(this.msg, formatRegx);
                        try
                        {
                            if (needFormat)
                            {
                                this.msg = string.Format(this.msg, this.MsgFormatParameter.ToArray());
                            }
                        }
                        catch
                        {
                            if (needFormat)
                            {
                                this.msg = Regex.Replace(this.msg, formatRegx, string.Empty);
                            }
                        }
                    }
                }
            }

            if (this.AutoChangeCode)
            {
                this.code = this.code == this.RightCode ? (int)CommonEnum.ProgErrorString.Key_200 : this.code;
            }
        }
    }
}
