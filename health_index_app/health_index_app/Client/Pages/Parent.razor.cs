using health_index_app.Client.Components;
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
        protected IParentAPIServices ParentAPIServices { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        private List<ChildNameDTO> childUsernames = new List<ChildNameDTO>();
        private List<ChildMealFoodListDTO> childMealFoodList = new List<ChildMealFoodListDTO>();

        private  Dictionary<string, bool> isHidden = new();

        protected override async Task OnInitializedAsync()
        {
            var UserAuth = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.Identity;
            if (UserAuth is not null && UserAuth.IsAuthenticated)
            {
                await RefreshLists();
            }
        }



        //OnInput real time search
        private string searchUsername = string.Empty;
        private string searchMealName = string.Empty;
        private int searchHealthIndex = 0;

        private int pageNumber = 1;
        private int pageSize = 5;
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

        private void Show(string childNameMealId)
        {
            isHidden[childNameMealId] = !isHidden[childNameMealId];
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




        private string newChildUserName = string.Empty;

        private AlertMessagesDTO Message { get; set; } = new();
        private AlertMessagesDTO addMessage = new AlertMessagesDTO()
        {
            Successful = "User sucessfully added to your child list!",
            Unsucessful = "User was not added to your child list!"
        };
        private AlertMessagesDTO deleteMessage = new AlertMessagesDTO()
        {
            Successful = "User sucessfully deleted from your child list!",
            Unsucessful = "User was not deleted from your child list!"
        };

        private async Task AddNewChild()
        {
            Message = addMessage;
            if ((from u in childUsernames select u.Name).Contains(newChildUserName)) 
            {
                Message.Status = (int) AlertMessage.Unsucessful;
            }
            else
            {
                if (await ParentAPIServices.AddChild(newChildUserName))
                {
                    Message.Status = (int) AlertMessage.Successful;
                    await RefreshLists();
                }
                else
                {
                    Message.Status = (int) AlertMessage.Unsucessful;
                }
            }

            StateHasChanged();

            await Task.Delay(TimeSpan.FromSeconds(3));
            Message.Status = 0;
        }

        private async Task DeleteChild(string username)
        {
            Message = deleteMessage;
            if(await ParentAPIServices.DeleteChild(username))
            {
                List<int> mealIds = childMealFoodList.Where(m => m.ChildName.ToLower() == username.ToLower()).Select(m => m.MealId).ToList();
                foreach (int id in mealIds)
                {
                    isHidden[$"{username}?{id}"] = true;
                }

                Message.Status = (int) AlertMessage.Successful;
                await RefreshLists();
            }
            else
            {
                Message.Status = (int) AlertMessage.Unsucessful;
            }

            StateHasChanged();

            await Task.Delay(TimeSpan.FromSeconds(3));
            Message.Status = 0;
        }

        private async Task RefreshLists()
        {
            var names = await ParentAPIServices.GetChildUsernames();
            childUsernames = names.Select(u => new ChildNameDTO { Name = u }).ToList();

            var childMeals = await ParentAPIServices.GetChildMeals();
            childMealFoodList = (from u in childUsernames
                                 join m in childMeals on u.Name equals m.childUsername
                                 select new ChildMealFoodListDTO
                                     {
                                         ChildName = u.Name,
                                         MealId = m.MealId,
                                         MealName = m.Name,
                                         HealthIndex = m.HealthIndex,
                                         Food = new List<ChildFoodDTO>(),
                                     }
                                 )
                                 .OrderBy(o => o.ChildName)
                                 .ToList();

            foreach (var meal in childMeals)
            {
                List<ChildFoodDTO> foodList = await ParentAPIServices.GetChildFoods(meal.MealId);

                childMealFoodList.Where(c => c.MealId == meal.MealId && c.ChildName == meal.childUsername).FirstOrDefault().Food = foodList;

                if (!isHidden.ContainsKey($"{meal.childUsername}?{meal.MealId}"))
                    isHidden.Add($"{meal.childUsername}?{meal.MealId}", true);
            }

            var c = childMealFoodList;
            var x = 1;
        }
    }
}
