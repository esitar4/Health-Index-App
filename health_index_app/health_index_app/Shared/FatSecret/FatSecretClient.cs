using FatSecretAPICall.Authentication;
using FatSecretAPICall.Requests;
using FatSecretAPICall.ResponseObjects;
using Newtonsoft.Json;
using RestSharp;

namespace FatSecretAPICall
{
    public class FatSecretClient : IFatSecretClient
    {
        private readonly FatSecretAuthenticationManager _authManager;
        private readonly RestClientOptions _options;
        private readonly IRestClient _client;
        private readonly string _url = "https://platform.fatsecret.com/rest/server.api";

        public FatSecretClient(FatSecretCredentials credentials)
        {
            _authManager = new FatSecretAuthenticationManager(credentials);
            _options = new RestClientOptions(_url);
            _client = new RestClient(_options);
        }

        public async Task<GetFoodResponse> FoodGetAsync(FoodGetV2Request request)
        {
            return await FatSecretRequest<GetFoodResponse>(request);
        }

        public async Task<FoodsSearchResponse> FoodsSearchAsync(FoodsSearchRequest request)
        {
            return await FatSecretRequest<FoodsSearchResponse>(request);
        }

        private async Task<T> FatSecretRequest<T>(IFatSecretRequest fatSecretRequest) where T : FatSecretResponse
        {
            var request = new RestRequest(_url, Method.Get);
            var authToken = await _authManager.GetAuthHeaderAsync();
            request.AddHeader("Authorization", authToken);

            foreach (var parameter in fatSecretRequest.GetParameters())
            {
                request.AddParameter(parameter.Item1, parameter.Item2);
            }

            request.AddParameter("format", "json");

            var response = await _client.ExecuteAsync<T>(request);
            var fatSecretResponse = response.Data;

            var fatSecretErrorResponse = JsonConvert.DeserializeObject<FatSecretErrorResponse>(response.Content);
            if (fatSecretErrorResponse.Error != null)
            {
                fatSecretResponse.Error = fatSecretErrorResponse.Error;
            }

            return fatSecretResponse;
        }
    }

    public interface IFatSecretClient
    {
        Task<GetFoodResponse> FoodGetAsync(FoodGetV2Request request);
        Task<FoodsSearchResponse> FoodsSearchAsync(FoodsSearchRequest request);
    }
}
