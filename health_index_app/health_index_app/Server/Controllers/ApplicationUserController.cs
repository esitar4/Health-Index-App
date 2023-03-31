using health_index_app.Server.Data;
using health_index_app.Server.Models;
using health_index_app.Shared.DTObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace health_index_app.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/applicationuser")]
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<FoodController> _logger;

        public ApplicationUserController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IConfiguration config, ILogger<FoodController> logger)
        {
            _userManager = userManager;
            _context = context;
            _config = config;
            _logger = logger;
        }

        [HttpGet]
        [Route("get-child-usernames")]
        public async Task<ActionResult<List<string>>> getChildUsernames()
        {
            var user = await _userManager.GetUserAsync(User);
            List<string> childUsernames = await _context.Users
                .Where(u => u.ParentId == user.Id)
                .Select(u => u.UserName)
                .ToListAsync();

            return Ok(childUsernames);
        }

        [HttpGet]
        [Route("get-child-meals")]
        public async Task<ActionResult<List<ChildMealDTO>>> getChildMeals()
        {
            var user = await _userManager.GetUserAsync(User);
            List<ChildMealDTO> childMealFoods = await (from u in _context.Users
                                        join um in _context.UserMeals on u.Id equals um.UserId
                                        join m in _context.Meals on um.MealId equals m.Id
                                        where u.ParentId == user.Id
                                        select new ChildMealDTO
                                        {
                                            childUsername = u.UserName,
                                            MealId = m.Id,
                                            Name = um.Name,
                                            HealthIndex = m.HealthIndex
                                        }).ToListAsync();
            return Ok(childMealFoods);
        }

        [HttpPost]
        [Route("add-child-to-user")]
        public async Task<ActionResult<bool>> AddChildToUser([FromBody] string username)
        {
            var child = _context.Users.Where(u => u.NormalizedUserName == username.ToUpper()).FirstOrDefault();

            if (child == null)
                return NotFound(false);

            var user = await _userManager.GetUserAsync(User);
            child.ParentId = user.Id;
            _context.Update(child);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        [HttpPost]
        [Route("remove-child-from-user")]
        public async Task<ActionResult<bool>> RemoveChildFromUser([FromBody] string username)
        {
            var child =  _context.Users.Where(u => u.UserName == username).FirstOrDefault();

            if (child == null) 
                return NotFound(false);

            child.ParentId = null;
            _context.Update(child);
            await _context.SaveChangesAsync();

            return Ok(true);
        }
    }
}
