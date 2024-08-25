using HaveFun_API.Models.DTO;
using HaveFun_API.Models.VO;

namespace HaveFun_API.Interface.IServices
{
    public interface ILoginService
    {
        string Authorize();
        Task<GoogleLoginDTO> GooleLogin(string code, string state);
		Task<(bool result, string msg, MemberLoginVO model)> Login(LoginDTO dto, bool isGoogle);
	}
}