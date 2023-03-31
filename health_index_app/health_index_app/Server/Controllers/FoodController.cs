using health_index_app.Server.Data;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace health_index_app.Server.Controllers
{
    [ApiController]
    [Route("food")]
    public class FoodController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<FoodController> _logger;

        public FoodController(ApplicationDbContext context, IConfiguration config, ILogger<FoodController> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Food>> CreateFood([FromBody] Food food)
        {
            // Check whether object exists in table
            if (_context.Foods.Any(f => f.Id == food.Id))
                return Ok(food);

            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
            _context.Entry(food).Reload();

            return Ok(food);
        }

        [HttpGet]
        [Route("read")]
        public async Task<ActionResult<Food>> ReadFood(int foodId)
        {
            var food = await _context.Foods.Where(f => f.Id == foodId).FirstOrDefaultAsync();

            if (food == null)
                return NotFound();

            return Ok(food);
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<bool>> UpdateFood([FromBody] Food food)
        {
            try
            {
                _context.Foods.Update(food);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                return NotFound(false);
            }

            return Ok(true);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<bool>> DeleteFood([FromBody] Food food)
        {
            try
            {
                _context.Foods.Remove(food);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                return NotFound(false);
            }

            return Ok(true);
        }
    }
}

