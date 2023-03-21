using health_index_app.Shared.FatSecret.Requests;
using health_index_app.Shared.FatSecret.ResponseObjects;
using System.Net.Http.Json;

namespace health_index_app.Client.Services
{
    public interface IFatSecretAPIServices
    {
        //Task<GetFoodResponse> FoodGetAsync(FoodGetV2Request request);
        Task<FoodsSearchResponse> FoodsSearchAsync(HttpClient client, string searchExpression);
    }

    public class FatSecretAPIServices : IFatSecretAPIServices 
    { 
        //private readonly HttpClient _client;

        //public FatSecretAPIServices(HttpClient client)
        //{
        //    _client = client;
        //}

        public async Task<FoodsSearchResponse> FoodsSearchAsync(HttpClient client, string searchExpression)
        {
            var url = $"https://localhost:7005/api/fatsecret?searchExpression={searchExpression}";
            return await client.GetFromJsonAsync<FoodsSearchResponse>(url);
        }

        //public async Task<FoodsSearchResponse> FoodsSearchAsync(FoodsSearchRequest request);
        //{
        //    var url = $"api/weatherforecast?cityId={cityId}";
        //    return await _client.GetFromJsonAsync<Forecast>(url);
        //}
        }
}
