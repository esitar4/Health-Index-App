using health_index_app.Shared.Models;
using System.ComponentModel.DataAnnotations;


namespace health_index_app.Shared.DTObjects
{
    public class UserMealDTO
    {
        public int Id { get; set; } = 0;
        public virtual int MealId { get; set; }

        [MaxLength(15, ErrorMessage = "Name length shouldn't be longer than 15 letters")]
        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; } = "";
    }
}