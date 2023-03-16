using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace health_index_app.Server.Models
{
    public class Admin
    {
        [Key]
        [ForeignKey("User")]
        [Required]
        [RegularExpression("^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$",
            ErrorMessage = "Username must be between 8 and 20 characters and cannot include '_' or '.'")]
        public string Username { get; set; }
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$",
            ErrorMessage = "Password must be a minimum of 8 characters, have at least 1 letter, 1 number and 1 special character")]
        [Required]
        public string Password { get; set; }
    }
}
