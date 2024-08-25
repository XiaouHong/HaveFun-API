using HaveFun_API.Models.DTO;
using HaveFun_API.Models.PO;

namespace HaveFun_API.Interface.IServices
{
    public interface IJWTService
    {
		public string GenerateToken(MemberPO dto, string access);
		public Dictionary<string, string> ParseTokenToClaim(string token);
        public RefreshTokenDTO GenerateRefreshToken(int id);
		public bool ValidateRefreshToken(RefreshTokenDTO refreshToken);
	}
}