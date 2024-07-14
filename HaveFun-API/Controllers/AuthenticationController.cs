using HaveFun_API.Enum;
using HaveFun_API.Examples;
using HaveFun_API.Interface.IServices;
using HaveFun_API.Models.DTO;
using HaveFun_API.Utility;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

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
		[ProducesResponseType(typeof(APIResponseExample<string>), statusCode: 200)]
		public Dictionary<string, object> Authorize()
		{
			var authorizeUrl = _authorizeService.Authorize();
			var isEmpty = !string.IsNullOrEmpty(authorizeUrl);
			return new Dictionary<string, object>
			{
				{Const.ResultCode, isEmpty ? ResultCodeType.Success : ResultCodeType.Fail},
				{Const.ResultMessage, isEmpty ? "成功" : "失敗" },
				{Const.Result, authorizeUrl }
			};
		}

		/// <summary>
		/// 二次取得token
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPost("callback")]
		[SwaggerRequestExample(typeof(GoogleDTO), typeof(GoogleExample))]
		[ProducesResponseType(typeof(APIResponseExample<GoogleLoginDTO>), statusCode: 200)]
		public async Task<Dictionary<string, object>> CallBack(GoogleDTO dto)
		{
			var Result = await _authorizeService.GooleLogin(dto.Code, dto.State);
			return new Dictionary<string, object>
			{
				{Const.ResultCode, ResultCodeType.Success},
				{Const.ResultMessage, "成功"},
				{Const.Result, Result }
			};
		}
	}
}
