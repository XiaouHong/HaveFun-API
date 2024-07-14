using HaveFun_API.Interface.IRepositories;
using HaveFun_API.Interface.IServices;
using HaveFun_API.Models.DTO;
using HaveFun_API.Schafold;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace HaveFun_API.Services
{
    /// <summary>
    /// 認證
    /// </summary>
    public class LoginService : ILoginService
	{
		private readonly HttpClient _httpClient;
		private readonly IMemberRepository _memberRepository;
		private readonly IJWTService _jwtService;

		/// <summary>
		/// 建構子
		/// </summary>
		public LoginService(HttpClient httpClient,
							IMemberRepository memberRepository,
							IJWTService jwtService)
		{
			_httpClient = httpClient;
			_memberRepository = memberRepository;
			_jwtService = jwtService;
		}

		/// <summary>
		/// 認證
		/// </summary>
		/// <returns></returns>
		public string Authorize()
		{
			var authorizeUrl = new RequestUrl("https://accounts.google.com/o/oauth2/v2/auth").CreateAuthorizeUrl(
				clientId: Global.ClientId,
				responseType: "code",
				scope: "openid email profile",
				redirectUri: Global.RedirectUri,
				state: "random_state_string");
			return authorizeUrl;
		}

		/// <summary>
		/// 用Token拿google個人資料
		/// </summary>
		/// <param name="code"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		public async Task<GoogleLoginDTO> GooleLogin(string code, string state)
		{
			var result = new GoogleLoginDTO();
			// 檢查 state 是否匹配以防止 CSRF 攻擊
			if (state != "random_state_string")
			{
				return result;
			}
			var tokenResponse = await _httpClient.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
			{
				Address = "https://oauth2.googleapis.com/token",
				ClientId = Global.ClientId,
				ClientSecret = Global.ClientSecret,
				Code = code,
				RedirectUri = Global.RedirectUri
			});

			if (tokenResponse.IsError)
			{
				return result;
			}

			var accessToken = tokenResponse.AccessToken;
			var refreshToken = tokenResponse.RefreshToken;
			_httpClient.SetBearerToken(accessToken);
			var userInfoResponse = await _httpClient.GetAsync("https://www.googleapis.com/oauth2/v3/userinfo");
			if (!userInfoResponse.IsSuccessStatusCode)
			{
				return result;
			}

			var userInfo = await userInfoResponse.Content.ReadAsStringAsync();
			var user = JsonConvert.DeserializeObject<GoogleInfoDTO>(userInfo);
			var mail = user.Email;
			var name = user.Name;

			var member = await _memberRepository.GetByMail(mail);

			if (member.ID > 0)
			{
				var tokens = _jwtService.GenerateToken(member, "");
				var updateToken = await _memberRepository.Update(new Models.DTO.MemberDTO
				{
					Token = tokens.token,
					RefreshToken = tokens.refreshToken,
				});
				if(!updateToken) { return result; }
				result.IsMember = true;
				result.Token = tokens.token;
			}
			result.Mail = mail;
			result.Name= name;
			return result;
		}
	}
}
