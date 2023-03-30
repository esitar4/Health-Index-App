using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using health_index_app.Server.Models;
using health_index_app.Server.Data;

namespace health_index_app.Server.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        [HttpPost]
        [Route("adduser")]
       // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<string>> AddUserToAdmin([FromBody] string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var roles = await _userManager.GetRolesAsync(user);
            var r = roles.FirstOrDefault();
            Console.WriteLine(r);

            if (user == null)
                return NotFound($"User with the given id was not found");

            var result = await _userManager.AddToRoleAsync(user, "Admin");
            if (result.Succeeded)
                return Ok($"Successfully added user {user.Id} to admin role");
            else
                return
                    BadRequest(result.Errors);
        }
    }
}
