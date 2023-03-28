using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace health_index_app.Shared.Models
{
    public class Meal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Range(0.0, 10.0, ErrorMessage = "Score must be between 0 and 10")]
        public double HealthIndex { get; set; } = -1;

    }
}
