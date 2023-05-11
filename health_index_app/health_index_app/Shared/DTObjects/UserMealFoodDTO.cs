using health_index_app.Shared.Models;

namespace health_index_app.Shared.DTObjects
{
    public class UserMealFoodDTO
    {
        public UserMealDTO UserMealDTO { get; set; }
        public Meal Meal { get; set; }
        public List<MealFood> MealFood { get; set; }
        public List<Food> Food { get; set; }
        public MealStatsDTO MealStats { get; set; }


    }
}
