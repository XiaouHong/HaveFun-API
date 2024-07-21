using HaveFun_API.Models.DTO;

namespace HaveFun_API.Interface.IRepositories
{
    public interface IMemberRepository
    {
        Task<MemberDTO> GetByMail(string mail);
        Task<MemberDTO> GetByToken(string token);
        Task<int> Insert(MemberBaseDTO dto);
		Task<bool> Update(MemberDTO dto);
    }
}