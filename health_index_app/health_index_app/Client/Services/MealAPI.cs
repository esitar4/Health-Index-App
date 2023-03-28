using health_index_app.Shared.Models;
using System.Net;
using System.Net.Http.Json;

namespace health_index_app.Client.Services
{
    public interface IMealAPI
    {
        Task<int> createMeal();
        Task<bool> deleteMeal(int mealId);
        Task<bool> updateMeal(Meal meal);
        Task<Meal> readMeal(int mealId);
    }

    public class MealAPI : IMealAPI
    {
        private readonly HttpClient _client;

        public MealAPI(HttpClient client)
        {
            _client = client;
        }

        public async Task<int> createMeal()
        {
            Meal meal;

            meal = new Meal();

            var response = await _client.PostAsJsonAsync("https://localhost:7005/meals/create", meal);

            try
            {
                /*meal = new Meal();

                var response = await _client.PostAsJsonAsync("meals/create", meal);*/
            } catch
            {
                throw new Exception("Unable to create meal");
            }
            return meal.Id;
        }

        public async Task<bool> deleteMeal(int mealId)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("meals/delete", mealId);
            } catch {
                throw new Exception("Meal not found");
            }
            return true;
        }

        public async Task<Meal> readMeal(int mealId)
        {
            Meal response;
            try
            {
                var url = $"/meals/read?mealId={mealId}";
                response = await _client.GetFromJsonAsync<Meal>(url);
            }
            catch
            {
                throw new Exception("Meal not found");
            }
            return response;
        }

        public async Task<bool> updateMeal(Meal meal)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("meals/update", meal);
            }
            catch
            {
                throw new Exception("Meal not found");
            }
            return true;
        }
    }
}
