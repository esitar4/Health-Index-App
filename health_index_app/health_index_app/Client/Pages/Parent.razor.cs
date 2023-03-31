using health_index_app.Client.Services;
using health_index_app.Shared.DTObjects;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace health_index_app.Client.Pages
{
    public partial class Parent
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        protected IFoodAPIServices FoodAPIServices { get; set; }
        [Inject]
        protected IMealFoodAPIServices MealFoodAPIServices { get; set; }
        [Inject]
        protected IMealsAPIServices MealAPIServices { get; set; }
        [Inject]
        protected IUserMealsAPIServices UserMealsAPIServices { get; set; }
        protected ParentAPIServices parentAPIServices { get; set; } = new( new HttpClient());

        [Inject]
        protected NavigationManager navigationManager { get; set; }

        List<string> childUsernames = null!;
        List<ChildMealDTO> childMeals = null!;
        Dictionary<int, List<ChildMealFoodDTO>> childMealFoods = new();

        Dictionary<int, bool> isHidden = new();

        string newChildUserName = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            var UserAuth = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.Identity;
            if (UserAuth is not null && UserAuth.IsAuthenticated)
            {
                childUsernames = await parentAPIServices.GetChildUsernames();
                childMeals = await parentAPIServices.GetChildMeals();
                foreach (var meal in childMeals)
                {
                    List<ChildMealFoodDTO> foodList = await parentAPIServices.GetChildFoods(meal.MealId);
                    childMealFoods.Add(meal.MealId, foodList);

                    isHidden.Add(meal.MealId, true);
                }
            }
        }

        private void Show(int mealId)
        {
            isHidden[mealId] = !isHidden[mealId];
        }

        private async Task AddNewChild()
        {
            Console.WriteLine(newChildUserName);
            await parentAPIServices.AddChild(newChildUserName);
            navigationManager.NavigateTo("refresh/parent");
        }

        private async Task DeleteChild(string username)
        {
            Console.WriteLine(username);
            await parentAPIServices.DeleteChild(username);
            navigationManager.NavigateTo("refresh/parent");
        }
    }
}
