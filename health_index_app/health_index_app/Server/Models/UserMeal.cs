using health_index_app.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace health_index_app.Server.Models
{
    public class UserMeal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual ApplicationUser? ApplicationUser { get; set; }

        [ForeignKey("Meal")]
        public int MealId { get; set; }

        public virtual Meal? Meal { get; set; }

        [MaxLength(64, ErrorMessage = "Name length shouldn't be longer than 64 letters")]
        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; } = "";
    }
}
