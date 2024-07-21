using HaveFun_API.Enum;
using System.Text.Json.Serialization;

namespace HaveFun_API.Models.DTO
{
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
		[JsonPropertyName("token")]
		public string Token { get; set; } = "";

		/// <summary>
		/// 權限類別
		/// </summary>
		[JsonPropertyName("authorityType")]
		public AuthorityType AuthorityType { get; set; } = AuthorityType.Unknow;
	}
}
