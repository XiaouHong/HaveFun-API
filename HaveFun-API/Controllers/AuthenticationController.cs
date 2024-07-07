using HaveFun_API.Enum;
using HaveFun_API.Examples;
using HaveFun_API.Interface.IServices;
using HaveFun_API.Schafold;
using HaveFun_API.Services;
using HaveFun_API.Utility;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HaveFun_API.Controllers
{
	/// <summary>
	/// 認證
	/// </summary>
	[Route("[controller]")]
	[ApiController]
	[Produces("application/json")]
	public class AuthenticationController : ControllerBase
	{
		private readonly ILoginService _authorizeService;

		/// <summary>
		/// 建構子
		/// </summary>
		public AuthenticationController(ILoginService authorizeService)
		{
			_authorizeService = authorizeService;
		}

		/// <summary>
		/// google登入
		/// </summary>
		/// <returns></returns>
		[HttpGet("authorize")]
		public IActionResult Authorize()
		{
			var authorizeUrl = _authorizeService.Authorize();
			return Redirect(authorizeUrl);
		}

		/// <summary>
		/// 二次取得token
		/// </summary>
		/// <param name="code"></param>
		/// <param name="state"></param>
		/// <returns></returns>
		[HttpPost("callback")]
		//[SwaggerRequestExample(typeof(Entry), typeof(EntryExample))]
		[ProducesResponseType(typeof(APIResponseExample<string>), statusCode: 200)]
		public async Task<Dictionary<string, object>> CallBack([FromQuery] string code, [FromQuery] string state)
		{
			var Result = await _authorizeService.GooleLogin(code, state);
			return new Dictionary<string, object>
			{
				{Const.ResultCode, Result ? ResultCodeType.Success : ResultCodeType.Fail},
				{Const.ResultMessage, Result ? "成功" : "失敗" }
			};
		}
	}
}
