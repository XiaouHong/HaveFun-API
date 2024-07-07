using HaveFun_API.Enum;
using System.Text.Json.Serialization;

namespace HaveFun_API.Examples
{
	/// <summary>
	/// API回應模型
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class APIResponseExample<T>
	{
		/// <summary>
		/// 結果代碼
		/// </summary>
		[JsonPropertyName("resultCode")]
		public ResultCodeType ResultCode { get; set; } = ResultCodeType.Success;

		/// <summary>
		/// 結果訊息
		/// </summary>
		[JsonPropertyName("resultMessage")]
		public string ResultMessage { get; set; } = "";

		/// <summary>
		/// 結果數量
		/// </summary>
		[JsonPropertyName("resultCount")]
		public int ResultCount { get; set; } = 0;

		/// <summary>
		/// 結果
		/// </summary>
		[JsonPropertyName("result")]
		public T Result { get; set; }
	}
}
