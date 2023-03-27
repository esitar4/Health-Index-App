using health_index_app.Shared.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace health_index_app.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
/*        [Key]
        [Required]
        //[MinLength(6, ErrorMessage = "Username must be at least 6 characters")]
        //[MaxLength(15, ErrorMessage = "Username must be no longer than 15 characters")]
        [RegularExpression("^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$",
            ErrorMessage = "Username must be between 8 and 20 characters and cannot include '_' or '.'")]
        public string Username { get; set; }*/
        //[Required]
        //[EmailAddress(ErrorMessage = "Not a valid email address")]
        //public string Email { get; set; }
/*        [Required]
        //[MinLength(8, ErrorMessage = "Password must be at least 6 characters")]
        //[MaxLength(10, ErrorMessage = "Password must be no longer than 15 characters")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$",
            ErrorMessage = "Password must be a minimum of 8 characters, have at least 1 letter, 1 number and 1 special character")]
        public string Password { get; set; }
        [Required]
        public bool IsLocked { get; set; } = false;
        [Required]
        public bool IsAdmin { get; set; } = false;*/

        public string? ParentId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        [Range(0.001, 9999.99, ErrorMessage = "Weight must be in between 0 and 9999.99")]
        public double? Weight { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        [Range(0.001, 999.99, ErrorMessage = "Height must be in between 0 and 999.99")]
        public double? Height { get; set; }
        [RegularExpression("[MFO]", ErrorMessage = "Invalid Gender Character")]   //character for internal use - parsed from dropdown menu on frontend
        public char? Gender { get; set; }

        //Navigation Property
        [ForeignKey("ParentId")]
        public ApplicationUser Parent { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<UserMeal> UserMeals { get; set; }
    }
}
