using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_index_app.Shared
{
    internal class Meal
    {
        private List<Food> foodItems;
        private double healthIndex;

        public List<Food> FoodItems { get; set; }
        public double HealthIndex { get; set; };

        public Meal(List<Food> foodItems, double healthIndex)
        {
            this.food_items = foodItems;
            this.healthIndex = healthIndex;
        }

        public Meal()
        {

        }
    }
}
