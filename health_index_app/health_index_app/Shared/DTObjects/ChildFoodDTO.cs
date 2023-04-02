using health_index_app.Shared.Models;

namespace health_index_app.Shared.DTObjects
{
    public class ChildFoodDTO
    {
        public int MealId { get; set; }
        public Food Food { get; set; }
        public double Amount { get; set; }
    }
}
