using HaveFun_API.Models.DTO;

namespace HaveFun_API.Interface.IServices
{
    public interface IMemberService
    {
        Task<(bool Result, string Msg)> Insert(MemberBaseDTO dto);
    }
}