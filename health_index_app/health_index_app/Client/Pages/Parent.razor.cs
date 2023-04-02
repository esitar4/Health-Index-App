using health_index_app.Client.Components;
using health_index_app.Client.Services;
using health_index_app.Shared.DTObjects;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Linq;

namespace health_index_app.Client.Pages
{
    public partial class Parent
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        protected IParentAPIServices parentAPIServices { get; set; }
        [Inject]
        protected NavigationManager navigationManager { get; set; }

        private List<ChildNameDTO> childUsernames = new List<ChildNameDTO>();
        private List<ChildMealFoodListDTO> childMealFoodList = new List<ChildMealFoodListDTO>();

        private  Dictionary<int, bool> isHidden = new();

        protected override async Task OnInitializedAsync()
        {
            var UserAuth = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.Identity;
            if (UserAuth is not null && UserAuth.IsAuthenticated)
            {
                var names = await parentAPIServices.GetChildUsernames();
                childUsernames = names.Select(u => new ChildNameDTO { Name = u }).ToList();

                var childMeals = await parentAPIServices.GetChildMeals();
                foreach (var meal in childMeals)
                {
                    List<ChildFoodDTO> foodList = await parentAPIServices.GetChildFoods(meal.MealId);

                    childMealFoodList = (from u in childUsernames
                             join m in childMeals on u.Name equals m.childUsername
                             select new ChildMealFoodListDTO
                             {
                                 ChildName = u.Name,
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
        private string searchUsername = string.Empty;
        private string searchMealName = string.Empty;
        private int searchHealthIndex = 0;

        private int pageNumber = 1;
        private int pageSize = 1;
        private string _activeSortColumn = "ChildName";
        List<ChildMealFoodListDTO> FilteredChildMealFoodList => childMealFoodList
            .Where(
                u => (u.ChildName.ToLower().Contains(searchUsername.ToLower())
                && u.MealName.ToLower().Contains(searchMealName.ToLower()))
                && u.HealthIndex >= searchHealthIndex
            )
            .ToList();
        List<ChildMealFoodListDTO> PagedChildMealFoodList => FilteredChildMealFoodList
            .Page(pageNumber, pageSize)
            .ToList();

        private void UpdateChildMealFoodListData(TableSortHeaderEventCallBackArgs<ChildMealFoodListDTO> args)
        {
            childMealFoodList = args.Data;
            _activeSortColumn = args.ActiveSortColumn;
        }


        public void GetUpdatedPageNumber(int num)
        {
            pageNumber = num;
        }

        private void Show(int mealId)
        {
            isHidden[mealId] = !isHidden[mealId];
        }



        private string searchUserNameTable = string.Empty;
        private int userTablePageSize = 2;
        private int userTablePageNumber = 1;
        private string _activeSortUserNameTableColumn = "Name";
        List<ChildNameDTO> FilteredChildUserNames => childUsernames
            .Where(
                u => u.Name.ToLower().Contains(searchUserNameTable.ToLower())
            )
            .ToList();
        List<ChildNameDTO> PagedChildUserNames => FilteredChildUserNames
            .Page(userTablePageNumber, userTablePageSize)
            .ToList();

        private void UpdateChildUsernameData(TableSortHeaderEventCallBackArgs<ChildNameDTO> args)
        {
            childUsernames = args.Data;
            _activeSortUserNameTableColumn = args.ActiveSortColumn;
        }
        public void GetUpdatedUserTablePageNumber(int num)
        {
            userTablePageNumber = num;
        }



        [Parameter]
        public int AddChildStatus { get; set; }
        [Parameter]
        public int DeleteChildStatus { get; set; }
        private string newChildUserName = string.Empty;

        private async Task AddNewChild()
        {
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.WriteLine(childUsernames.GetType().Name);
            Console.WriteLine(childUsernames.GetType().FullName);
            foreach(var s in childUsernames.GetType().GetProperties().Select(p => p.Name))
                Console.WriteLine(childUsernames.GetType().GetProperties().Select(p => p.Name));
            Console.WriteLine("\n\n\n\n\n\n\n");
            ResetStatus();
            if (childUsernames.Contains(new ChildNameDTO { Name = newChildUserName })) 
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

    }
}
