using HaveFun_API.Enum;
using HaveFun_API.Interface.IRepositories;
using HaveFun_API.Models.PO;
using HaveFun_API.Schafold;
using Microsoft.EntityFrameworkCore;

namespace HaveFun_API.Repositories
{
    /// <summary>
    /// 權限
    /// </summary>
    public class AuthorityRepository : IAuthorityRepository
	{
		private readonly HaveFunContext _haveFun;

		/// <summary>
		/// 建構子
		/// </summary>
		public AuthorityRepository(HaveFunContext haveFun)
		{
			_haveFun = haveFun;
		}

		/// <summary>
		/// 取得訪問權
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public async Task<string> GetAcess(int ID)
		{
			var Query = await _haveFun.Authority.AsQueryable()
												.Where(x => x.TargetID == ID)
												.Where(x => x.IsRead)
												.ToListAsync();
			var functionEngNameList = GetFunctionEngName(Query.Select(x => x.FunctionID).ToList());
			return string.Join(",", functionEngNameList);
		}

		/// <summary>
		/// 取得Function Eng Name
		/// </summary>
		/// <param name="functionIDList"></param>
		/// <returns></returns>
		public async Task<List<string>> GetFunctionEngName(List<int> functionIDList)
		{
			var Query = await _haveFun.AuthorityFunction.AsQueryable()
														.Where(x => functionIDList.Contains(x.ID))
														.ToListAsync();
			return Query.Select(x => x.EnglishName).ToList();
		}

		/// <summary>
		/// 確認是否有權限
		/// </summary>
		/// <param name="targetID"></param>
		/// <param name="functionEngName"></param>
		/// <param name="actionType"></param>
		/// <returns></returns>
		public async Task<bool> CheckAction(int targetID, string functionEngName, ActionType actionType)
		{
			var functionID = await _haveFun.AuthorityFunction.AsQueryable()
															 .Where(x => x.EnglishName == functionEngName)
															 .FirstOrDefaultAsync();
			if (functionID == null) return false;
			var Query = _haveFun.Authority.AsQueryable()
										  .Where(x => x.TargetID == targetID);
			switch (actionType)
			{
				case ActionType.IsRead:
					Query = Query.Where(x => x.IsRead);
					break;
				case ActionType.IsCreate:
					Query = Query.Where(x => x.IsCreate);
					break;
				case ActionType.IsUpdate:
					Query = Query.Where(x => x.IsUpdate);
					break;
				case ActionType.IsDelete:
					Query = Query.Where(x => x.IsDelete);
					break;
			}
			return await Query.FirstOrDefaultAsync() != null;
		}

		/// <summary>
		/// 新增普通權限
		/// </summary>
		/// <param name="targetID"></param>
		/// <returns></returns>
		public async Task<bool> InsertNormalAuthority(int targetID)
		{
			var functionList = await _haveFun.AuthorityFunction.AsQueryable()
															   .Where(x => x.AuthorityType <= AuthorityType.Normal)
															   .ToListAsync();
			var authorityList = new List<AuthorityPO>();
			functionList.ForEach(function =>
			{
				authorityList.Add(new AuthorityPO
				{
					Type = TargetType.Member,
					TargetID = targetID,
					FunctionID = function.ID,
					IsRead = true,
					IsCreate = true,
					IsUpdate = true,
					IsDelete = true
				});
			});
			await _haveFun.Authority.AddRangeAsync(authorityList);
			return await _haveFun.SaveChangesAsync() > 0;
		}
	}
}
