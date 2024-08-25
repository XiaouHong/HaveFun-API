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

		/// <summary>
		///Token
		/// </summary>
		public string AccessToken { get; set; } = "";
	}

	/// <summary>
	/// RefreshToken
	/// </summary>
	public class RefreshTokenDTO
	{
		/// <summary>
		///Token
		/// </summary>
		public string Token { get; set; } = "";
		/// <summary>
		///Token
		/// </summary>
		public DateTime Expiration { get; set; } = DateTime.MinValue;
		/// <summary>
		///Token
		/// </summary>
		public int UserId { get; set; } = 0;
	}
}
