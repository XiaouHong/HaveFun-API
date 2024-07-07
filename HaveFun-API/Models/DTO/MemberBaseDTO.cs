using HaveFun_API.Enum;

namespace HaveFun_API.Models.DTO
{
	/// <summary>
	/// 會員
	/// </summary>
	public class MemberBaseDTO
	{
		/// <summary>
		/// 郵箱
		/// </summary>
		public string Mail { get; set; } = "";

		/// <summary>
		/// 名字
		/// </summary>
		public string Name { get; set; } = "";

		/// <summary>
		/// 暱稱
		/// </summary>
		public string NickName { get; set; } = "";

		/// <summary>
		/// 自我介紹
		/// </summary>
		public string Note { get; set; } = "";

		/// <summary>
		/// 權限類別
		/// </summary>
		public AuthorityType AuthorityType { get; set; } = AuthorityType.Unknow;

		/// <summary>
		/// RefreshToken
		/// </summary>
		public string RefreshToken { get; set; } = "";

		/// <summary>
		/// Token
		/// </summary>
		public string Token { get; set; } = "";
	}
}
