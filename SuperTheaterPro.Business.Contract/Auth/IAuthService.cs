using SuperTheaterPro.Business.Model;

namespace SuperTheaterPro.Business.Contract.Auth
{
    public interface IAuthService
    {
        /// <summary>
        /// 校验用户Token
        /// </summary>
        BusinessResultModel TokenIsValid(string token, byte platformType);
    }
}
