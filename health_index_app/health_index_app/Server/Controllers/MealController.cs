using health_index_app.Server.Data;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace health_index_app.Server.Controllers
{
    [ApiController]
    [Route("meal")]
    public class MealController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<FatSecretController> _logger;

        public MealController(ApplicationDbContext context, IConfiguration config, ILogger<FatSecretController> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Meal>> CreateMeal([FromBody] Meal meal)
        {
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();
            _context.Entry(meal).Reload();

            return Ok(meal);
        }

        [HttpGet]
        [Route("read")]
        public async Task<ActionResult<Meal>> ReadMeal(int mealId)
        {
            Meal meal = await _context.Meals.Where(m => m.Id == mealId).FirstOrDefaultAsync();
            if (meal == null)
            {
                return NotFound();
            }

            return Ok(meal);
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<bool>> UpdateMeal([FromBody] Meal meal)
        {
            try
            {
                _context.Meals.Update(meal);
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
        public async Task<ActionResult<bool>> DeleteMeal([FromBody] Meal meal)
        {
            try
            {
                _context.Meals.Remove(meal);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(false);
            }

            return Ok(true);
        }
    }
}
