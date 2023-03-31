using health_index_app.Server.Data;
using health_index_app.Server.Models;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace health_index_app.Server.Controllers
{
    [ApiController]
    [Route("usermeal")]
    public class UserMealController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<UserMealController> _logger;

        public UserMealController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IConfiguration config, ILogger<UserMealController> logger)
        {
            _userManager = userManager;
            _context = context;
            _config = config;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<UserMealDTO>> CreateUserMeal([FromBody] UserMealDTO userMealDTO)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            // Check whether object exists in table
            if (_context.UserMeals.Any(um => um.UserId == userId && um.MealId == userMealDTO.MealId))
            {
                userMealDTO.Id = await _context.UserMeals
                    .Where(um => um.UserId == userId && um.MealId == userMealDTO.MealId)
                    .Select(um => um.Id)
                    .FirstOrDefaultAsync();
                return Ok(userMealDTO);
            }

            UserMeal userMeal = new UserMeal()
            {
                UserId = userId,
                MealId = userMealDTO.MealId,
                Name = userMealDTO.Name,
            };

            _context.UserMeals.Add(userMeal);
            await _context.SaveChangesAsync();
            _context.Entry(userMeal).Reload();

            userMealDTO.Id = userMeal.Id;

            return Ok(userMealDTO);
        }

        [HttpGet]
        [Route("read")]
        public async Task<ActionResult<UserMealDTO>> ReadUserMeal(int mealId)
        {
            UserMeal userMeal = await _context.UserMeals.Where(um => um.MealId == mealId).FirstOrDefaultAsync();

            if (userMeal == null)
                return NotFound();

            UserMealDTO userMealDTO = new UserMealDTO
            {
                Id = userMeal.Id,
                Name = userMeal.Name,
                MealId = userMeal.MealId
            };

            return Ok(userMealDTO);
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<bool>> UpdateUserMeal([FromBody] UserMealDTO userMealDTO)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            UserMeal userMeal = await _context.UserMeals
                .Where(um => um.UserId == userId && um.MealId == userMealDTO.MealId)
                .FirstOrDefaultAsync();

            if (userMeal == null) 
                return NotFound(false);

            userMeal.MealId = userMealDTO.MealId;
            userMeal.Name = userMealDTO.Name;

            _context.UserMeals.Update(userMeal);
            await _context.SaveChangesAsync();


            return Ok(true);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<bool>> DeleteUserMeal([FromBody] int mealId)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            UserMeal userMeal = await _context.UserMeals
                .Where(um => um.UserId == userId && um.MealId == mealId)
                .FirstOrDefaultAsync();

            if (userMeal == null)
            {
                return NotFound(false);
            }

            _context.UserMeals.Remove(userMeal);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        [HttpGet]
        [Authorize]
        [Route("get-all-meal-ids")]
        public async Task<ActionResult<List<int>>> GetAllUserMealIds()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            List<int> mealIds = await _context.UserMeals
                .Where(um => um.UserId == userId)
                .Select(um => um.MealId)
                .ToListAsync();
                
            return Ok(mealIds);
        }
    }
}
