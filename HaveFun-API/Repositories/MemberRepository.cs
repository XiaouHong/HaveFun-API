using HaveFun_API.Enum;
using HaveFun_API.Interface.IRepositories;
using HaveFun_API.Models.DTO;
using HaveFun_API.Models.PO;
using HaveFun_API.Schafold;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;

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
		public async Task<MemberDTO> GetByMail(string mail)
		{
			var Result = new MemberDTO();
			var Query = await _haveFun.Member.AsQueryable()
											 .Where(x => x.Mail == mail)
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
		public async Task<bool> Insert(MemberBaseDTO dto)
		{
			await _haveFun.Member.AddAsync(new MemberPO
			{
				Mail = dto.Mail,
				Name = dto.Name,
				NickName = dto.NickName,
				Note = dto.Note,
				AuthorityType = AuthorityType.Normal
			});
			return await _haveFun.SaveChangesAsync() > 0;
		}

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="mail"></param>
		/// <returns></returns>
		public async Task<int> Insert(string mail)
		{
			var New = new MemberPO
			{
				Mail = mail,
				AuthorityType = AuthorityType.Normal
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
			var Origin = _haveFun.Member.AsQueryable()
										.Where(x => x.ID == dto.ID)
										.FirstOrDefault();
			if (Origin == null)
			{
				return false;
			}

			if (!string.IsNullOrEmpty(dto.Name))
			{
				Origin.Name = dto.Name;
			}

			if (!string.IsNullOrEmpty(dto.NickName))
			{
				Origin.NickName = dto.NickName;
			}

			if (!string.IsNullOrEmpty(dto.Note))
			{
				Origin.Note = dto.Note;
			}

			if (!string.IsNullOrEmpty(dto.Token))
			{
				Origin.Token = dto.Token;
			}

			if (!string.IsNullOrEmpty(dto.RefreshToken))
			{
				Origin.RefreshToken = dto.RefreshToken;
			}

			if (dto.AuthorityType != AuthorityType.Unknow)
			{
				Origin.AuthorityType = dto.AuthorityType;
			}

			return await _haveFun.SaveChangesAsync() > 0;
		}
	}
}
