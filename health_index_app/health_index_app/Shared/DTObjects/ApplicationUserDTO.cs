using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace health_index_app.Shared.DTObjects
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; } = String.Empty;
        public string Username { get; set; }
        public string? ParentId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Range(0.001, 9999.99, ErrorMessage = "Weight must be in between 0 and 9999.99")]
        public double? Weight { get; set; }
        [Range(0.001, 999.99, ErrorMessage = "Height must be in between 0 and 999.99")]
        public double? Height { get; set; }
        [RegularExpression("[MFO]", ErrorMessage = "Invalid Gender Character")]   //character for internal use - parsed from dropdown menu on frontend
        public char? Gender { get; set; }
        public bool Admin { get; set; }
        public string LockedStatus { get; set; }
        public DateTimeOffset? LockEnd { get; set; }
    }
}
