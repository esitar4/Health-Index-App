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
    [Route("MealFood")]
    public class MealFoodsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<FatSecretController> _logger;

        private Task<AuthenticationState> authenticationStateTask { get; set; }

        public MealFoodsController(ApplicationDbContext context, IConfiguration config, ILogger<FatSecretController> logger)
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
        public async Task<ActionResult<MealFood>> createMealFood([FromBody] MealFood MealFood)
        {
            //return GetDummyCurrentWeather();
            _context.MealFoods.Add(MealFood);
            await _context.SaveChangesAsync();
            _context.Entry(MealFood).Reload();

            return Ok(MealFood);
        }

        [HttpGet]
        [Route("read")]
        public async Task<ActionResult<MealFood>> readMealFood(int MealFoodId)
        {
            //return GetDummyCurrentWeather();
            var MealFood = await _context.MealFoods.Where(m => m.Id == MealFoodId).FirstOrDefaultAsync();

            return Ok(MealFood);
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<MealFood>> updateMealFood([FromBody] int FoodIdToUpdate, [FromBody] MealFood NewMealFood)
        {
            //return GetDummyCurrentWeather();
            var updatedMealFood = await _context.MealFoods.Where(m => m.Id == FoodIdToUpdate).FirstOrDefaultAsync();
            await _context.SaveChangesAsync();
            _context.Entry(NewMealFood).Reload();


            return Ok(NewMealFood);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<MealFood>> deleteMealFood([FromBody] MealFood MealFood)
        {
            //return GetDummyCurrentWeather();
            _context.MealFoods.Remove(MealFood);
            await _context.SaveChangesAsync();

            return Ok(MealFood);
        }
    }
}
