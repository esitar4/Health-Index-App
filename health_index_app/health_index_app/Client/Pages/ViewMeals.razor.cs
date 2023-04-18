using health_index_app.Client.Services;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace health_index_app.Client.Pages
{
    partial class ViewMeals
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        IMealsAPIServices MealAPIService { get; set; }
        
        [Parameter]
        public int MealId { get; set; }

        List<Meal> Meals { get; set; } = new List<Meal>();

        public Meal CurMeal { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            var UserAuth = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.Identity;
            if (UserAuth is not null && UserAuth.IsAuthenticated)
            {
                if (MealId != 0) 
                {
                    CurMeal = await MealAPIService.ReadMeal(MealId);
                }
                
            }
        }

    }
}
