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
            FoodsSearchResponse response;
            try
            {
                var url = $"/api/fatsecret/foodsearch?searchExpression={searchExpression}";
                response = await _client.GetFromJsonAsync<FoodsSearchResponse>(url);
            } catch
            {
                response = new FoodsSearchResponse
                {
                    Error = new FatSecretError { Message = "Unable to get a response!"}
                };
            }
            return response;
        }

        public async Task<GetFoodResponse> FoodGetAsync(int foodId)
        {
            GetFoodResponse response;
            try
            {
                var url = $"/api/fatsecret/foodget?foodId={foodId}";
                response = await _client.GetFromJsonAsync<GetFoodResponse>(url);
            } catch
            {
                response = new GetFoodResponse
                {
                    Error = new FatSecretError { Message = "Unable to get a response!" }
                };
            }
            return response;
        }
    }
}
