using health_index_app.Client.Services;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace health_index_app.Client.Pages
{
    partial class ViewMeals
    {
        [Inject]
        IMealsAPIServices MealAPIService { get; set; }
        
        [Parameter]
        public int MealId { get; set; }

        List<Meal> Meals { get; set; } = new List<Meal>();

        public Meal CurMeal { get; set; } = new Meal();


        public async void GetMeal(int mealId)
        {
            if (mealId != 0) {
                CurMeal = await MealAPIService.ReadMeal(mealId);
            }
        }

    }
}
