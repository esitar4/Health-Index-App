using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_index_app.Shared.DTObjects
{
    public class ChildMealDTO
    {
        public string childUsername { get; set; }
        public int MealId { get; set; }
        public string Name { get; set; }
        public double HealthIndex { get; set; }
    }
}
