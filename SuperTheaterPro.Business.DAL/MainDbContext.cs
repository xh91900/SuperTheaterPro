using SuperProducer.Core.Config;
using SuperProducer.Framework.DAL;
using SuperProducer.Framework.Model;
using SuperTheaterPro.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SuperTheaterPro.Business.DAL
{
    public class MainDbContext : DbContextBase
    {
        public MainDbContext() : base(CachedFileConfigContext.Current.DaoConfig.Main, new LogDbContext())
        {
            Database.SetInitializer(new NullDatabaseInitializer<MainDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region "Fluent API"

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            #endregion
        }



        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T">继承ModelBase的实体类</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>返回修改后的实体</returns>
        public override T Update<T>(T entity)
        {
            entity.LastModifyTime = DateTime.Now;
            return base.Update(entity);
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T">继承ModelBase的实体类</typeparam>
        /// <param name="entity">实体</param>
        /// <returns>返回受影响的行数</returns>
        public override int Update<T>(IEnumerable<T> entity)
        {
            foreach (var item in entity)
            {
                item.LastModifyTime = DateTime.Now;
            }
            return base.Update(entity);
        }



        public DbSet<UserLoginToken> UserLoginToken { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UserBasicInfo> UserBasicInfo { get; set; }
        public DbSet<UserWallet> UserWallet { get; set; }
        
    }
}
