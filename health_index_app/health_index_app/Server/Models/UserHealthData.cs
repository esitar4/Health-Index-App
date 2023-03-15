using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace health_index_app.Server.Models
{
    public class UserHealthData
    {
        [Key]
        [ForeignKey("User")]
        [Required]
        //[MinLength(6, ErrorMessage = "Username must be at least 6 characters")]
        //[MaxLength(15, ErrorMessage = "Username must be no longer than 15 characters")]
        [RegularExpression("^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$",
            ErrorMessage = "Username must be between 8 and 20 characters and cannot include '_' or '.'")]
        public string Username { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public double? Weight { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public double? Height { get; set; }
        [RegularExpression("[MFO]")]   //character for internal use - parsed from dropdown menu on frontend
        public char? Gender { get; set; }
    }
}
