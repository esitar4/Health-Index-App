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
    [Route("food")]
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
        public async Task<ActionResult<Food>> ReadFood(int foodId)
        {
            var food = await _context.Foods.Where(m => m.Id == foodId).FirstOrDefaultAsync();

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

