using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace health_index_app.Shared.Models
{
    public class MealFood
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MealId { get; set; }

        [Required]
        public int FoodId { get; set; }

        [Required]
        [Range(0.0001, Double.MaxValue, ErrorMessage = "Serving size must be greater than 0")]
        public double ServingSize { get; set; } = 1;
    }
}
