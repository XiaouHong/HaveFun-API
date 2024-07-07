using System.Security.Cryptography;
using System.Text;

namespace HaveFun_API.Utility
{
	/// <summary>
	/// 對稱加密
	/// </summary>
	public class Aes
	{
		private static readonly System.Security.Cryptography.Aes _aes = System.Security.Cryptography.Aes.Create();

		static Aes()
		{
			//_aes.KeySize = 256; // 192、256
			_aes.Key = Encoding.ASCII.GetBytes("*3Un79ww_cv8&v5e"); // 1234567812345678
			_aes.IV = Encoding.ASCII.GetBytes("gt836-izc@3eW%s5"); // 1234567812345678
		}

		/// <summary>
		/// 加密
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string Encrypt(object value)
		{
			using (MemoryStream ms = new())
			using (CryptoStream cs = new(ms, _aes.CreateEncryptor(), CryptoStreamMode.Write))
			using (StreamWriter sw = new(cs))
			{
				sw.Write(value);
				sw.Flush();

				cs.FlushFinalBlock();

				return string.Join("", ms.ToArray().Select(x => x.ToString("x2")));
			}
		}

		/// <summary>
		/// 解密
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string Decrypt(string value)
		{
			byte[] bytes = Enumerable.Range(0, value.Length)
								   	 .Where(i => i % 2 == 0)
									 .Select(i => Convert.ToByte(value.Substring(i, 2), 16)).ToArray();

			using (MemoryStream ms = new(bytes))
			using (CryptoStream cs = new(ms, _aes.CreateDecryptor(), CryptoStreamMode.Read))
			using (StreamReader sr = new(cs))
			{
				return sr.ReadToEnd();
			}
		}
	}
}
