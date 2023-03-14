using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace health_index_app.Shared
{
    public class User
    {
        [Key]
        [Required]
        //[MinLength(6, ErrorMessage = "Username must be at least 6 characters")]
        //[MaxLength(15, ErrorMessage = "Username must be no longer than 15 characters")]
        [RegularExpression(@"^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$", 
            ErrorMessage = "Username must be between 8 and 20 characters and cannot include '_' or '.'")]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }
        [Required]
        //[MinLength(8, ErrorMessage = "Password must be at least 6 characters")]
        //[MaxLength(10, ErrorMessage = "Password must be no longer than 15 characters")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$", 
            ErrorMessage = "Password must be a minimum of 8 characters, have at least 1 letter, 1 number and 1 special character")]
        public string Password { get; set; }
        [Required]
        public bool IsLocked { get; set; } = false;
        [Required]
        public bool IsAdmin { get; set; } = false;
        [ForeignKey("User")]
        public string? ParentId { get; set; }
    }
}
