using HaveFun_API.Interface.IRepositories;
using HaveFun_API.Interface.IServices;
using HaveFun_API.Models.DTO;
using HaveFun_API.Models.PO;
using HaveFun_API.Models.VO;
using HaveFun_API.Schafold;
using HaveFun_API.Utility;
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
		private readonly IAuthorityRepository _authorityRepository;

		/// <summary>
		/// 建構子
		/// </summary>
		public LoginService(HttpClient httpClient,
							IMemberRepository memberRepository,
							IJWTService jwtService,
							IAuthorityRepository authorityRepository)
		{
			_httpClient = httpClient;
			_memberRepository = memberRepository;
			_jwtService = jwtService;
			_authorityRepository = authorityRepository;
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

			var googleAccessToken = tokenResponse.AccessToken ?? "";

			if (googleAccessToken == "")
			{
				return result;
			}

			// 此註解是紀錄 Google response有 refresh token可以使用
			//var refreshToken = tokenResponse.RefreshToken;
			_httpClient.SetBearerToken(googleAccessToken);
			var userInfoResponse = await _httpClient.GetAsync("https://www.googleapis.com/oauth2/v3/userinfo");
			if (!userInfoResponse.IsSuccessStatusCode)
			{
				return result;
			}

			var userInfo = await userInfoResponse.Content.ReadAsStringAsync();
			var user = JsonConvert.DeserializeObject<GoogleInfoDTO>(userInfo);
			var mail = user?.Email;
			var name = user?.Name;

			if (mail == null)
			{
				return result;
			}

			var login = await Login(new LoginDTO
			{
				Mail = mail
			}, true);

			if (login.result)
			{
				result.IsMember = true;
				result.Token = login.model.AccessToken;
			}
			result.Mail = mail;
			result.Name = name ?? "";
			return result;
		}

		/// <summary>
		/// 登入
		/// </summary>
		/// <param name="dto">登入模型</param>
		/// <param name="isGoogle">是否為Google登入</param>
		/// <returns></returns>
		public async Task<(bool result,string msg, MemberLoginVO model)> Login(LoginDTO dto, bool isGoogle)
		{
			var model = new MemberLoginVO();
			var member = await _memberRepository.GetByMail(dto.Mail);
			if (member.ID <= 0)
				return (false, "帳號或密碼錯誤", model);

			if (!isGoogle)
			{
				var MD5password = Tool.MD5(dto.Password);
				if (MD5password != member.Password)
					return (false, "帳號或密碼錯誤", model);
			}

			model = await GetToken(member);

			if (string.IsNullOrEmpty(model.AccessToken))
				return (false, "獲取token失敗", model);
			if (string.IsNullOrEmpty(model.RefreshToken))
				return (false, "獲取token失敗", model);

			return (true, "成功", model);
		}

		/// <summary>
		/// 取得Token
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		private async Task<MemberLoginVO> GetToken(MemberPO dto)
		{
			var MemberLoginVO = new MemberLoginVO();
			var access = await _authorityRepository.GetAcess(dto.ID);
			var accessToken = _jwtService.GenerateToken(dto, access);
			var refreshToken = _jwtService.GenerateRefreshToken(dto.ID);
			var update = await _memberRepository.Update(new MemberDTO
			{
				ID = dto.ID,
				AccessToken = accessToken,
				RefreshToken = refreshToken.Token,
				Expiration = refreshToken.Expiration
			});
			if (!update)
				return MemberLoginVO;
			MemberLoginVO.AccessToken = accessToken;
			MemberLoginVO.RefreshToken = refreshToken.Token;
			return MemberLoginVO;
		}
	}
}
