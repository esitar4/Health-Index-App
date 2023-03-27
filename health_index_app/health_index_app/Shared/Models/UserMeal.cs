using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace health_index_app.Shared.Models
{
    public class UserMeal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; } = null!;

        [ForeignKey("Meals")]
        public int MealId { get; set; }

        [MaxLength(15,ErrorMessage = "Name length shouldn't be longer than 15 letters")]
        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; } = "";
    }
}
