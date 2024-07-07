namespace HaveFun_API.Models.DTO
{
	/// <summary>
	/// google登入
	/// </summary>
	public class AuthorityMemberDTO
	{
		/// <summary>
		/// 郵箱
		/// </summary>
		public string Mail { get; set; } = "";

		/// <summary>
		///Token
		/// </summary>
		public string RefreshToken { get; set; } = "";
	}
}
