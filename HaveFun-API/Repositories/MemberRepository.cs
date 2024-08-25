using HaveFun_API.Enum;
using HaveFun_API.Interface.IRepositories;
using HaveFun_API.Models.DTO;
using HaveFun_API.Models.PO;
using HaveFun_API.Schafold;
using Microsoft.EntityFrameworkCore;

namespace HaveFun_API.Repositories
{
    /// <summary>
    /// 會員
    /// </summary>
    public class MemberRepository : IMemberRepository
	{
		private readonly HaveFunContext _haveFun;

		/// <summary>
		/// 建構子
		/// </summary>
		public MemberRepository(HaveFunContext haveFun)
		{
			_haveFun = haveFun;
		}

		/// <summary>
		/// 取得
		/// </summary>
		/// <param name="mail"></param>
		/// <returns></returns>
		public async Task<MemberPO> GetByMail(string mail)
		{
			return await _haveFun.Member.AsQueryable()
										.Where(x => x.Mail == mail)
										.FirstOrDefaultAsync() ?? new MemberPO();
		}

		/// <summary>
		/// 取得
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public async Task<MemberDTO> GetByToken(string token)
		{
			var Result = new MemberDTO();
			var Query = await _haveFun.Member.AsQueryable()
											 .Where(x => x.RefreshToken == token)
											 .FirstOrDefaultAsync();
			if (Query == null)
			{
				return Result;
			}
			Result.ID = Query.ID;
			Result.Mail = Query.Mail;
			Result.Name = Query.Name;
			Result.NickName = Query.NickName;
			Result.Note = Query.Note;
			Result.AuthorityType = Query.AuthorityType;
			return Result;
		}

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		public async Task<int> Insert(MemberBaseDTO dto)
		{
			var New = new MemberPO
			{
				Mail = dto.Mail,
				Password = dto.Password,
				Name = dto.Name,
				NickName = dto.NickName,
				Note = dto.Note,
				AuthorityType = AuthorityType.Normal,
				CreateTime = DateTime.Now
			};
			await _haveFun.Member.AddAsync(New);
			await _haveFun.SaveChangesAsync();
			return New.ID;
		}

		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		public async Task<bool> Update(MemberDTO dto)
		{
			var origin = _haveFun.Member.AsQueryable()
										.Where(x => x.ID == dto.ID)
										.FirstOrDefault();
			if (origin == null)
			{
				return false;
			}

			if (!string.IsNullOrEmpty(dto.Name))
			{
				origin.Name = dto.Name;
			}

			if (!string.IsNullOrEmpty(dto.NickName))
			{
				origin.NickName = dto.NickName;
			}

			if (!string.IsNullOrEmpty(dto.Note))
			{
				origin.Note = dto.Note;
			}

			if (!string.IsNullOrEmpty(dto.AccessToken))
			{
				origin.AccessToken = dto.AccessToken;
			}

			if (!string.IsNullOrEmpty(dto.RefreshToken))
			{
				origin.RefreshToken = dto.RefreshToken;
			}

			if (dto.AuthorityType != AuthorityType.Unknow)
			{
				origin.AuthorityType = dto.AuthorityType;
			}

			return await _haveFun.SaveChangesAsync() > 0;
		}
	}
}
