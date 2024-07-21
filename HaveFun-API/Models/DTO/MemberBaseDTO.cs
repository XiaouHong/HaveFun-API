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
}
