using HaveFun_API.Enum;
using System.Text.Json.Serialization;

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
		[JsonPropertyName("mail")]
		public string Mail { get; set; } = "";

		/// <summary>
		/// 密碼
		/// </summary>
		[JsonPropertyName("password")]
		public string Password { get; set; } = "";

		/// <summary>
		/// 名字
		/// </summary>
		[JsonPropertyName("name")]
		public string Name { get; set; } = "";

		/// <summary>
		/// 暱稱
		/// </summary>
		[JsonPropertyName("nickName")]
		public string NickName { get; set; } = "";

		/// <summary>
		/// 自我介紹
		/// </summary>
		[JsonPropertyName("note")]
		public string Note { get; set; } = "";
	}

	/// <summary>
	/// 會員
	/// </summary>
	public class MemberDTO : MemberBaseDTO
	{
		/// <summary>
		/// 編號
		/// </summary>
		[JsonPropertyName("ID")]
		public int ID { get; set; } = 0;

		/// <summary>
		/// RefreshToken
		/// </summary>
		[JsonPropertyName("refreshToken")]
		public string RefreshToken { get; set; } = "";

		/// <summary>
		/// Token
		/// </summary>
		[JsonPropertyName("accessToken")]
		public string AccessToken { get; set; } = "";

		/// <summary>
		/// 過期時間
		/// </summary>
		[JsonPropertyName("expiration")]
		public DateTime Expiration { get; set; } = DateTime.MinValue;

		/// <summary>
		/// 權限類別
		/// </summary>
		[JsonPropertyName("authorityType")]
		public AuthorityType AuthorityType { get; set; } = AuthorityType.Unknow;
	}

	/// <summary>
	/// 登入
	/// </summary>
	public class LoginDTO
	{
		/// <summary>
		/// 郵箱
		/// </summary>
		[JsonPropertyName("mail")]
		public string Mail { get; set; } = "";

		/// <summary>
		/// 密碼
		/// </summary>
		[JsonPropertyName("password")]
		public string Password { get; set; } = "";
	}
}
