using health_index_app.Shared.FatSecret.ResponseObjects;
using Newtonsoft.Json;
using System.Text;

namespace health_index_app.Shared.FatSecret.Authentication
{
    public class FatSecretAuthenticationManager
    {
        private readonly FatSecretAuthenticationToken _authToken;
        private readonly FatSecretCredentials _credentials;
        private FatSecretTokenResponse _tokenResponse = new FatSecretTokenResponse();

        private readonly string _url = "https://oauth.fatsecret.com/connect/token";

        public FatSecretAuthenticationManager(FatSecretCredentials credentials)
        {
            _credentials = credentials;
            _authToken = new FatSecretAuthenticationToken();
        }

        private async Task GetNewTokenAsync(HttpClient httpClient)
        {
            HttpClient Http = httpClient;
            var byteArray = Encoding.ASCII.GetBytes($"{_credentials.ClientKey}:{_credentials.ClientSecret}");
            Http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var values = new Dictionary<string, string>
                            {
                               { "scope", "basic" },
                               { "grant_type", "client_credentials" }
                            };
            var content = new FormUrlEncodedContent(values);
            var responses = await Http.PostAsync(_url, content);
            var responseString = await responses.Content.ReadAsStringAsync();

            if (responseString != null)
            {
                _tokenResponse = JsonConvert.DeserializeObject<FatSecretTokenResponse>(responseString);
                _authToken.SetToken(_tokenResponse);
            }
        }

        public async Task<string> GetAuthHeaderAsync(HttpClient httpClient)
        {

            if (_authToken.IsExpired)
            {
                await GetNewTokenAsync(httpClient);
            }

            return $"Bearer {_authToken.AccessToken}";

        }

    }
}
