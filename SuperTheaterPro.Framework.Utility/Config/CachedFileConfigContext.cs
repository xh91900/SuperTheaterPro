using SuperTheaterPro.Framework.Utility.Config.Model;
using Core = SuperProducer.Core.Config;

namespace SuperTheaterPro.Framework.Utility.Config
{
    public class CachedFileConfigContext : Core.CachedFileConfigContext
    {
        new public static CachedFileConfigContext Current = new CachedFileConfigContext();

        public SiteConfig SiteConfig
        {
            get
            {
                return base.Get<SiteConfig>();
            }
        }
    }
}
