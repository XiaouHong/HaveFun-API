namespace HaveFun_API.Interface.IServices
{
    public interface ILoginService
    {
        string Authorize();
        Task<bool> GooleLogin(string code, string state);
    }
}