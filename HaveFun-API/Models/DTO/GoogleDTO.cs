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
}
