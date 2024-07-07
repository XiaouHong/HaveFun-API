using HaveFun_API.Models.DTO;

namespace HaveFun_API.Interface.IRepositories
{
    public interface IMemberRepository
    {
        Task<MemberDTO> GetByMail(string mail);
        Task<MemberDTO> GetByToken(string token);
        Task<bool> Insert(MemberBaseDTO dto);
        Task<int> Insert(string mail);

		Task<bool> Update(MemberDTO dto);
    }
}