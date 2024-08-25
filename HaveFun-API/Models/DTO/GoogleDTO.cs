using System.Text.Json.Serialization;

namespace HaveFun_API.Models.DTO
{
	/// <summary>
	/// GoogleDTO
	/// </summary>
	public class GoogleDTO
	{
		/// <summary>
		/// 回傳state
		/// </summary>
		[JsonPropertyName("state")]
		public string State { get; set; } = "";

		/// <summary>
		/// 回傳code
		/// </summary>
		[JsonPropertyName("code")]
		public string Code { get; set; } = "";
	}

	/// <summary>
	/// Google資訊
	/// </summary>
	public class GoogleInfoDTO
	{
		/// <summary>
		/// 郵件
		/// </summary>
		[JsonPropertyName("email")]
		public string Email { get; set; } = "";

		/// <summary>
		/// 名稱
		/// </summary>
		[JsonPropertyName("name")]
		public string Name { get; set; } = "";
	}

	/// <summary>
	/// google登入
	/// </summary>
	public class GoogleLoginDTO
	{
		/// <summary>
		/// Access Token
		/// </summary>
		[JsonPropertyName("token")]
		public string Token { get; set; } = "";

		/// <summary>
		/// 是否為會員
		/// </summary>
		[JsonPropertyName("isMember")]
		public bool IsMember { get; set; } = false;

		/// <summary>
		/// google名稱
		/// </summary>
		[JsonPropertyName("name")]
		public string Name { get; set; } = "";

		/// <summary>
		/// google郵件
		/// </summary>
		[JsonPropertyName("mail")]
		public string Mail { get; set; } = "";
	}
}
