using HaveFun_API.Models.DTO;
using Swashbuckle.AspNetCore.Filters;

namespace HaveFun_API.Examples
{
	/// <summary>
	/// 模型範例
	/// </summary>
	public class MemberBaseExample : IExamplesProvider<MemberBaseDTO>
	{
		/// <summary>
		/// 建構子
		/// </summary>
		/// <returns></returns>
		public MemberBaseDTO GetExamples()
		{
			return new MemberBaseDTO
			{
				Mail = "",
				Password = "",
				Name = "",
				NickName = "",
				Note = ""
			};
		}
	}
}
