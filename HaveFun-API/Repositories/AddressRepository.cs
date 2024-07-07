using HaveFun_API.Interface.IRepositories;
using HaveFun_API.Models.DTO;
using HaveFun_API.Models.PO;
using HaveFun_API.Schafold;
using Microsoft.EntityFrameworkCore;

namespace HaveFun_API.Repositories
{
    /// <summary>
    /// 地址
    /// </summary>
    public class AddressRepository : IAddressRepository
	{
		private readonly HaveFunContext _haveFun;

		/// <summary>
		/// 建構子
		/// </summary>
		public AddressRepository(HaveFunContext HaveFun)
		{
			_haveFun = HaveFun;
		}

		/// <summary>
		/// 取得
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public async Task<AddressPO> Get(int ID)
		{
			return await _haveFun.Address.AsQueryable()
										 .Where(x => x.ID == ID)
										 .FirstOrDefaultAsync() ?? new AddressPO();
		}

		/// <summary>
		/// 取得清單
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		public async Task<(int Count, List<AddressPO> List)> GetList(SearchAddressDTO dto)
		{
			var Query = _haveFun.Address.AsQueryable();

			if (!string.IsNullOrEmpty(dto.Country))
			{
				Query = Query.Where(x => x.Country.Contains(dto.Country));
			}

			if (!string.IsNullOrEmpty(dto.City))
			{
				Query = Query.Where(x => x.Country.Contains(dto.City));
			}

			if (!string.IsNullOrEmpty(dto.Town))
			{
				Query = Query.Where(x => x.Country.Contains(dto.Town));
			}

			var Count = await Query.CountAsync();
			var List = await Query.Skip((dto.PageNow - 1) * dto.PageShow)
								  .Take(dto.PageShow)
								  .ToListAsync();
			return (Count, List);
		}

		/// <summary>
		/// 新增
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		public async Task<bool> Insert(AddressBaseDTO dto)
		{
			await _haveFun.Address.AddAsync(new AddressPO
			{
				Country = dto.Country,
				City = dto.City,
				Town = dto.Town,
				Code = dto.Code
			});
			return await _haveFun.SaveChangesAsync() > 0;
		}

		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		public async Task<bool> Update(AddressDTO dto)
		{
			var Origin = await _haveFun.Address.AsQueryable()
											   .Where(x => x.ID == dto.ID)
											   .FirstOrDefaultAsync();
			if (Origin == null)
			{
				return false;
			}

			if (!string.IsNullOrEmpty(dto.Country))
			{
				Origin.Country = dto.Country;
			}
			if (!string.IsNullOrEmpty(dto.City))
			{
				Origin.City = dto.City;
			}
			if (!string.IsNullOrEmpty(dto.Town))
			{
				Origin.Town = dto.Town;
			}
			if (!string.IsNullOrEmpty(dto.Code))
			{
				Origin.Code = dto.Code;
			}

			return await _haveFun.SaveChangesAsync() > 0;
		}

		/// <summary>
		/// 刪除
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public async Task<bool> Delete(int ID)
		{
			var Data = await _haveFun.Address.AsQueryable()
											 .Where(x => x.ID == ID)
											 .FirstOrDefaultAsync();
			if (Data == null) { return true; }
			_haveFun.Address.Remove(Data);
			return await _haveFun.SaveChangesAsync() > 0;
		}
	}
}
