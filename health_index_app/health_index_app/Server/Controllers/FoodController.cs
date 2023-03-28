using AutoMapper.Internal;
using health_index_app.Client.Services;
using health_index_app.Server.Data;
using health_index_app.Shared.FatSecret;
using health_index_app.Shared.FatSecret.Authentication;
using health_index_app.Shared.FatSecret.Requests;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;

namespace health_index_app.Server.Controllers
{
    [ApiController]
    [Route("Food")]
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<FatSecretController> _logger;
        private readonly FatSecretAPIServices _fatSecretClient;

        private Task<AuthenticationState> authenticationStateTask { get; set; }

        public FoodController(ApplicationDbContext context, IConfiguration config, ILogger<FatSecretController> logger, FatSecretAPIServices fatSecretClient)
        {
            _context = context;
            _config = config;
            _logger = logger;
            _fatSecretClient = fatSecretClient;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Food>> createFood([FromBody] int foodId)
        {
            //return GetDummyCurrentWeather();

            Food food;

            try
            {
                food = new Food();

                var responseFood = _fatSecretClient.FoodGetAsync(foodId).Result.Food;

                //Add all of the food attributes from responseFood to food

                food.Id = Convert.ToInt32(responseFood.Food_Id);
                food.FoodName = responseFood.Food_Name;
                food.FoodType = responseFood.Food_Type;
                food.BrandName = responseFood.Brand_Name;
                food.FoodURL = responseFood.Food_Url;

                food.ServingId = Convert.ToInt32(responseFood.Servings.Serving[0].Serving_Id);
                food.ServingURL = responseFood.Food_Url;
                food.ServingDescription = responseFood.Servings.Serving[0].Serving_Description;
                food.MetricServingAmount = Convert.ToDouble(responseFood.Servings.Serving[0].Metric_Serving_Amount);
                food.MetricServingUnit = responseFood.Servings.Serving[0].Metric_Serving_Unit;
                food.MeasurementDescription = responseFood.Servings.Serving[0].Measurement_Description;

                food.Calories = Convert.ToDouble(responseFood.Servings.Serving[0].Calories);
                food.Calcium = Convert.ToDouble(responseFood.Servings.Serving[0].Calcium);
                food.CarboHydrate = Convert.ToDouble(responseFood.Servings.Serving[0].Carbohydrate);
                food.Cholesterol = Convert.ToDouble(responseFood.Servings.Serving[0].Cholesterol);
                food.Fat = Convert.ToDouble(responseFood.Servings.Serving[0].Fat);
                food.Fiber = Convert.ToDouble(responseFood.Servings.Serving[0].Fiber);
                food.Iron = Convert.ToDouble(responseFood.Servings.Serving[0].Iron);
                food.PolyunsaturatedFat = Convert.ToDouble(responseFood.Servings.Serving[0].Polyunsaturated_Fat);
                food.Potassium = Convert.ToDouble(responseFood.Servings.Serving[0].Potassium);
                food.Protein = Convert.ToDouble(responseFood.Servings.Serving[0].Protein);
                food.SaturatedFat = Convert.ToDouble(responseFood.Servings.Serving[0].Saturated_Fat);
                food.Sodium = Convert.ToDouble(responseFood.Servings.Serving[0].Sodium);
                food.Sugar = Convert.ToDouble(responseFood.Servings.Serving[0].Sugar);
                food.VitaminA = Convert.ToDouble(responseFood.Servings.Serving[0].Vitamin_A);
                food.VitaminC = Convert.ToDouble(responseFood.Servings.Serving[0].Vitamin_C);
                food.VitaminD = Convert.ToDouble(responseFood.Servings.Serving[0].Vitamin_D);

                _context.Foods.Add(food);
                await _context.SaveChangesAsync();

                return Ok(food);
            }
            catch
            {
                throw;
                throw new Exception("Unable to create Food");
            }
        }

        [HttpGet]
        [Route("read")]
        public async Task<ActionResult<Food>> readFood(int FoodId)
        {
            //return GetDummyCurrentWeather();
            var Food = await _context.Foods.Where(m => m.Id == FoodId).FirstOrDefaultAsync();

            return Ok(Food);
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

/**/
