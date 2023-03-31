namespace health_index_app.Client.Services
{
    public interface IAdminAPIServices
    {
        Task<string> Post(string userId);
    }
}
