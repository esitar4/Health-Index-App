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
    [Route("meals")]
    public class MealsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<FatSecretController> _logger;

        private Task<AuthenticationState> authenticationStateTask { get; set; }

        public MealsController(ApplicationDbContext context, IConfiguration config, ILogger<FatSecretController> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Meal>> createMeal([FromBody] Meal meal)
        {
            //return GetDummyCurrentWeather();
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();
            _context.Entry(meal).Reload();

            return Ok(meal);
        }

        [HttpGet]
        [Route("read")]
        public async Task<ActionResult<Meal>> readMeal(int mealId)
        {
            //return GetDummyCurrentWeather();
            var meal = await _context.Meals.Where(m => m.Id == mealId).FirstOrDefaultAsync();

            return Ok(meal);
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
