namespace HaveFun_API.Schafold
{
	/// <summary>
	/// 參數
	/// </summary>
	public static class Global
	{
		/// <summary>
		/// goole認證ID
		/// </summary>
		public static string ClientId = "";

		/// <summary>
		/// google認證Secret
		/// </summary>
		public static string ClientSecret = "";

		/// <summary>
		/// 返還網址
		/// </summary>
		public static string RedirectUri = "";

		/// <summary>
		/// JWT密碼
		/// </summary>
		public static string JWTSecret = "";

		/// <summary>
		/// Access到期時間
		/// </summary>
		public static double ExpiredTime = 0;

		/// <summary>
		/// Refresh到期時間
		/// </summary>
		public static double RefreshTokenExpiredTime = 0;

		/// <summary>
		/// 前端網址
		/// </summary>
		public static string FontEndUri = "";
	}
}
