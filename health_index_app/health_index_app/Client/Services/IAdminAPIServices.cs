using health_index_app.Shared.DTObjects;

namespace health_index_app.Client.Services
{
    public interface IAdminAPIServices
    {
        Task<string> PostAdminUser(string userId);
        Task<string> RemoveAdminUser(string userId);
        Task<string> PostUnlockAccount(string userId);
        Task<string> PostLockAccount(string userId);
        Task<string> PostDeleteAccount(string userId);
        Task<string> PostAddParentChildRelationship(string combinedId);
        Task<string> PostRemoveParentChildRelationship(string userId);
        Task<List<ApplicationUserDTO>> GetUsers();
    }
}
