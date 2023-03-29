// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using health_index_app.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace health_index_app.Server.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public char? Gender { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Update Phone number")]
            public string PhoneNumber { get; set; }

            [DateOfBirth(ErrorMessage = "Date of Birth must be in the past")]
            [Display(Name = "Date of Birth")]
            public DateTime? DateOfBirth { get; set; }
            [Display(Name = "Update Weight (pounds)")]
            [Range(0.001, 9999.99, ErrorMessage = "Weight must be in between 0 and 9999.99")]
            public double? Weight { get; set; }
            [Display(Name = "Update Height (inches)")]
            [Range(0.001, 999.99, ErrorMessage = "Height must be in between 0 and 999.99")]
            public double? Height { get; set; }
            [RegularExpression("[MFO]", ErrorMessage = "Invalid Gender Character")]   //character for internal use - parsed from dropdown menu on frontend
            [Display(Name = "Gender (Optional)")]
            public char? Gender { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            if(user.DateOfBirth is not null)
                this.DateOfBirth = user.DateOfBirth.Value.Date;
            if (user.Weight is not null) 
                this.Weight = user.Weight;
            if(user.Height is not null)
                this.Height = user.Height;
            if(user.Gender is not null)
                this.Gender = user.Gender;

            Username = userName;
            PhoneNumber = phoneNumber;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            Console.WriteLine($"Old phone number: {this.PhoneNumber} old height: {this.Height} old weight: {this.Weight}");
            user.PhoneNumber = Input.PhoneNumber;
            user.Weight = Input.Weight;
            user.Height = Input.Height;
            user.Gender = Input.Gender;
            var updateSuccess = await _userManager.UpdateAsync(user);
            Console.WriteLine($"new height: {user.Height} new weight: {user.Weight}");

            /*
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            */

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}