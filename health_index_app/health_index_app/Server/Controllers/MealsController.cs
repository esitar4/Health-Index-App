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
    [Route("meals")]
    public class MealsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<FatSecretController> _logger;

        private Task<AuthenticationState> authenticationStateTask { get; set; }

        public MealsController(ApplicationDbContext context, IConfiguration config, ILogger<FatSecretController> logger)
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
        public async Task<ActionResult<Meal>> CreateMeal([FromBody] Meal meal)
        {
            //return GetDummyCurrentWeather();
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();
            _context.Entry(meal).Reload();

            return Ok(meal);
        }

        [HttpGet]
        [Route("read")]
        public async Task<ActionResult<Meal>> ReadMeal(int mealId)
        {
            //return GetDummyCurrentWeather();
            var meal = await _context.Meals.Where(m => m.Id == mealId).FirstOrDefaultAsync();

            return Ok(meal);
        }
    }
}
