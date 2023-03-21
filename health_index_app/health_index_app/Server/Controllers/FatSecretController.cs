using health_index_app.Shared.FatSecret;
using health_index_app.Shared.FatSecret.Authentication;
using health_index_app.Shared.FatSecret.Requests;
using health_index_app.Shared.FatSecret.ResponseObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace health_index_app.Server.Controllers
{
    [ApiController]
    [Route("api/fatsecret")]
    public class FatSecretController : Controller
    {
        private readonly IFatSecretClient _fatSecretClient = 
                                                            new FatSecretClient(
                                                                                new FatSecretCredentials
                                                                                {
                                                                                    ClientKey = "44a3ee4ca84b42ebb3234bc6bf66518c",
                                                                                    ClientSecret = "29c8029e8f1b4fdcae11abc7d1babfdd"
                                                                                },
                                                                                    new HttpClient()
                                                                                );
        //private readonly IConfiguration _config;
        //private readonly ILogger<FatSecretController> _logger;

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<FatSecretResponse> Get(string searchExpression)
        {
            //return GetDummyCurrentWeather();
            var request = new FoodsSearchRequest { SearchExpression = searchExpression, MaxResults = 10 };

            return await _fatSecretClient.FoodsSearchAsync(request);
        }
    }
}
