using HaveFun_API.Enum;

namespace HaveFun_API.Interface.IRepositories
{
    public interface IAuthorityRepository
    {
        Task<bool> CheckAction(int targetID, string functionEngName, ActionType actionType);
        Task<string> GetAcess(int ID);
        Task<List<string>> GetFunctionEngName(List<int> functionIDList);
        Task<bool> InsertNormalAuthority(int targetID);
    }
}