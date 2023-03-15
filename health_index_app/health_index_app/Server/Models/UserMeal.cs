using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace health_index_app.Server.Models
{
    public class UserMeal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string Username { get; set; } = null!;

        [ForeignKey("Meals")]
        public int MealId { get; set; }

        [Required]
        public string Name { get; set; } = "";
    }
}
