using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace HaveFun_API.Utility
{
	/// <summary>
	/// 工具
	/// </summary>
	public static class Tool
	{
		/// <summary>
		/// 取得列舉敘述
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string GetDescriptionText(this System.Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());
			DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
			return attributes.Length > 0 ? attributes[0].Description : value.ToString();
		}

		/// <summary>
		/// 檢查參數
		/// </summary>
		/// <param name="isempty"></param>
		/// <param name="APIMsg"></param>
		/// <param name="Msg"></param>
		/// <returns></returns>
		public static StringBuilder CheckParam(bool isempty, StringBuilder APIMsg, string Msg)
		{
			if(isempty)
			{
				APIMsg.Append($"，{Msg}");
			}
			return APIMsg;
		}

		/// <summary>
		/// MD5
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string MD5(string value)
		{
			var dataBytes = Encoding.UTF8.GetBytes(value);
			var hashBytes = System.Security.Cryptography.MD5.HashData(dataBytes);
			return Convert.ToBase64String(hashBytes);
		}

		/// <summary>
		/// 是否為正確的郵件格式
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public static bool IsValidEmail(string email)
		{
			return Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
		}

		/// <summary>
		/// 是否為正確的密碼格式
		/// </summary>
		/// <param name="password"></param>
		/// <returns></returns>
		public static bool IsValidPassword(string password)
		{
			return Regex.IsMatch(password, @"^(?=.*[0-9])(?=.*[a-zA-Z])(?=.*[!@#$.\%\^\&\*\(\)])[0-9a-zA-Z!@#$.\%\^\&\*\(\)]{8,12}$");
		}
	}
}
