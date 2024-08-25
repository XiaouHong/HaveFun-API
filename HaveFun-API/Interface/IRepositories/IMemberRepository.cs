using HaveFun_API.Models.DTO;
using HaveFun_API.Models.PO;

namespace HaveFun_API.Interface.IRepositories
{
    public interface IMemberRepository
    {
        Task<MemberPO> GetByMail(string mail);
        Task<MemberDTO> GetByToken(string token);
        Task<int> Insert(MemberBaseDTO dto);
		Task<bool> Update(MemberDTO dto);
    }
}