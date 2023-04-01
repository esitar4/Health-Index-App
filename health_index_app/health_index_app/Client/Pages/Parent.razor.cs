using health_index_app.Client.Services;
using health_index_app.Shared.DTObjects;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Xml.Linq;

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
        List<ChildMealFoodListDTO> childMealFoodList = null!;

        Dictionary<int, bool> isHidden = new();

        protected override async Task OnInitializedAsync()
        {
            var UserAuth = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.Identity;
            if (UserAuth is not null && UserAuth.IsAuthenticated)
            {
                childUsernames = await parentAPIServices.GetChildUsernames();
                var childMeals = await parentAPIServices.GetChildMeals();
                foreach (var meal in childMeals)
                {
                    List<ChildMealFoodDTO> foodList = await parentAPIServices.GetChildFoods(meal.MealId);


                    childMealFoodList = (from u in childUsernames
                             join m in childMeals on u equals m.childUsername
                             select new ChildMealFoodListDTO
                             {
                                 ChildName = u,
                                 MealId = m.MealId,
                                 MealName = m.Name,
                                 HealthIndex = m.HealthIndex,
                                 Food = foodList,
                             }
                             )
                             .OrderBy(o => o.ChildName)
                             .ToList();

                    isHidden.Add(meal.MealId, true);
                }
            }
        }



        //OnInput real time search
        string searchText = string.Empty;
        List<ChildMealFoodListDTO> FilteredChildMealFoodList => childMealFoodList.Where(u => u.ChildName.ToLower().Contains(searchText.ToLower())).ToList();


        private void Show(int mealId)
        {
            isHidden[mealId] = !isHidden[mealId];
        }



        [Parameter]
        public bool? AddChildStatus { get; set; } = true;
        [Parameter]
        public bool? DeleteChildStatus { get; set; } = true;
        string newChildUserName = string.Empty;

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



        private bool isSortedAscending;
        private string activeSortColumn = "ChildName";
        private void SortTable(string columnName)
        {
            if (columnName != activeSortColumn)
            {
                childMealFoodList = childMealFoodList.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                isSortedAscending = true;
                activeSortColumn = columnName;
            }
            else
            {
                if (isSortedAscending)
                {
                    childMealFoodList = childMealFoodList.OrderByDescending(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                else
                {
                    childMealFoodList = childMealFoodList.OrderBy(x => x.GetType().GetProperty(columnName).GetValue(x, null)).ToList();
                }
                isSortedAscending = !isSortedAscending;
            }
        }

        private string SetSortIcon(string columnName)
        {
            if (activeSortColumn != columnName)
            {
                return "fa-sort";
            }
            if (isSortedAscending)
            {
                return "fa-sort-up";
            }
            else
            {
                return "fa-sort-down";
            }
        }
    }
}
