using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace health_index_app.Shared.Models
{

    public class MealFood
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Meal")]
        public int MealId { get; set; }

        public virtual Meal? Meal { get; set; }

        public int FoodId { get; set; }

        public int ServingId { get; set; }

        [ForeignKey("FoodId, ServingId")]
        public virtual Food? Food { get; set; }

        [Required]
        [Range(0.0001, Double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public double Amount { get; set; } = 1;
    }
}