using SuperProducer.Core.Utility;

namespace SuperTheaterPro.API.Logic
{
    /// <summary>
    /// 系统启动器
    /// </summary>
    public class SystemLauncher
    {
        public enum SystemStatus
        {
            /// <summary>
            /// 启动
            /// </summary>
            Start = 1,

            /// <summary>
            /// 停止
            /// </summary>
            Stop = 2
        }

        /// <summary>
        /// 初始化[注意初始化顺序]
        /// </summary>
        public static void Initialize()
        {
            InitBasicConfig();
            InitSqlDependency();
            InitContainer();

            if (ProductionHelper.IsProductionEnvironment())
            {
                InitWechatParas();
                InitBaiduParas();
            }

            SystemConfigObject.Notify((int)SystemStatus.Start);
        }

        /// <summary>
        /// 卸载
        /// </summary>
        public static void Uninitialize()
        {
            SystemConfigObject.Notify((int)SystemStatus.Stop);
        }



        private static void InitBasicConfig()
        {
            SystemConfigObject.Add(new BasicConfigSubscriber());
        }

        private static void InitSqlDependency()
        {
            SystemConfigObject.Add(new SqlDependencySubscriber());
        }

        private static void InitContainer()
        {
            SystemConfigObject.Add(new ContainerSubscriber());
        }

        private static void InitWechatParas()
        {

        }

        private static void InitBaiduParas()
        {

        }

        internal static SystemLauncherEntity SystemConfigObject = new SystemLauncherEntity();
    }
}
