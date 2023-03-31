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
        public async Task<ActionResult<MealFood>> ReadMealFood(int mealFoodId)
        {

            var MealFood = await _context.MealFoods.Where(mf => mf.Id == mealFoodId).FirstOrDefaultAsync();

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
    }
}
