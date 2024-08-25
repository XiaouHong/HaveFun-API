using HaveFun_API.Interface.IRepositories;
using HaveFun_API.Interface.IServices;
using HaveFun_API.Models.DTO;
using HaveFun_API.Utility;
using System.Transactions;

namespace HaveFun_API.Services
{
    /// <summary>
    /// 成員
    /// </summary>
    public class MemberService : IMemberService
	{
		private readonly IMemberRepository _memberRepository;
		private readonly IAuthorityRepository _authorityRepository;

		/// <summary>
		/// 建構子
		/// </summary>
		public MemberService(IMemberRepository memberRepository,
							 IAuthorityRepository authorityRepository)
		{
			_memberRepository = memberRepository;
			_authorityRepository = authorityRepository;
		}

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		public async Task<(bool Result, string Msg)> Insert(MemberBaseDTO dto)
		{
			var isMath = false;
			isMath = Tool.IsValidEmail(dto.Mail);
			if (!isMath)
			{
				return (false, "郵件非正確格式");
			}
			isMath = Tool.IsValidPassword(dto.Password);
			if (!isMath)
			{
				return (false, "密碼非正確格式");
			}

			dto.Password = Tool.MD5(dto.Password);
			dto.Name = dto.Name.Trim();
			dto.NickName = dto.NickName.Trim();

			using (var transation = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
			{
				var MemberID = await _memberRepository.Insert(dto);
				if (MemberID <= 0)
				{
					return (false, "會員新增失敗");
				}
				var Result = await _authorityRepository.InsertNormalAuthority(MemberID);
				if (!Result)
				{
					return (false, "權限新增失敗");
				}
				transation.Complete();
			}
			return (true, "成功");
		}
	}
}
