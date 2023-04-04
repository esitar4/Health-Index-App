using health_index_app.Shared.Models;
using System.Net.Http.Json;

namespace health_index_app.Client.Services
{
    public interface IUserMealsAPIServices
    {
        Task<UserMealDTO> CreateUserMeal(UserMealDTO userMealDTO);
        Task<UserMealDTO> ReadUserMeal(int mealId);
        Task<bool> UpdateUserMeal(UserMealDTO userMealDTO);
        Task<bool> DeleteUserMeal(int mealId);
        Task<List<int>> GetAllUserMealId();
    }

    public class UserMealsAPIServices : IUserMealsAPIServices
    {
        private readonly HttpClient _client;

        public UserMealsAPIServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserMealDTO> CreateUserMeal(UserMealDTO userMealDTO)
        {
            UserMealDTO result;
            try
            {
                var response = await _client.PostAsJsonAsync("usermeal/create", userMealDTO);
                result  = await response.Content.ReadFromJsonAsync<UserMealDTO>();
            }
            catch
            {
                throw new Exception("Unable to create UserMeal");
            }
            return result;
        }

        public async Task<UserMealDTO> ReadUserMeal(int mealId)
        {
            UserMealDTO userMealDTO;
            try
            {
                var url = $"/usermeal/read?mealId={mealId}";
                userMealDTO = await _client.GetFromJsonAsync<UserMealDTO>(url);
            }
            catch
            {
                throw new Exception("Unable to read UserMeal, UserMeal not found");
            }
            return userMealDTO;
        }

        public async Task<bool> UpdateUserMeal(UserMealDTO userMealDTO)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("usermeal/update", userMealDTO);
            }
            catch
            {
                throw new Exception("Unable to update UserMeal, UserMeal not found");
            }
            return true;
        }


        public async Task<bool> DeleteUserMeal(int mealId)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("usermeal/delete", mealId);
            }
            catch
            {
                throw new Exception("Unable to delete UserMeal, UserMeal not found");
            }
            return true;
        }

        public async Task<List<int>> GetAllUserMealId()
        {
            List<int> mealIds;
            try
            {
                var url = $"/usermeal/get-all-meal-ids";
                mealIds = await _client.GetFromJsonAsync<List<int>>(url);
            }
            catch
            {
                throw new Exception("Something went very wrong");
            }
            return mealIds;
        }
    }
}
