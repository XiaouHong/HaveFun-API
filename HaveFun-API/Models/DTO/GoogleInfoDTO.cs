using System.Text.Json.Serialization;

namespace HaveFun_API.Models.DTO
{
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
}
