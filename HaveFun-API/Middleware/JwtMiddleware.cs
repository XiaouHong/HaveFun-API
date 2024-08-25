using Microsoft.IdentityModel.Tokens;

namespace HaveFun_API.Middleware
{
	/// <summary>
	/// Jwt Middleware
	/// </summary>
	public class JwtMiddleware
	{
		private readonly RequestDelegate _next;

		/// <summary>
		/// 建構子
		/// </summary>
		/// <param name="next"></param>
		public JwtMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		/// <summary>
		/// 投放下一步
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public async Task Invoke(HttpContext context)
		{
			// 先抓取到access token

			// 如 access過期 抓取refresh token
			// var refreshToken = context.Request.Cookies["refreshToken"];

			// 驗證refresh token
			// if (refreshToken != null)
			// var newAccessToken = tokenService.RefreshToken(refreshToken);

			// 重新塞入access
			// context.Response.Headers.Add

			var userIdentity = context.User.Identities.FirstOrDefault();

			if (userIdentity != null && userIdentity.IsAuthenticated)
			{
				context.Items["UserId"] = userIdentity.Claims.First().Value;
			}

			await _next(context);
		}
	}
}
