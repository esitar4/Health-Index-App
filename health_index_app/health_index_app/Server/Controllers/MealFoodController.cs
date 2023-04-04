using health_index_app.Server.Data;
using Food = health_index_app.Shared.Models.Food;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using health_index_app.Shared.Models;
using health_index_app.Shared.DTObjects;
using Microsoft.AspNetCore.Authorization;

namespace health_index_app.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("mealfood")]
    public class MealFoodController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<MealFoodController> _logger;


        public MealFoodController(ApplicationDbContext context, IConfiguration config, ILogger<MealFoodController> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<MealFood>> CreateMealFood([FromBody] MealFood mealFood)
        {
            // Check whether object exists in table
            if (_context.MealFoods.Any(mf => mf.MealId == mealFood.MealId && mf.FoodId == mealFood.FoodId))
            {
                mealFood.Id = await _context.MealFoods
                    .Where(mf => mf.MealId == mealFood.MealId && mf.FoodId == mealFood.FoodId)
                    .Select(mf => mf.Id)
                    .FirstOrDefaultAsync();
                return Ok(mealFood);
            }

            _context.MealFoods.Add(mealFood);
            await _context.SaveChangesAsync();
            _context.Entry(mealFood).Reload();

            return Ok(mealFood);
        }

        [HttpGet]
        [Route("read")]
        public async Task<ActionResult<IEnumerable<MealFood>>> ReadMealFood(int mealFoodId)
        {

            var MealFood = _context.MealFoods.Where(mf => mf.Id == mealFoodId);

            if (MealFood == null)
            {
                return NotFound();
            }

            return Ok(MealFood);
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<bool>> UpdateMealFood([FromBody] MealFood mealFood)
        {
            try
            {
                _context.MealFoods.Update(mealFood);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(false);
            }

            return Ok(true);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<MealFood>> DeleteMealFood([FromBody] MealFood mealFood)
        {
            try
            {
                _context.MealFoods.Remove(mealFood);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return NotFound(false);
            }

            return Ok(mealFood);
        }

        [HttpGet]
        [Route("get-food-list")]
        public async Task<ActionResult<List<Food>>> GetFoodList(int mealId)
        {
            List<ChildFoodDTO> foodList = await (from mf in _context.MealFoods
                                         join f in _context.Foods on mf.FoodId equals f.Id
                                         where mf.MealId == mealId
                                         select new ChildFoodDTO
                                         {
                                             MealId = mealId,
                                             Food = f,
                                             Amount = mf.Amount
                                         })
                                         .ToListAsync();
            return Ok(foodList);
        }
    }
}
