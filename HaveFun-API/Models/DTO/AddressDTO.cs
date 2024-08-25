using System.Text.Json.Serialization;

namespace HaveFun_API.Models.DTO
{
	/// <summary>
	/// 地址DTO
	/// </summary>
	public class AddressBaseDTO
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

		/// <summary>
		/// 區碼
		/// </summary>
		[JsonPropertyName("dode")]
		public string Code { get; set; } = "";
	}

	/// <summary>
	/// 更新地址
	/// </summary>
	public class AddressDTO : AddressBaseDTO
	{
		/// <summary>
		/// 編號
		/// </summary>
		[JsonPropertyName("ID")]
		public int ID { get; set; } = 0;
	}
}
