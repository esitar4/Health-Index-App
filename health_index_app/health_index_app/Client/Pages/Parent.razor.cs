using health_index_app.Client.Services;
using health_index_app.Shared.DTObjects;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace health_index_app.Client.Pages
{
    public partial class Parent
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        protected IUserMealsAPIServices UserMealsAPIServices { get; set; }
        [Inject]
        protected IParentAPIServices parentAPIServices { get; set; }
        [Inject]
        protected NavigationManager navigationManager { get; set; }

        List<string> childUsernames = null!;
        List<ChildMealDTO> childMeals = null!;
        Dictionary<int, List<ChildMealFoodDTO>> childMealFoods = new();

        Dictionary<int, bool> isHidden = new();

        string newChildUserName = string.Empty;

        [Parameter]
        public bool? AddChildStatus { get; set; } = true;
        [Parameter]
        public bool? DeleteChildStatus { get; set; } = true;

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
            ResetStatus();
            AddChildStatus = await parentAPIServices.AddChild(newChildUserName);
            navigationManager.NavigateTo($"refresh/parent/{AddChildStatus}/{DeleteChildStatus}");
        }

        private async Task DeleteChild(string username)
        {
            ResetStatus();
            DeleteChildStatus = await parentAPIServices.DeleteChild(username);
            navigationManager.NavigateTo($"refresh/parent/{AddChildStatus}/{DeleteChildStatus}");
        }

        private void ResetStatus()
        {
            AddChildStatus = true;
            DeleteChildStatus = true;
        }

    }
}
