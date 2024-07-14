using System.Text.Json.Serialization;

namespace HaveFun_API.Models.VO
{
	/// <summary>
	/// 地址清單
	/// </summary>
	public class AddressListVO
	{
		/// <summary>
		/// 清單
		/// </summary>
		[JsonPropertyName("list")]
		public List<AddressVO> List { get; set; } = new List<AddressVO>();
	}

	/// <summary>
	/// 地址
	/// </summary>
	public class AddressVO
	{
		/// <summary>
		/// 編號
		/// </summary>
		[JsonPropertyName("ID")]
		public int ID { get; set; } = 0;

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
		[JsonPropertyName("code")]
		public string Code { get; set; } = "";
	}
}
