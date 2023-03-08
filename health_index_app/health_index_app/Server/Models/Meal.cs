using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_index_app.Shared
{
    public class Meal
    {
        public List<Food> FoodItems { get; set; }
        public double HealthIndex { get; set; }

    }
}
