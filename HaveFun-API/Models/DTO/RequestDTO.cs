using System.Text.Json.Serialization;

namespace HaveFun_API.Models.DTO
{
	/// <summary>
	/// 刪除
	/// </summary>
	public class RequestDTO
	{
		/// <summary>
		/// 編號
		/// </summary>
		[JsonPropertyName("ID")]
		public int ID { get; set; } = 0;
	}
}
