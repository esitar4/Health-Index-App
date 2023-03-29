using health_index_app.Shared.Models;
using System.Net;
using System.Net.Http.Json;

namespace health_index_app.Client.Services
{
    public interface IUserMealsAPIServices
    {
        Task<int> createUserMeal(UserMeal UserMeal);
        Task<bool> deleteUserMeal(int UserMealId);
        Task<bool> updateUserMeal(UserMeal UserMeal);
        Task<UserMeal> readUserMeal(int UserMealId);
    }

    public class UserMealsAPIServices : IUserMealsAPIServices
    {
        private readonly HttpClient _client;

        public UserMealsAPIServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<int> createUserMeal(UserMeal UserMeal)
        {
            int userMealId;
            try
            {
                //var PostBody = new { MealName, MealId };
                var response = await _client.PostAsJsonAsync("UserMeals/create", UserMeal);
                userMealId = response.Content.ReadFromJsonAsync<UserMeal>().Result.MealId;
            }
            catch
            {
                throw new Exception("Unable to create UserMeal");
            }
            return userMealId;
        }

        public async Task<bool> deleteUserMeal(int UserMealId)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("UserMeals/delete", UserMealId);
            }
            catch
            {
                throw new Exception("UserMeal not found");
            }
            return true;
        }

        public async Task<UserMeal> readUserMeal(int UserMealId)
        {
            UserMeal response;
            try
            {
                var url = $"/UserMeals/read?UserMealId={UserMealId}";
                response = await _client.GetFromJsonAsync<UserMeal>(url);
            }
            catch
            {
                throw new Exception("UserMeal not found");
            }
            return response;
        }

        public async Task<bool> updateUserMeal(UserMeal UserMeal)
        {
            try
            {
                //var PostBody = new { UserMealToUpdate, UserMeal };
                var response = await _client.PostAsJsonAsync("UserMeals/update", UserMeal);
            }
            catch
            {
                throw new Exception("UserMeal not found");
            }
            return true;
        }
    }
}
