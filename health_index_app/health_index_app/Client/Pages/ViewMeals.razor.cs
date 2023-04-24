using health_index_app.Client.Services;
using health_index_app.Shared.DTObjects;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;

namespace health_index_app.Client.Pages
{
    partial class ViewMeals
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        IMealAPIServices MealAPIService { get; set; }
        [Inject]
        IUserMealsAPIServices UserMealsAPIService { get; set; }
        [Inject]
        IMealFoodAPIServices MealFoodAPIService { get; set; }
        [Inject]
        IFoodAPIServices FoodAPIService { get; set; }
        [Inject]
        ILocalStorageService LocalStorageService { get; set; }


        [Parameter]
        public int MealId { get; set; }

        List<Meal> Meals { get; set; } = new List<Meal>();
        List<UserMealDTO> UserMeals { get; set; } = new();

        private Dictionary<int, string> activeListItem = new Dictionary<int, string>();

        private Meal CurMeal { get; set; } = null!;
        private UserMealFoodDTO userMealFoodDTO { get; set; } = new();
        private Dictionary<int, object> storage { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            var UserAuth = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.Identity;
            if (UserAuth is not null && UserAuth.IsAuthenticated)
            {
                if (MealId != 0) 
                {
                    CurMeal = await MealAPIService.ReadMeal(MealId);
                }
                
                UserMeals = await UserMealsAPIService.GetAllUserMealIdsToMealNames();
                
                foreach (var meal in UserMeals)
                {
                    activeListItem.Add(meal.MealId, "");
                }
                
            }
        }

        private async Task showMealDetail(int mealId)
        {
            if (CurMeal != null && CurMeal.Id != mealId)
                activeListItem[CurMeal.Id] = "";
            
            activeListItem[mealId] = "active";

            if (await LocalStorageService.ContainKeyAsync(mealId.ToString()))
            {
                userMealFoodDTO = await LocalStorageService.GetItemAsync<UserMealFoodDTO>(mealId.ToString());
                CurMeal = userMealFoodDTO.Meal;
            } 
            else
            {
                CurMeal = await MealAPIService.ReadMeal(mealId);
                userMealFoodDTO.UserMealDTO = await UserMealsAPIService.ReadUserMeal(mealId);
                userMealFoodDTO.Meal = CurMeal;
                userMealFoodDTO.MealFood = await MealFoodAPIService.GetMealFoodList(mealId);
                List<Food> tempFoodList = new List<Food>();
                foreach (var food in userMealFoodDTO.MealFood)
                {
                    tempFoodList.Add(await FoodAPIService.ReadFood(food.FoodId, food.ServingId));
                }
                userMealFoodDTO.Food = tempFoodList;

                await LocalStorageService.SetItemAsync(mealId.ToString(), userMealFoodDTO);
            }

            StateHasChanged();
        }

    }
}
