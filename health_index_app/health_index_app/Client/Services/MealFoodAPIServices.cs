using health_index_app.Shared.Models;
using System.Net.Http.Json;

namespace health_index_app.Client.Services
{
    public interface IMealFoodAPIServices
    {
        Task<MealFood> CreateMealFood(MealFood mealFood);
        Task<IEnumerable<MealFood>> ReadMealFood(int mealFoodId);
        Task<bool> UpdateMealFood(MealFood mealFood);
        Task<bool> DeleteMealFood(MealFood mealFood);
        Task<List<MealFood>> GetFoodList(int mealId);
    }

    public class MealFoodAPIServices : IMealFoodAPIServices
    {
        private readonly HttpClient _client;

        public MealFoodAPIServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<MealFood> CreateMealFood(MealFood mealFood)
        {
            MealFood MealFood;
            try
            {
                var response = await _client.PostAsJsonAsync("mealfood/create", mealFood);
                MealFood =  await response.Content.ReadFromJsonAsync<MealFood>();
            } 
            catch
            {
                throw new Exception("Unable to create MealFood");
            }
            return MealFood;
        }
        public async Task<IEnumerable<MealFood>> ReadMealFood(int mealId)
        {
            List<MealFood> response;
            try
            {
                var url = $"/mealfood/read?mealId={mealId}";
                response = await _client.GetFromJsonAsync<List<MealFood>>(url);
            }
            catch
            {
                throw new Exception("Unable to read MealFood, MealFood not found");
            }
            return response;
        }

        public async Task<bool> UpdateMealFood(MealFood MealFood)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("mealfood/update", MealFood);
            }
            catch
            {
                throw new Exception("Unable to update MealFood, MealFood not found");
            }
            return true;
        }

        public async Task<bool> DeleteMealFood(MealFood mealFood)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("mealfood/delete", mealFood);
            } 
            catch {
                throw new Exception("Unable to delete MealFood, MealFood not found");
            }
            return true;
        }

        public async Task<List<MealFood>> GetFoodList(int mealId)
        {
            var url = $"/mealfood/get-food-list?mealId={mealId}";
            var response = await _client.GetFromJsonAsync<List<MealFood>>(url);
            return response;
        }

    }
}
