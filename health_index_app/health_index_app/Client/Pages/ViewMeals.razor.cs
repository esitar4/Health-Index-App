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
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        protected IMealAPIServices MealAPIService { get; set; }
        [Inject]
        protected IUserMealsAPIServices UserMealsAPIService { get; set; }
        [Inject]
        protected IMealFoodAPIServices MealFoodAPIService { get; set; }
        [Inject]
        protected IFoodAPIServices FoodAPIService { get; set; }
        [Inject]
        protected ILocalStorageService LocalStorageService { get; set; }
        [Inject]
        protected ToastService ToastService { get; set; } = new();

        [Parameter]
        public int MealId { get; set; }
        public bool MealIdCheck { get; set; } = true;

        private string searchMealName = string.Empty;
        List<UserMealDTO> UserMeals { get; set; } = new();
        List<UserMealDTO> FilteredUserMeals => UserMeals.Where(um => um.Name.ToLower().Contains(searchMealName.ToLower())).ToList();

        private Dictionary<int, string> activeListItem = new Dictionary<int, string>();
        private string color = "#000";
        private Meal CurMeal { get; set; } = null!;
        private UserMealFoodDTO userMealFoodDTO { get; set; } = new();
        private int numCols = 6;

        private string onClickNav = "#073b4c";
        private string onClickNavIconAnimation = "fa-beat";
        private string onClickHide = "";

        protected override async Task OnInitializedAsync()
        {
            var UserAuth = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.Identity;
            if (UserAuth is not null && UserAuth.IsAuthenticated)
            {
                if (MealId != 0) 
                {
                    userMealFoodDTO.Meal = await MealAPIService.ReadMeal(MealId);
                    onClickNavIconAnimation = "";
                }
                
                UserMeals = await UserMealsAPIService.GetAllUserMealIdsToMealNames();
                
                foreach (var meal in UserMeals)
                {
                    activeListItem.Add(meal.MealId, "");
                }

                if (UserMeals.Where(um => um.MealId == MealId).Any())
                {
                    await showMealDetail(MealId);
                }
                else
                {
                    MealIdCheck = false;
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

        private void OnClickChangeNav()
        {
            onClickNavIconAnimation = "";
            onClickHide = "display:none";
            if (onClickNav == "#078976")
            {
                onClickNav = "#073b4c";
            } 
            else
            {
                onClickNav = "#078976";
            }
        }

        private async Task DeleteMeal(UserMealDTO userMeal)
        {
            bool res = await UserMealsAPIService.DeleteUserMeal(userMeal.MealId);
            UserMeals = await UserMealsAPIService.GetAllUserMealIdsToMealNames();
            await LocalStorageService.RemoveItemAsync(userMeal.MealId.ToString());

            

            if (res)
            {
                ToastService.ShowToast($"{userMeal.Name} was successfully deleted!", ToastLevel.Success, 3000);
                userMealFoodDTO.Meal = null!;
            }
            else
            {
                ToastService.ShowToast($"{userMeal.Name} deleted unsuccessfully!", ToastLevel.Error, 3000);
            }

            StateHasChanged();
        }

    }
}
