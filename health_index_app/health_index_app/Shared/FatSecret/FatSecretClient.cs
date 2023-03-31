using health_index_app.Shared.FatSecret.Authentication;
using health_index_app.Shared.FatSecret.Requests;
using health_index_app.Shared.FatSecret.ResponseObjects;
using Newtonsoft.Json;
using RestSharp;

namespace health_index_app.Shared.FatSecret
{
    public class FatSecretClient : IFatSecretClient
    {
        private readonly FatSecretAuthenticationManager _authManager;
        private readonly RestClientOptions _options;
        private readonly RestClient _client;
        private readonly HttpClient _httpClient;

        private readonly string _url = "https://platform.fatsecret.com/rest/server.api";
        

        public FatSecretClient(FatSecretCredentials credentials, HttpClient httpClient)
        {
            _authManager = new FatSecretAuthenticationManager(credentials);
            _httpClient = httpClient;
            _options = new RestClientOptions(_url);
            _client = new RestClient(_httpClient, _options);

        }

        public async Task<GetFoodResponse> FoodGetAsync(FoodGetV2Request request)
        {
            return await FatSecretRequest<GetFoodResponse>(request);
        }

        public async Task<FoodsSearchResponse> FoodsSearchAsync(FoodsSearchRequest request)
        {
            return await FatSecretRequest<FoodsSearchResponse>(request);
        }

        private async Task<T> FatSecretRequest<T>(IFatSecretRequest fatSecretRequest) where T : FatSecretResponse, new()
        {
            var request = new RestRequest(_url, Method.Get);
            var authToken = await _authManager.GetAuthHeaderAsync(_httpClient);
            request.AddHeader("Authorization", authToken);

            foreach (var parameter in fatSecretRequest.GetParameters())
            {
                request.AddParameter(parameter.Item1, parameter.Item2);
            }

            request.AddParameter("format", "json");

            var response = await _client.ExecuteAsync<T>(request);

            T fatSecretResponse;
            // FatSecret Servings List Response
            if (response.Data != null)
            {
                fatSecretResponse = response.Data;
            }
            // Parse Servings non list response to list
            else
            {
                var json = response.Content;
                try
                {
                    fatSecretResponse = JsonConvert.DeserializeObject<T>(json);
                }
                catch
                {
                    if (typeof(T) == typeof(GetFoodResponse))
                    {
                        json = json.Replace("{\"serving\": ", "{\"serving\": [");
                        json = json.Insert(json.IndexOf("}") + 1, "]");
                        fatSecretResponse = JsonConvert.DeserializeObject<T>(json);
                    }
                    else
                    {
                        fatSecretResponse = new() { Error = new FatSecretError { Code = -1, Message = "Json could not be converted to existing response objects!"} };
                    }
                }
                
            }

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
