﻿using health_index_app.Shared.Models;
using System.Net;
using System.Net.Http.Json;

namespace health_index_app.Client.Services
{
    public interface IMealFoodAPIServices
    {
        Task<MealFood> CreateMealFood(MealFood mealFood);
        Task<bool> DeleteMealFood(int mealFoodId);
        Task<bool> UpdateMealFood(MealFood mealFood);
        Task<MealFood> ReadMealFood(int mealFoodId);
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
                var response = await _client.PostAsJsonAsync("mealfoods/create", mealFood);
                MealFood =  await response.Content.ReadFromJsonAsync<MealFood>();
            } catch
            {
                throw new Exception("Unable to create MealFood");
            }
            return MealFood;
        }

        public async Task<bool> DeleteMealFood(int MealFoodId)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("MealFoods/delete", MealFoodId);
            } catch {
                throw new Exception("MealFood not found");
            }
            return true;
        }

        public async Task<MealFood> ReadMealFood(int MealFoodId)
        {
            MealFood response;
            try
            {
                var url = $"/MealFoods/read?MealFoodId={MealFoodId}";
                response = await _client.GetFromJsonAsync<MealFood>(url);
            }
            catch
            {
                throw new Exception("MealFood not found");
            }
            return response;
        }

        public async Task<bool> UpdateMealFood(MealFood MealFood)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("MealFoods/update", MealFood);
            }
            catch
            {
                throw new Exception("MealFood not found");
            }
            return true;
        }
    }
}
