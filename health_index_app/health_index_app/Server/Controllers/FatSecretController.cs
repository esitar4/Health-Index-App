using AutoMapper.Internal;
using health_index_app.Server.Data;
using health_index_app.Shared.FatSecret;
using health_index_app.Shared.FatSecret.Authentication;
using health_index_app.Shared.FatSecret.Requests;
using health_index_app.Shared.FatSecret.ResponseObjects;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;

namespace health_index_app.Server.Controllers
{
    [ApiController]
    [Route("api/fatsecret")]
    public class FatSecretController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFatSecretClient _fatSecretClient;
        private readonly IConfiguration _config;
        private readonly ILogger<FatSecretController> _logger;

        private Task<AuthenticationState> authenticationStateTask { get; set; }

        public FatSecretController( ApplicationDbContext context, IFatSecretClient fatSecretClient, IConfiguration config, ILogger<FatSecretController> logger) 
        {
            _context = context;
            _fatSecretClient = fatSecretClient;
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
/*        [HttpPost]
        [Route("createmeal")]
        public async Task<HttpStatusCode> createMeal(Meal mealId)
        {
            var sqlMeals = _context.Meals;

            sqlMeals.Add(mealId);

            _context.SaveChanges();

            return HttpStatusCode.OK;
        }*/

/*        async Task<string> getUserId()
        {
            var user = (await authenticationStateTask).User;
            var userid = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return userid;
        }*/

/*        private Dictionary<Shared.Models.Food, Double> convertResponseToFoodDictionary(Dictionary<int, double> responseFoods)
        {
            var foods = new Dictionary<Shared.Models.Food, Double>();

            foreach( var foodResponse in responseFoods.Values )
            {
                var food = convertResponseToFood( _fatSecretClient.FoodGetAsync(new FoodGetV2Request { FoodId = Convert.ToInt32(foodResponse) }).Result.Food);
            }
            return foods;
        }

        private static Shared.Models.Food convertResponseToFood( Shared.FatSecret.ResponseObjects.Food responseFood)
        {
            var food = new Shared.Models.Food();

            //Add all of the food attributes from responseFood to food

            food.Id = Convert.ToInt32(responseFood.Food_Id);
            food.FoodName = responseFood.Food_Name;
            food.FoodType = responseFood.Food_Type;
            food.BrandName = responseFood.Brand_Name;
            food.FoodURL = responseFood.Food_Url;

            food.ServingId = responseFood.Servings.Serving




            return food;
        }*/
    }
}
