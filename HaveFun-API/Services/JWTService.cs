using HaveFun_API.Interface.IServices;
using HaveFun_API.Models.DTO;
using HaveFun_API.Schafold;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
		private readonly TokenValidationParameters _tokenValidationParameters;

		/// <summary>
		/// 建構子
		/// </summary>
		public JWTService(TokenValidationParameters tokenValidationParameters)
		{
			_tokenValidationParameters = tokenValidationParameters;
		}

		/// <summary>
		/// 產生Token
		/// </summary>
		/// <param name="dto"></param>
		/// <param name="Access"></param>
		/// <returns></returns>
		public (string token, string refreshToken) GenerateToken(MemberDTO dto, string Access)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(Global.JWTSecret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					//https://blog.poychang.net/authenticating-jwt-tokens-in-asp-net-core-webapi/
					new Claim(JwtRegisteredClaimNames.NameId, dto.ID.ToString()),
					new Claim(JwtRegisteredClaimNames.Sub, Access),
				}),
				Expires = DateTime.Now.AddMinutes(30),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
			};
			var SecurityToken = tokenHandler.CreateToken(tokenDescriptor);
			var token = tokenHandler.WriteToken(SecurityToken);
			var refreshToken = Guid.NewGuid().ToString();
			return (token, refreshToken);
		}

		/// <summary>
		/// 解析權杖為宣告
		/// </summary>
		/// <returns></returns>
		public Dictionary<string, string> ParseToeknToClaim(string token)
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

		// 驗證成功則重新刷新Token
		/// <summary>
		/// 驗證
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public async Task<bool> Verify(string token)
		{
			//建立JwtSecurityTokenHandler
			var tokenHandler = new JwtSecurityTokenHandler();
			//驗證參數的Token，回傳SecurityToken
			var tokenInVerification = tokenHandler.ValidateToken(token, _tokenValidationParameters, out SecurityToken validatedToken);
			if (validatedToken is JwtSecurityToken jwtSecurityToken)
			{
				//檢核Token的演算法
				var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

				if (!result)
				{
					return false;
				}
			}
			//string ID = tokenInVerification.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.NameId).Value;
			//檢測 ID是不是登入者
			return true;
		}

	}
}
