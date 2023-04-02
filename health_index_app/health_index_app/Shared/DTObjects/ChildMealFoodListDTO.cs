using health_index_app.Shared.Models;

namespace health_index_app.Shared.DTObjects
{
    public class ChildMealFoodListDTO
    {
        public string ChildName { get; set; }
        public int MealId { get; set; }
        public string MealName { get; set; }
        public double HealthIndex { get; set; }
        public List<ChildFoodDTO> Food { get; set; }
    }
}
