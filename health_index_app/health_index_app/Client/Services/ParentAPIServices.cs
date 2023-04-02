using health_index_app.Shared.DTObjects;
using health_index_app.Shared.Models;
using System.Net.Http.Json;

namespace health_index_app.Client.Services
{
    public class ParentAPIServices : IParentAPIServices
    {
        private readonly HttpClient _client;


        public ParentAPIServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<string>> GetChildUsernames()
        {
            var url = "/api/applicationuser/get-child-usernames";
            var response = await _client.GetFromJsonAsync<List<string>>(url);
            return response;
        }

        public async Task<List<ChildMealDTO>> GetChildMeals()
        {
            var url = "/api/applicationuser/get-child-meals";
            var response = await _client.GetFromJsonAsync<List<ChildMealDTO>>(url);
            return response;
        }

        public async Task<List<ChildFoodDTO>> GetChildFoods(int mealId)
        {
            var url = $"/mealfood/get-food-list?mealId={mealId}";
            var response = await _client.GetFromJsonAsync<List<ChildFoodDTO>>(url);
            return response;
        }
        public async Task<bool> DeleteChild(string username)
        {
            var url = $"/api/applicationuser/remove-child-from-user";
            var response = await _client.PostAsJsonAsync(url, username);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> AddChild(string username)
        {
            var url = $"/api/applicationuser/add-child-to-user";
            var response = await _client.PostAsJsonAsync(url, username);
            return response.IsSuccessStatusCode;
        }
    }
}
