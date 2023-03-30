using health_index_app.Client.Pages;
using health_index_app.Shared.Models;
using Newtonsoft.Json;
using System.Net;
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
                var response = await _client.PostAsJsonAsync("usermeals/create", userMealDTO);
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
                var url = $"/usermeals/read?mealId={mealId}";
                userMealDTO = await _client.GetFromJsonAsync<UserMealDTO>(url);
            }
            catch
            {
                throw new Exception("UserMeal not found");
            }
            return userMealDTO;
        }

        public async Task<bool> UpdateUserMeal(UserMealDTO userMealDTO)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("usermeals/update", userMealDTO);
            }
            catch
            {
                throw new Exception("UserMeal not found");
            }
            return true;
        }


        public async Task<bool> DeleteUserMeal(int mealId)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("usermeals/delete", mealId);
            }
            catch
            {
                throw new Exception("UserMeal not found");
            }
            return true;
        }

        public async Task<List<int>> GetAllUserMealId()
        {
            List<int> mealIds;
            try
            {
                var url = $"/usermeals/get-all-meal-ids";
                mealIds = await _client.GetFromJsonAsync<List<int>>(url);
            }
            catch
            {
                throw;
                throw new Exception("No meals found for user");
            }
            return mealIds;
        }
    }
}
