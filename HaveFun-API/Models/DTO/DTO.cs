using System.Text.Json.Serialization;

namespace HaveFun_API.Models.DTO
{
	/// <summary>
	/// 基底
	/// </summary>
	public class DTO
	{
		/// <summary>
		/// 第幾頁
		/// </summary>
		[JsonPropertyName("pageNow")]
		public int PageNow { get; set; } = 1;

		/// <summary>
		/// 出現幾筆
		/// </summary>
		[JsonPropertyName("pageShow")]
		public int PageShow { get; set; } = 10;
	}
}
