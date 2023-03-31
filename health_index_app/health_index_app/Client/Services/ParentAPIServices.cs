using health_index_app.Shared.DTObjects;
using health_index_app.Shared.Models;
using System.Net.Http.Json;

namespace health_index_app.Client.Services
{
    public class ParentAPIServices
    {
        private readonly HttpClient _client;


        public ParentAPIServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<string>> GetChildUsernames()
        {
            var url = "https://localhost:7005/api/applicationuser/get-child-usernames";
            var response = await _client.GetFromJsonAsync<List<string>>(url);
            return response;
        }

        public async Task<List<MealDTO>> GetChildMeals()
        {
            var url = "https://localhost:7005/api/applicationuser/get-child-meals";
            var response = await _client.GetFromJsonAsync<List<MealDTO>>(url);
            return response;
        }

        public async Task<List<Food>> GetChildFoods(int mealId)
        {
            var url = $"https://localhost:7005/api/applicationuser/get-food-list?mealId={mealId}";
            var response = await _client.GetFromJsonAsync<List<Food>>(url);
            return response;
        }
    }
}
