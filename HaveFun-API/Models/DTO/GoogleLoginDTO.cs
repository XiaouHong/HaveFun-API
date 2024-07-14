using System.Text.Json.Serialization;

namespace HaveFun_API.Models.DTO
{
	/// <summary>
	/// google登入
	/// </summary>
	public class GoogleLoginDTO
	{
		/// <summary>
		/// 登入token
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
