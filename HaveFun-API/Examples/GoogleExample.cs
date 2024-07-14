using HaveFun_API.Models.DTO;
using Swashbuckle.AspNetCore.Filters;

namespace HaveFun_API.Examples
{
	/// <summary>
	/// 模型範例
	/// </summary>
	public class GoogleExample : IExamplesProvider<GoogleDTO>
	{
		/// <summary>
		/// 建構子
		/// </summary>
		/// <returns></returns>
		public GoogleDTO GetExamples()
		{
			return new GoogleDTO
			{
				State = "",
				Code = ""
			};
		}
	}
}
