// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using System;
using System.Threading.Tasks;
using health_index_app.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace health_index_app.Server.Areas.Identity.Pages.Account.Manage
{
    public class PersonalDataModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;

        public PersonalDataModel(
            UserManager<ApplicationUser> userManager,
            ILogger<PersonalDataModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public DateTime? DateOfBirth { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public char? Gender { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [DateOfBirth(ErrorMessage = "Date of Birth must be in the past")]
            [Display(Name = "Date of Birth (Optional)")]
            public DateTime? DateOfBirth { get; set; }
            [Display(Name = "Weight (Optional - pounds)")]
            [Range(0.001, 9999.99, ErrorMessage = "Weight must be in between 0 and 9999.99")]
            public double? Weight { get; set; }
            [Display(Name = "Height (Optional - inches)")]
            [Range(0.001, 999.99, ErrorMessage = "Height must be in between 0 and 999.99")]
            public double? Height { get; set; }
            [RegularExpression("[MFO]", ErrorMessage = "Invalid Gender Character")]   //character for internal use - parsed from dropdown menu on frontend
            [Display(Name = "Gender (Optional")]
            public char? Gender { get; set; }
        }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            Console.WriteLine(user.DateOfBirth);
            this.DateOfBirth = user.DateOfBirth.Value.Date;
            this.Weight = user.Weight;
            this.Height = user.Height;
            this.Gender = user.Gender;
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            return Page();
        }
    }
}
