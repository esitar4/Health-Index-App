using System.Net.Http.Json;

namespace health_index_app.Client.Services
{
    public class AdminAPIServices : IAdminAPIServices
    {
        private readonly HttpClient _client;
        

        public AdminAPIServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> Post(string userId)
        {
            var response = await _client.PostAsJsonAsync("https://localhost:7005/api/admin/adduser", userId);
            return response.ToString();
        }
    }
}
