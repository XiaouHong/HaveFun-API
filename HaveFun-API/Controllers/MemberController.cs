using HaveFun_API.Enum;
using HaveFun_API.Examples;
using HaveFun_API.Interface.IServices;
using HaveFun_API.Models.DTO;
using HaveFun_API.Models.VO;
using HaveFun_API.Utility;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace HaveFun_API.Controllers
{
	/// <summary>
	/// 成員
	/// </summary>
	[Produces("application/json")]
	[Route("[controller]")]
	[ApiController]
	public class MemberController : ControllerBase
	{
		private readonly IMemberService _memberService;
		private readonly ILoginService _loginService;

		/// <summary>
		/// 建構子
		/// </summary>
		public MemberController(IMemberService memberService,
								ILoginService loginService)
		{
			_memberService = memberService;
			_loginService = loginService;
		}

		/// <summary>
		/// 新增成員
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPost("insert")]
		[SwaggerRequestExample(typeof(MemberBaseDTO), typeof(MemberBaseExample))]
		[ProducesResponseType(typeof(APIResponseExample<string>), statusCode: 200)]
		public async Task<Dictionary<string, object>> Insert(MemberBaseDTO dto)
		{
			var resultCode = ResultCodeType.Unknow;
			var resultMessage = "";
			var errorMessage = new StringBuilder();
			Tool.CheckParam(string.IsNullOrEmpty(dto.Name), errorMessage, "未填寫名稱");
			Tool.CheckParam(string.IsNullOrEmpty(dto.Mail), errorMessage, "未填寫郵件");
			Tool.CheckParam(string.IsNullOrEmpty(dto.Password), errorMessage, "未填寫密碼");
			Tool.CheckParam(string.IsNullOrEmpty(dto.NickName), errorMessage, "未填寫暱稱");
			if (errorMessage.Length > 0)
			{
				resultCode = ResultCodeType.Fail;
				resultMessage = errorMessage.ToString();
			}
			else
			{
				var result = await _memberService.Insert(dto);
				resultCode = result.Result ? ResultCodeType.Success : ResultCodeType.Fail;
				resultMessage = result.Msg;
			}
			return new Dictionary<string, object>
			{
				{Const.ResultCode, resultCode},
				{Const.ResultMessage, resultMessage}
			};
		}

		/// <summary>
		/// 登入
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPost("login")]
		[SwaggerRequestExample(typeof(LoginDTO), typeof(LoginExample))]
		[ProducesResponseType(typeof(APIResponseExample<string>), statusCode: 200)]
		public async Task<Dictionary<string, object>> Login(LoginDTO dto)
		{
			var resultCode = ResultCodeType.Unknow;
			var resultMessage = "";
			var errorMessage = new StringBuilder();
			var model = new MemberLoginVO();
			Tool.CheckParam(string.IsNullOrEmpty(dto.Mail), errorMessage, "未填寫郵件");
			Tool.CheckParam(string.IsNullOrEmpty(dto.Password), errorMessage, "未填寫密碼");
			if (errorMessage.Length > 0)
			{
				resultCode = ResultCodeType.Fail;
				resultMessage = errorMessage.ToString();
			}
			else
			{
				var result = await _loginService.Login(dto, false);
				resultCode = result.result ? ResultCodeType.Success : ResultCodeType.Fail;
				resultMessage = result.msg;
				model = result.model;
				Response.Cookies.Append("refreshToken", model.RefreshToken, new CookieOptions
				{
					HttpOnly = true,
					Secure = true, // 使用 HTTPS 時設置為 true
					SameSite = SameSiteMode.Strict
				});
			}
			return new Dictionary<string, object>
			{
				{Const.ResultCode, resultCode},
				{Const.ResultMessage, resultMessage},
				{Const.Result, model.AccessToken}
			};
		}
	}
}
