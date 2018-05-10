using SuperProducer.Core.Utility;
using SuperProducer.Framework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTheaterPro.Business.DAL.User
{
    public class UserInfo
    {
        public static Model.UserInfo GetInfo(string userMobile, string userPass, byte platformType)
        {
            if (!string.IsNullOrEmpty(userMobile) && !string.IsNullOrEmpty(userPass) && platformType > 0)
            {
                var dataList = GetList(userMobile: userMobile, userPass: userPass, platformType: platformType);
                if (dataList != null)
                    return dataList.FirstOrDefault();
            }
            return null;
        }

        public static Model.UserInfo GetInfo(long userID = 0, Guid? userGuid = null, string userMobile = null)
        {
            if (userID > 0 || userGuid.HasValue || !string.IsNullOrEmpty(userMobile))
            {
                var dataList = GetList(ids: userID.ToString(), userGuid: userGuid, userMobile: userMobile);
                if (dataList != null)
                    return dataList.FirstOrDefault();
            }
            return null;
        }

        public static List<Model.UserInfo> GetList(string ids = null, Guid? userGuid = null, string userName = null, string userPass = null,
            string userMobile = null, bool? userMobileActive = null,
            string userEmail = null, bool? userEmailActive = null,
            byte userStatus = 0,
            byte platformType = 0,
            bool? isDel = false)
        {
            using (var mainContext = new MainDbContext())
            {
                var where = PredicateExtensionses.True<Model.UserInfo>();

                if (!string.IsNullOrEmpty(ids))
                {
                    var tmpWhere = PredicateExtensionses.True<Model.UserInfo>();
                    var idsArray = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in idsArray)
                    {
                        var tempItem = ConvertHelper.GetLong(item, 0);
                        if (tempItem > 0)
                            tmpWhere = tmpWhere.Or(value => value.ID == tempItem);
                    }
                    where = where.And(tmpWhere);
                }

                if (userGuid != null && userGuid != Guid.Empty)
                    where = where.And(item => item.UserGuid == userGuid);

                if (!string.IsNullOrEmpty(userName))
                    where = where.And(item => item.UserName == userName);

                if (!string.IsNullOrEmpty(userPass))
                    where = where.And(item => item.UserPass == userPass);

                if (!string.IsNullOrEmpty(userMobile))
                    where = where.And(item => item.UserMobile == userMobile);

                if (userMobileActive != null)
                    where = where.And(item => item.UserMobileActive == userMobileActive);

                if (!string.IsNullOrEmpty(userEmail))
                    where = where.And(item => item.UserEmail == userEmail);

                if (userEmailActive != null)
                    where = where.And(item => item.UserEmailActive == userEmailActive);

                if (userStatus > 0)
                    where = where.And(item => item.UserStatus == userStatus);

                if (platformType > 0)
                    where = where.And(item => item.PlatformType == platformType);

                if (isDel != null)
                    where = where.And(item => item.IsDel == isDel);

                return mainContext.FindAll(where);
            }
        }
    }
}
