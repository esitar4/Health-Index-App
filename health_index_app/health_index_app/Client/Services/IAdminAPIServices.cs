namespace health_index_app.Client.Services
{
    public interface IAdminAPIServices
    {
        Task<string> PostAdminUser(string userId);
        Task<string> PostUnlockAccount(string userId);
    }
}
