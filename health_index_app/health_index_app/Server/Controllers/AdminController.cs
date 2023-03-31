using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using health_index_app.Server.Models;
using health_index_app.Server.Data;

namespace health_index_app.Server.Controllers
{
    //[ApiController]
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


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("adduser")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("unlockAccount")]
        public async Task<ActionResult<string>> UnlockUserAccount([FromBody] string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound($"User with the given id was not found");
            user.LockoutEnd = null;
            var updateSuccess = await _userManager.UpdateAsync(user);
            if (updateSuccess.Succeeded)
                return Ok($"Successfully unlocked user {user.Id}'s account");
            else
                return
                    BadRequest(updateSuccess.Errors);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("deleteAccount")]
        public async Task<ActionResult<string>> DeleteUserAccount([FromBody] string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound($"User with the given id was not found");

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
                return Ok($"Successfully deleted user {user.Id}'s account");
            else
                return
                    BadRequest(result.Errors);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("addParentChildRelationship")]
        public async Task<ActionResult<string>> AddParentChildRelationship([FromBody] string combinedId)
        {
            string[] splitString = combinedId.Split(".");
            string childId = splitString[0];
            string parentId = splitString[1];
            if (childId == parentId)
                return BadRequest("Parent and child id cannot be the same");

            var childUser = await _userManager.FindByIdAsync(childId);
            var parentUser = await _userManager.FindByIdAsync(parentId);

            if (childUser == null)
                return NotFound($"Child: user with the given id was not found");
            if (parentUser == null)
                return NotFound($"Parent: user with the given id was not found");

            childUser.ParentId = parentId;
            var updateSuccess = await _userManager.UpdateAsync(childUser);

            if (updateSuccess.Succeeded)
                return Ok($"Successfully added user {parentId} as a parent to {childUser.Id}'s account");
            else
                return
                    BadRequest(updateSuccess.Errors);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("removeParentChildRelationship")]
        public async Task<ActionResult<string>> RemoveParentChildRelationship([FromBody] string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound($"User with the given id was not found");

            user.ParentId = null;
            var update = await _userManager.UpdateAsync(user);

            if (update.Succeeded)
                return Ok($"Successfully removed user {userId}'s parent account");
            else
                return
                    BadRequest(update.Errors);
        }
    }
}
