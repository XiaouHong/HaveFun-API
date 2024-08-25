using System.Text.Json.Serialization;

namespace HaveFun_API.Models.VO
{
	public class MemberVO
	{
	}

	/// <summary>
	/// 成員登入
	/// </summary>
	public class MemberLoginVO
	{
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
	}
}
