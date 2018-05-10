using SuperProducer.Core.Utility;
using SuperProducer.Framework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTheaterPro.Business.DAL.Auth
{
    public class UserLoginToken
    {
        public static Model.UserLoginToken GetUserLoginToken(string token, byte platformType)
        {
            if (!string.IsNullOrEmpty(token) && platformType > 0)
            {
                var dataList = GetUserLoginToken(ids: null, token: token, platformType: platformType);
                if (dataList != null && dataList.Count == 1)
                {
                    return dataList.FirstOrDefault();
                }
            }
            return null;
        }

        public static List<Model.UserLoginToken> GetUserLoginToken(string ids = null, long userID = 0, string token = null, byte platformType = 0, bool? isDel = false)
        {
            using (var mainContext = new MainDbContext())
            {
                var where = PredicateExtensionses.True<Model.UserLoginToken>();

                if (!string.IsNullOrEmpty(ids))
                {
                    var tmpWhere = PredicateExtensionses.True<Model.UserLoginToken>();
                    var idsArray = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var item in idsArray)
                    {
                        var tempItem = ConvertHelper.GetLong(item, 0);
                        if (tempItem > 0)
                            tmpWhere = tmpWhere.Or(value => value.ID == tempItem);
                    }
                    where = where.And(tmpWhere);
                }

                if (userID > 0)
                    where = where.And(item => item.UserID == userID);

                if (!string.IsNullOrEmpty(token))
                    where = where.And(item => item.Token == token);

                if (platformType > 0)
                    where = where.And(item => item.PlatformType == platformType);

                if (isDel != null)
                    where = where.And(item => item.IsDel == isDel);

                return mainContext.FindAll(where);
            }
        }
    }
}
