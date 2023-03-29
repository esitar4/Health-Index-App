using AutoMapper.Internal;
using health_index_app.Client.Pages;
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
        public async Task<ActionResult<UserMeal>> createUserMeal([FromBody] UserMeal userMeal)
        {
            //return GetDummyCurrentWeather();

            //UserMeal userMeal = new UserMeal();
            //userMeal.MealId = MealId;
            //userMeal.Name = MealName;
            //userMeal.UserId = getUserId().Result;

            _context.UserMeals.Add(userMeal);
            await _context.SaveChangesAsync();
            _context.Entry(userMeal).Reload();

            return Ok(userMeal);
        }

        [HttpGet]
        [Route("read")]
        public async Task<ActionResult<UserMeal>> readUserMeal(int UserMealId)
        {
            //return GetDummyCurrentWeather();
            var UserMeal = await _context.UserMeals.Where(m => m.Id == UserMealId).FirstOrDefaultAsync();

            return Ok(UserMeal);
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<UserMeal>> updateUserMeal([FromBody] UserMeal NewUserMeal)
        {
            //return GetDummyCurrentWeather();
            var updatedUserMeal = await _context.UserMeals.Where(m => m.Id == NewUserMeal.Id).FirstOrDefaultAsync();
            await _context.SaveChangesAsync();
            _context.Entry(NewUserMeal).Reload();


            return Ok(NewUserMeal);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<UserMeal>> deleteUserMeal([FromBody] UserMeal UserMeal)
        {
            //return GetDummyCurrentWeather();
            _context.UserMeals.Remove(UserMeal);
            await _context.SaveChangesAsync();

            return Ok(UserMeal);
        }

        async Task<string> getUserId()
        {
            var user = (await authenticationStateTask).User;
            var userid = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return userid;
        }
    }
}
