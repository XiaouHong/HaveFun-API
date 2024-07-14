using HaveFun_API.Models.DTO;

namespace HaveFun_API.Interface.IServices
{
    public interface ILoginService
    {
        string Authorize();
        Task<GoogleLoginDTO> GooleLogin(string code, string state);
    }
}