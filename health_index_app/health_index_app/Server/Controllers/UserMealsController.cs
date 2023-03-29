using health_index_app.Server.Data;
using health_index_app.Server.Models;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace health_index_app.Server.Controllers
{
    [ApiController]
    [Route("UserMeal")]
    public class UserMealsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<FatSecretController> _logger;

        private Task<AuthenticationState> authenticationStateTask { get; set; }

        public UserMealsController(ApplicationDbContext context, IConfiguration config, ILogger<FatSecretController> logger)
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
        public async Task<ActionResult<int>> CreateUserMeal([FromBody] dynamic PostBody)
        {
            UserMeal userMeal = new UserMeal();

            userMeal.Meal = PostBody.meal;
            userMeal.Name = PostBody;
            userMeal.UserId = await GetUserId();

            _context.UserMeals.Add(userMeal);
            await _context.SaveChangesAsync();
            _context.Entry(userMeal).Reload();

            return Ok(userMeal.Id);
        }

        [HttpGet]
        [Route("read")]
        public async Task<ActionResult<Meal>> ReadUserMeal(int UserMealId)
        {
            //return GetDummyCurrentWeather();
            var userMeal = await _context.UserMeals.Where(m => m.Id == UserMealId).FirstOrDefaultAsync();
            var meal = userMeal.Meal;
            return Ok(meal);
        }

        //[HttpPost]
        //[Route("update")]
        //public async Task<ActionResult<UserMeal>> updateUserMeal([FromBody] List<int> newUserMealVariables)
        //{
        //    //return GetDummyCurrentWeather();
        //    //int userMealId = newUserMeal[0];
        //    //int mealId = newUserMeal[1];
        //    //UserMeal newUserMeal = new UserMeal { Id = newUserMeal[0], Meal =}
        //    var updatedUserMeal = await _context.UserMeals.Where(m => m.Id == userMealId).FirstOrDefaultAsync();
        //    await _context.SaveChangesAsync();
        //    _context.Entry(NewUserMeal).Reload();


        //    return Ok(NewUserMeal);
        //}

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<bool>> DeleteUserMeal([FromBody] int UserMealId)
        {
            //return GetDummyCurrentWeather();
            var deletedUserMeal = await _context.UserMeals.Where(m => m.Id == UserMealId).FirstOrDefaultAsync();
            _context.UserMeals.Remove(deletedUserMeal);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        private async Task<string> GetUserId()
        {
            var user = (await authenticationStateTask).User;
            var userid = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return userid;
        }
    }
}
