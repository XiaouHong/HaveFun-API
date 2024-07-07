using HaveFun_API.Models.DTO;

namespace HaveFun_API.Interface.IServices
{
    public interface IJWTService
    {
        (string token, string refreshToken) GenerateToken(MemberDTO dto, string Access);
        Dictionary<string, string> ParseToeknToClaim(string token);
        Task<bool> Verify(string token);
    }
}