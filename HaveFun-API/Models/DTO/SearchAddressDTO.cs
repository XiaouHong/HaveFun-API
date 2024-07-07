using System.Text.Json.Serialization;

namespace HaveFun_API.Models.DTO
{
	/// <summary>
	/// 搜尋地址
	/// </summary>
	public class SearchAddressDTO : DTO
	{
		/// <summary>
		/// 國家
		/// </summary>
		[JsonPropertyName("country")]
		public string Country { get; set; } = "";

		/// <summary>
		/// 城市
		/// </summary>
		[JsonPropertyName("city")]
		public string City { get; set; } = "";

		/// <summary>
		/// 城鎮
		/// </summary>
		[JsonPropertyName("town")]
		public string Town { get; set; } = "";
	}
}
