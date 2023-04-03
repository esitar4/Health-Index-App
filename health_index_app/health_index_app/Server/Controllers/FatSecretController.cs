using health_index_app.Shared.FatSecret;
using health_index_app.Shared.FatSecret.Requests;
using health_index_app.Shared.FatSecret.ResponseObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace health_index_app.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/fatsecret")]
    public class FatSecretController : Controller
    {
        private readonly IFatSecretClient _fatSecretClient;
        private readonly IConfiguration _config;
        private readonly ILogger<FatSecretController> _logger;

        public FatSecretController(IFatSecretClient fatSecretClient, IConfiguration config, ILogger<FatSecretController> logger) 
        {
            _fatSecretClient = fatSecretClient;
            _config = config;
            _logger = logger;
        }

        [HttpGet]
        [Route("foodsearch")]
        public async Task<FatSecretResponse> Get(string searchExpression, int maxResults = 10)
        {
            var request = new FoodsSearchRequest { SearchExpression = searchExpression, MaxResults = maxResults };

            return await _fatSecretClient.FoodsSearchAsync(request);
        }

        [HttpGet]
        [Route("foodget")]
        public async Task<FatSecretResponse> Get(string foodId)
        {
            var request = new FoodGetV2Request { FoodId = Convert.ToInt32(foodId) };

            return await _fatSecretClient.FoodGetAsync(request);
        }
    }
}
