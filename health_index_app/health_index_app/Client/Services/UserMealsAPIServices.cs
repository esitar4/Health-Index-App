using health_index_app.Shared.Models;
using System.Net;
using System.Net.Http.Json;

namespace health_index_app.Client.Services
{
    public interface IUserMealsAPIServices
    {
        Task<int> CreateUserMeal(Meal meal, string mealName);
        Task<bool> DeleteUserMeal(int mealId);
        Task<bool> UpdateUserMeal(int userMealId, int mealId);
        Task<List<int>> ReadUserMeal();
    }

    public class UserMealsAPIServices : IUserMealsAPIServices
    {
        private readonly HttpClient _client;

        public UserMealsAPIServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<int> CreateUserMeal(Meal meal, string mealName)
        {
            int userMealId;
            try
            {
                var PostBody = new { mealName, meal };
                var response = await _client.PostAsJsonAsync("UserMeals/create", PostBody);
                userMealId = await response.Content.ReadFromJsonAsync<int>();
            }
            catch
            {
                throw new Exception("Unable to create UserMeal");
            }
            return userMealId;
        }

        public async Task<bool> DeleteUserMeal(int mealId)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("UserMeals/delete", mealId);
            }
            catch
            {
                throw new Exception("UserMeal not found");
            }
            return true;
        }

        public async Task<List<int>> ReadUserMeal()
        {
            List<int> mealIds;
            try
            {
                var url = $"/UserMeals/read";
                mealIds = await _client.GetFromJsonAsync<List<int>>(url);
            }
            catch
            {
                throw new Exception("UserMeal not found");
            }
            return mealIds;
        }

        public async Task<bool> UpdateUserMeal(int userMealId, int mealId)
        {
            try
            {
                List<int> Postbody = new List<int> { userMealId, mealId };
                var response = await _client.PostAsJsonAsync("UserMeals/update", Postbody);
            }
            catch
            {
                throw new Exception("UserMeal not found");
            }
            return true;
        }
    }
}
