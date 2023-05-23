using health_index_app.Shared.Models;
using System.Net.Http.Json;

namespace health_index_app.Client.Services
{
    public interface IMealAPIServices
    {
        Task<Meal> CreateMeal(Meal meal);
        Task<Meal> ReadMeal(int mealId);
        Task<bool> UpdateMeal(Meal meal);
        Task<bool> DeleteMeal(Meal meal);
        
    }

    public class MealAPIServices : IMealAPIServices
    {
        private readonly HttpClient _client;

        public MealAPIServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<Meal> CreateMeal(Meal meal)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("meal/create", meal);
                meal = (await response.Content.ReadFromJsonAsync<Meal>());
            } 
            catch
            {
                throw new Exception("Unable to create Meal");
            }
            return meal;
        }

        public async Task<Meal> ReadMeal(int mealId)
        {
            Meal response;
            try
            {
                var url = $"/meal/read?mealId={mealId}";
                response = await _client.GetFromJsonAsync<Meal>(url);
            }
            catch
            {
                throw new Exception("Unable to read Meal, Meal not found");
            }
            return response;
        }

        public async Task<bool> UpdateMeal(Meal meal)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("meal/update", meal);
            }
            catch
            {
                throw new Exception("Unable to update Meal, Meal not found");
            }
            return true;
        }

        public async Task<bool> DeleteMeal(Meal meal)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("meal/delete", meal);
            } 
            catch {
                throw new Exception("Unable to delete Meal, Meal not found");
            }
            return true;
        }


    }
}
