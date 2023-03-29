using health_index_app.Client.Pages;
using health_index_app.Server.Data;
using health_index_app.Shared.FatSecret;
using health_index_app.Shared.FatSecret.Requests;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace health_index_app.Server.Controllers
{
    [ApiController]
    [Route("Food")]
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<FatSecretController> _logger;

        public FoodController(ApplicationDbContext context, IConfiguration config, ILogger<FatSecretController> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Food>> CreateFood([FromBody] Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
            _context.Entry(food).Reload();

            return Ok(food);
        }

        [HttpGet]
        [Route("read")]
        public async Task<ActionResult<Food>> ReadFood(int FoodId)
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
