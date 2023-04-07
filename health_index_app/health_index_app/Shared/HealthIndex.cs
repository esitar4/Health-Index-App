using health_index_app.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace health_index_app.Shared
{
    public class HealthIndex
    {
        public static double generateHealthIndex(List<Food> meal)
        {
            double healthIndex = 0;
            
            if (meal.Count == 0)
            {
                return healthIndex;
            }

            foreach(Food food in meal)
            {
                double arg = (double)(nullCheck(food.Calories) + nullCheck(food.CarboHydrate) -

                         30 * nullCheck(food.Cholesterol) + 30 * nullCheck(food.Fiber) + 30 * nullCheck(food.Protein)
                         - 30 * nullCheck(food.SaturatedFat) + 10 * nullCheck(food.Sodium) - 30 * nullCheck(food.Sugar)
                         + 30 * (nullCheck(food.VitaminA) + 30 * nullCheck(food.VitaminC) + 30 * nullCheck(food.VitaminD)));
                         
                if (arg <= 0)
                {
                    healthIndex += 0;
                }
                else if (arg > Math.Pow(Math.E, 10))
                {
                    healthIndex += 10;
                }
                else
                {
                    healthIndex += Math.Log(arg);
                }
            }

            return Math.Round(healthIndex/meal.Count, 1);
        }

        public static double? nullCheck(double? value)
        {
            if (value == null)
                return 0;
            else
                return value;
        }
    }
}
