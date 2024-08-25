using HaveFun_API.Interface.IServices;
using HaveFun_API.Models.DTO;
using HaveFun_API.Models.PO;
using HaveFun_API.Schafold;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HaveFun_API.Services
{
    /// <summary>
    /// JWT
    /// </summary>
    public class JWTService : IJWTService
	{
		//private readonly TokenValidationParameters _tokenValidationParameters;
		private readonly IHttpContextAccessor _httpContextAccessor;

		/// <summary>
		/// 建構子
		/// </summary>
		public JWTService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		/// <summary>
		/// 產生Token
		/// </summary>
		/// <param name="dto"></param>
		/// <param name="access"></param>
		/// <returns></returns>
		public string GenerateToken(MemberPO dto, string access)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(Global.JWTSecret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					//https://blog.poychang.net/authenticating-jwt-tokens-in-asp-net-core-webapi/
					new Claim(ClaimTypes.NameIdentifier, dto.ID.ToString()),
					new Claim(ClaimTypes.Email, dto.Mail),
					new Claim(ClaimTypes.Name, dto.NickName),
					new Claim(JwtRegisteredClaimNames.Sub, access),
				}),

				Expires = DateTime.UtcNow.AddMinutes(Global.ExpiredTime),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
															SecurityAlgorithms.HmacSha256)
			};
			var SecurityToken = tokenHandler.CreateToken(tokenDescriptor);
			var token = tokenHandler.WriteToken(SecurityToken);
			return token;
		}

		/// <summary>
		/// 產生Refresh Token
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public RefreshTokenDTO GenerateRefreshToken(int id)
		{
			return new RefreshTokenDTO
			{
				Token = Guid.NewGuid().ToString(),
				Expiration = DateTime.UtcNow.AddHours(Global.RefreshTokenExpiredTime),
				UserId = id
			};
		}

		/// <summary>
		/// 解析權杖為宣告
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, string> ParseTokenToClaim(string token)
		{
			var Dictionary = new Dictionary<string, string>();
			var TokenHandler = new JwtSecurityTokenHandler();

			var JST = TokenHandler.ReadJwtToken(token);
			var Claims = JST.Claims.ToList();

			foreach (var Claim in Claims)
			{
				Dictionary.Add(Claim.Type, Claim.Value);
			}
			return Dictionary;
		}

		///// <summary>
		///// 驗證
		///// </summary>
		///// <param name="token"></param>
		///// <returns></returns>
		//public async Task<int> Verify(string token)
		//{
		//	//建立JwtSecurityTokenHandler
		//	var tokenHandler = new JwtSecurityTokenHandler();
		//	//驗證參數的Token，回傳SecurityToken
		//	var tokenInVerification = tokenHandler.ValidateToken(token, _tokenValidationParameters, out SecurityToken validatedToken);
		//	if (validatedToken is JwtSecurityToken jwtSecurityToken)
		//	{
		//		//檢核Token的演算法
		//		var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

		//		if (!result)
		//		{
		//			return 0;
		//		}
		//	}
		//	string id = tokenInVerification.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.NameId).Value ?? "";
		//	return int.Parse(id);
		//}
		
		/// <summary>
		/// 驗證Token
		/// </summary>
		/// <param name="refreshToken"></param>
		/// <returns></returns>
		public bool ValidateRefreshToken(RefreshTokenDTO refreshToken)
		{
			var user = _httpContextAccessor.HttpContext?.User;
			if (refreshToken == null || refreshToken.Expiration < DateTime.Now)
			{
				return false;
			}
			if (refreshToken.UserId.ToString() != user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value)
			{
				return false;
			}
			return true;
		}

	}
}
