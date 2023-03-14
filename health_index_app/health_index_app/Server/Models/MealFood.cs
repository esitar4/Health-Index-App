using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace health_index_app.Server.Models
{
    public class MealFood
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Meal")]
        public int MealId { get; set; }

        [ForeignKey("Food")]
        public int FoodId { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public double ServingSize { get; set; }
    }
}
