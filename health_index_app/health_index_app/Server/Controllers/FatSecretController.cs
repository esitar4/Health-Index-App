using health_index_app.Shared.FatSecret;
using health_index_app.Shared.FatSecret.Authentication;
using health_index_app.Shared.FatSecret.Requests;
using health_index_app.Shared.FatSecret.ResponseObjects;
using Microsoft.AspNetCore.Mvc;

namespace health_index_app.Server.Controllers
{
    [ApiController]
    [Route("api/fatsecret")]
    public class FatSecretController : Controller
    {
        private readonly IFatSecretClient _fatSecretClient = new FatSecretClient(
            new FatSecretCredentials
            {
                ClientKey = "44a3ee4ca84b42ebb3234bc6bf66518c",
                ClientSecret = "29c8029e8f1b4fdcae11abc7d1babfdd"
            },
            new HttpClient()
        );
        private readonly IConfiguration _config;
        private readonly ILogger<FatSecretController> _logger;

        public FatSecretController(IConfiguration config, ILogger<FatSecretController> logger) 
        {
            //_fatSecretClient = fatSecretClient;
            _config = config;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet]
        [Route("foodsearch")]
        public async Task<FatSecretResponse> Get(string searchExpression, int maxResults = 10)
        {
            //return GetDummyCurrentWeather();
            var request = new FoodsSearchRequest { SearchExpression = searchExpression, MaxResults = maxResults };

            return await _fatSecretClient.FoodsSearchAsync(request);
        }

        [HttpGet]
        [Route("foodget")]
        public async Task<FatSecretResponse> Get(string foodId)
        {
            //return GetDummyCurrentWeather();
            var request = new FoodGetV2Request { FoodId = Convert.ToInt32(foodId) };

            return await _fatSecretClient.FoodGetAsync(request);
        }
    }
}
