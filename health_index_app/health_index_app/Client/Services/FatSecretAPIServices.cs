﻿using health_index_app.Shared.FatSecret.Requests;
using health_index_app.Shared.FatSecret.ResponseObjects;
using System.Net.Http.Json;

namespace health_index_app.Client.Services
{
    public interface IFatSecretAPIServices
    {
        Task<GetFoodResponse> FoodGetAsync(int foodId);
        Task<FoodsSearchResponse> FoodsSearchAsync(string searchExpression);
    }

    public class FatSecretAPIServices : IFatSecretAPIServices 
    {
        private readonly HttpClient _client;

        public FatSecretAPIServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<FoodsSearchResponse> FoodsSearchAsync(string searchExpression)
        {
            var url = $"https://localhost:7005/api/fatsecret/foodsearch?searchExpression={searchExpression}";
            return await _client.GetFromJsonAsync<FoodsSearchResponse>(url);
        }

        public async Task<GetFoodResponse> FoodGetAsync(int foodId)
        {
            var url = $"https://localhost:7005/api/fatsecret/foodget?foodId={foodId}";
            return await _client.GetFromJsonAsync<GetFoodResponse>(url);
        }
    }
}