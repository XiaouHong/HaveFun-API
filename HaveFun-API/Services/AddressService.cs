using HaveFun_API.Interface.IRepositories;
using HaveFun_API.Models.DTO;
using HaveFun_API.Models.VO;

namespace HaveFun_API.Services
{
	/// <summary>
	/// 地址
	/// </summary>
	public class AddressService
	{
		private readonly IAddressRepository _addressRepository;

		/// <summary>
		/// 建構子
		/// </summary>
		public AddressService(IAddressRepository addressRepository)
		{
			_addressRepository = addressRepository;
		}

		/// <summary>
		/// 取得
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		public async Task<(bool Result, AddressVO VO)> Get(RequestDTO dto)
		{
			var VO = new AddressVO();
			var Result = await _addressRepository.Get(dto.ID);
			Result.ID = VO.ID;
			Result.Country = VO.Country;
			Result.City = VO.City;
			Result.Town = VO.Town;
			Result.Code = VO.Code;
			return (Result.ID > 0, VO);
		}
	}
}
