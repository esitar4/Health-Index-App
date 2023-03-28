using health_index_app.Shared.FatSecret.Requests;
using health_index_app.Shared.Models;
using System.Net;
using System.Net.Http.Json;

namespace health_index_app.Client.Services
{
    public interface IFoodAPIServices
    {
        Task<Food> createFood(int foodId);
        Task<bool> deleteFood(int FoodId);
        Task<bool> updateFood(Food Food);
        Task<Food> readFood(int FoodId);
    }

    public class FoodAPIServices : IFoodAPIServices
    {
        private readonly HttpClient _client;


        public FoodAPIServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<Food> createFood(int foodId)
        {
            Food food;
            try
            {
                var response = await _client.PostAsJsonAsync("Food/create", foodId);

                food = response.Content.ReadFromJsonAsync<Food>().Result;
            }
            catch
            {
                throw;
                throw new Exception("Unable to create Food");
            }
            return food;
        }

        public async Task<bool> deleteFood(int FoodId)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("Food/delete", FoodId);
            }
            catch
            {
                throw;
                throw new Exception("Food not found");
            }
            return true;
        }

        public async Task<Food> readFood(int FoodId)
        {
            Food response;
            try
            {
                var url = $"/Food/read?FoodId={FoodId}";
                response = await _client.GetFromJsonAsync<Food>(url);
            }
            catch
            {
                throw;
                throw new Exception("Food not found");
            }
            return response;
        }

        public async Task<bool> updateFood(Food Food)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("Food/update", Food);
            }
            catch
            {
                throw;
                throw new Exception("Food not found");
            }
            return true;
        }
    }
}
