using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_index_app.Shared.DTObjects
{
    public class MealStatsDTO
    {
        public double? TotalCarboHydrate { get; set; } = 0;
        public double? TotalSodium { get; set; } = 0;
        public double? TotalFat { get; set; } = 0;
        public double? TotalSugar { get; set; } = 0;
        public double? TotalCalories { get; set; } = 0;
    }
}
