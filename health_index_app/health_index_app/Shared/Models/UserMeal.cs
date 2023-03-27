using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace health_index_app.Shared.Models
{
    public class UserMeal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int MealId { get; set; }

        [MaxLength(15,ErrorMessage = "Name length shouldn't be longer than 15 letters")]
        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; } = "";
    }
}
