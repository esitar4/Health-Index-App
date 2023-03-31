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

        public async Task<List<ChildMealDTO>> GetChildMeals()
        {
            var url = "https://localhost:7005/api/applicationuser/get-child-meals";
            var response = await _client.GetFromJsonAsync<List<ChildMealDTO>>(url);
            return response;
        }

        public async Task<List<ChildMealFoodDTO>> GetChildFoods(int mealId)
        {
            var url = $"https://localhost:7005/mealfood/get-food-list?mealId={mealId}";
            var response = await _client.GetFromJsonAsync<List<ChildMealFoodDTO>>(url);
            return response;
        }
    }
}
