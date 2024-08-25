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
				Mail = "lucky@gmail",
				Password = "password",
				Name = "Xiou-Hong",
				NickName = "apple",
				Note = "note"
			};
		}
	}

	/// <summary>
	/// 模型範例
	/// </summary>
	public class LoginExample : IExamplesProvider<LoginDTO>
	{
		/// <summary>
		/// 建構子
		/// </summary>
		/// <returns></returns>
		public LoginDTO GetExamples()
		{
			return new LoginDTO
			{
				Mail = "",
				Password = ""
			};
		}
	}

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
