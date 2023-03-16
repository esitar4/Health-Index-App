using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_index_app.Shared
{
    internal class Meal
    {

        public List<Food> FoodItems { get; set; }
        public double HealthIndex { get; set; }
        public int MealID { get; set; }

        public Meal(List<Food> FoodItems, double HealthIndex, int MealID)
        {
            this.FoodItems = FoodItems;
            this.HealthIndex = HealthIndex;
            this.MealID = MealID;
        }

        public Meal()
        {

        }
    }
}
