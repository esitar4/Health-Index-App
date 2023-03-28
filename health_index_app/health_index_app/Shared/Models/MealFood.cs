using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace health_index_app.Shared.Models
{
    public class MealFood
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public virtual Meal Meal { get; set; }

        [ForeignKey("Id")]
        public virtual Food Food { get; set; }

        [Required]
        [Range(0.0001, Double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public double Amount { get; set; } = 1;
    }
}
