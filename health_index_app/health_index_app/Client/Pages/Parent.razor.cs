using health_index_app.Client.Components;
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
        public List<ChildMealFoodListDTO> mutatedChildMealFoodList { get; set; } =  null!;

        Dictionary<int, bool> isHidden = new();

        private int pageSize = 1;
        private int pageNumber = 1;

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

                    mutatedChildMealFoodList = new(childMealFoodList);

                    isHidden.Add(meal.MealId, true);
                }
            }
        }



        //OnInput real time search
        string searchUsername = string.Empty;
        string searchMealName = string.Empty;
        int searchHealthIndex = 0;


        List<ChildMealFoodListDTO> FilteredChildMealFoodList => mutatedChildMealFoodList
            .Where(
                u => (u.ChildName.ToLower().Contains(searchUsername.ToLower())
                && u.MealName.ToLower().Contains(searchMealName.ToLower()))
                && u.HealthIndex >= searchHealthIndex
            )
            .ToList();
        List<ChildMealFoodListDTO> PagedChildMealFoodList => FilteredChildMealFoodList
            .Page(pageNumber, pageSize)
            .ToList();



        public void GetUpdatedPageNumber(int num)
        {
            pageNumber = num;
        }

        private void Show(int mealId)
        {
            isHidden[mealId] = !isHidden[mealId];
        }



        [Parameter]
        public int AddChildStatus { get; set; }
        [Parameter]
        public int DeleteChildStatus { get; set; }
        private string newChildUserName = string.Empty;

        private async Task AddNewChild()
        {
            ResetStatus();
            if (childUsernames.Contains(newChildUserName)) 
            {
                AddChildStatus = (int) AlertMessage.Unsucessful;
            }
            else
            {
                if (await parentAPIServices.AddChild(newChildUserName))
                {
                    AddChildStatus = (int) AlertMessage.Successful;
                }
                else
                {
                    AddChildStatus = (int) AlertMessage.Unsucessful;
                }
            }
                

            navigationManager.NavigateTo($"refresh/parent/{AddChildStatus}/{DeleteChildStatus}");
        }

        private async Task DeleteChild(string username)
        {
            ResetStatus();
            if(await parentAPIServices.DeleteChild(username))
            {
                DeleteChildStatus = (int) AlertMessage.Successful;
            }
            else
            {
                DeleteChildStatus = (int) AlertMessage.Unsucessful;
            }
            navigationManager.NavigateTo($"refresh/parent/{AddChildStatus}/{DeleteChildStatus}");
        }

        private void ResetStatus()
        {
            AddChildStatus = (int) AlertMessage.None;
            DeleteChildStatus = (int) AlertMessage.None;
        }

        private string _activeSortColumn = "ChildName";
        private void updatedata(TableSortHeaderEventCallBackArgs<ChildMealFoodListDTO> args)
        {
            mutatedChildMealFoodList = args.Data;
            _activeSortColumn = args.ActiveSortColumn;
        }
    }
}
