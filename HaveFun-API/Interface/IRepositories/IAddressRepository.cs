using HaveFun_API.Models.DTO;
using HaveFun_API.Models.PO;

namespace HaveFun_API.Interface.IRepositories
{
    public interface IAddressRepository
    {
        Task<bool> Delete(int ID);
        Task<AddressPO> Get(int ID);
        Task<(int Count, List<AddressPO> List)> GetList(SearchAddressDTO dto);
        Task<bool> Insert(AddressBaseDTO dto);
        Task<bool> Update(AddressDTO dto);
    }
}