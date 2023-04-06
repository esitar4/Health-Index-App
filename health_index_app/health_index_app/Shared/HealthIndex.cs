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
            
            foreach(Food food in meal)
            {
                double arg = (double)(nullCheck(food.Calories) + nullCheck(food.CarboHydrate) -
                    nullCheck(food.Cholesterol) + nullCheck(food.Fiber) + nullCheck(food.Protein)
                    - nullCheck(food.SaturatedFat) + nullCheck(food.Sodium) - nullCheck(food.Sugar)
                    + (nullCheck(food.VitaminA) + nullCheck(food.VitaminC) + nullCheck(food.VitaminD)));

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
