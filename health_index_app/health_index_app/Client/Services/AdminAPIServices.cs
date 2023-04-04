using System.Net.Http.Json;
using health_index_app.Shared.DTObjects;
using health_index_app.Client.Components;
using Microsoft.AspNetCore.Components;
using System.Net;

namespace health_index_app.Client.Services
{
    public class AdminAPIServices : IAdminAPIServices
    {
        private readonly HttpClient _client;

        public AdminAPIServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> PostAdminUser(string userId)
        {
            var response = await _client.PostAsJsonAsync("https://localhost:7005/api/admin/adduser", userId);
            return response.ToString();
        }

        public async Task<string> RemoveAdminUser(string userId)
        {
            var response = await _client.PostAsJsonAsync("https://localhost:7005/api/admin/removeuser", userId);
            return response.ToString();
        }

        public async Task<string> PostUnlockAccount(string userId)
        {
            var response = await _client.PostAsJsonAsync("https://localhost:7005/api/admin/unlockAccount", userId);
            return response.ToString();
        }

        public async Task<string> PostLockAccount(string userId)
        {
            var response = await _client.PostAsJsonAsync("https://localhost:7005/api/admin/lockAccount", userId);
            return response.ToString();
        }

        public async Task<string> PostDeleteAccount(string userId)
        {
            var response = await _client.PostAsJsonAsync("https://localhost:7005/api/admin/deleteAccount", userId);
            return response.ToString();
        }

        public async Task<string> PostAddParentChildRelationship(string combinedId)
        {
            var response = await _client.PostAsJsonAsync("https://localhost:7005/api/admin/addParentChildRelationship", combinedId);
            return response.ToString();
        }

        public async Task<string> PostRemoveParentChildRelationship(string userId)
        {
            var response = await _client.PostAsJsonAsync("https://localhost:7005/api/admin/removeParentChildRelationship", userId);
            return response.ToString();
        }

        public async Task<List<ApplicationUserDTO>> GetUsers()
        {
            var response = await _client.GetFromJsonAsync<List<ApplicationUserDTO>>("https://localhost:7005/api/admin/getUsers");
            return response;
        }
    }
}
