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
        private readonly IFatSecretSetup _fatSecretSetup;
        private readonly IConfiguration _config;
        private readonly ILogger<FatSecretController> _logger;

        public FatSecretController(IFatSecretSetup fatSecretSetup, IConfiguration config, ILogger<FatSecretController> logger) 
        {
            _fatSecretSetup = fatSecretSetup;
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

            return await _fatSecretSetup.client.FoodsSearchAsync(request);
        }

        [HttpGet]
        [Route("foodget")]
        public async Task<FatSecretResponse> Get(string foodId)
        {
            //return GetDummyCurrentWeather();
            var request = new FoodGetV2Request { FoodId = Convert.ToInt32(foodId) };

            return await _fatSecretSetup.client.FoodGetAsync(request);
        }
    }
}
