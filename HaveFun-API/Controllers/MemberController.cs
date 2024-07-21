using HaveFun_API.Enum;
using HaveFun_API.Examples;
using HaveFun_API.Interface.IServices;
using HaveFun_API.Models.DTO;
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

		/// <summary>
		/// 建構子
		/// </summary>
		public MemberController(IMemberService memberService)
		{
			_memberService = memberService;
		}

		/// <summary>
		/// 新增成員
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPost("Insert")]
		[SwaggerRequestExample(typeof(MemberBaseDTO), typeof(MemberBaseExample))]
		[ProducesResponseType(typeof(APIResponseExample<string>), statusCode: 200)]
		public async Task<Dictionary<string, object>> Insert(MemberBaseDTO dto)
		{
			var ResultCode = ResultCodeType.Unknow;
			var ResultMessage = "";
			StringBuilder errorMessage = new StringBuilder();
			Tool.CheckParam(string.IsNullOrEmpty(dto.Name), errorMessage, "未填寫名稱");
			Tool.CheckParam(string.IsNullOrEmpty(dto.Mail), errorMessage, "未填寫郵件");
			Tool.CheckParam(string.IsNullOrEmpty(dto.Password), errorMessage, "未填寫密碼");
			Tool.CheckParam(string.IsNullOrEmpty(dto.NickName), errorMessage, "未填寫暱稱");
			if (errorMessage.Length > 0)
			{
				ResultCode = ResultCodeType.Fail;
				ResultMessage = errorMessage.ToString();
			}
			else
			{
				var Result = await _memberService.Insert(dto);
				ResultCode = Result.Result ? ResultCodeType.Success : ResultCodeType.Fail;
				ResultMessage = Result.Msg;
			}
			return new Dictionary<string, object>
			{
				{Const.ResultCode, ResultCode},
				{Const.ResultMessage, ResultMessage}
			};
		}
	}
}
