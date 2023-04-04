using Microsoft.AspNetCore.Authorization;
using health_index_app.Client.Services;
using Microsoft.AspNetCore.Components;
using health_index_app.Shared;
using health_index_app.Shared.DTObjects;
using System.Net;

namespace health_index_app.Client.Pages
{
    public partial class Admin
    {
        [Inject]
        protected IAdminAPIServices adminApiService { get; set; }
        [Inject]
        protected ToastService ToastService { get; set; } = new();

        private string userIdUnlock = String.Empty;
        private string userIdDelete = String.Empty;
        private string userIdChild = String.Empty;
        private string userIdParent = String.Empty;
        private string userIdRemoveParent = String.Empty;

        private Dictionary<string, string> ids = new Dictionary<string, string>();

        private List<ApplicationUserDTO> users = new();
        List<ApplicationUserDTO> FilteredUsers => (from u in users
                                                    where u.Username.ToLower().Contains(searchStr.ToLower())
                                                    select u).ToList();

        List<ApplicationUserDTO> pageData => FilteredUsers.Page(pageNumber, pageSize).ToList();

        protected override async Task OnInitializedAsync()
        {
            await RefreshList();
        }

        public async Task RefreshList()
        {

            users = await adminApiService.GetUsers();
            foreach (var u in users)
            {
                if (!ids.ContainsKey(u.Id))
                    ids[u.Id] = "";
            }
        }

        private int pageNumber = 1;
        private int pageSize = 5;
        public void GetUpdatedPageNumber(int num)
        {
            pageNumber = num;
        }

        string searchStr = string.Empty;

        public async void PostAdminUser(string userId)
        {
            var res = await adminApiService.PostAdminUser(userId);
            if (res.StartsWith($"StatusCode: 200")) 
                ToastService.ShowToast($"{userId} successfully added to the admin role", ToastLevel.Success, 30000);

            else
                ToastService.ShowToast($"Could not add user {userId} to the admin role", ToastLevel.Error, 30000);
            await RefreshList();
            StateHasChanged();

        }

        public async void RemoveAdminUser(string userId)
        {
            var res = await adminApiService.RemoveAdminUser(userId);
            if (res.StartsWith($"StatusCode: 200"))
                ToastService.ShowToast($"{userId} successfully removed from the admin role", ToastLevel.Success, 30000);

            else
                ToastService.ShowToast($"Could not remove user {userId} from the admin role", ToastLevel.Error, 30000);
            await RefreshList();
            StateHasChanged();
        }

        public async void PostUnlockAccount(string userId)
        {
            var res = await adminApiService.PostUnlockAccount(userId);
            if (res.StartsWith($"StatusCode: 200")) 
                ToastService.ShowToast($"User account {userId} successfully unlocked", ToastLevel.Success, 30000);

            else
                ToastService.ShowToast($"Could not unlock user account {userId}", ToastLevel.Error, 30000);
            await RefreshList();
            StateHasChanged();
        }

        public async void PostLockAccount(string userId)
        {
            var res = await adminApiService.PostLockAccount(userId);
            if (res.StartsWith($"StatusCode: 200"))
                ToastService.ShowToast($"User account {userId} successfully locked", ToastLevel.Success, 30000);

            else
                ToastService.ShowToast($"Could not lock user account {userId}", ToastLevel.Error, 30000);
            await RefreshList();
            StateHasChanged();
        }

        public async void PostDeleteAccount(string userId)
        {
            var res = await adminApiService.PostDeleteAccount(userId);
            if (res.StartsWith($"StatusCode: 200")) 
                ToastService.ShowToast($"User account{userId} successfully deleted", ToastLevel.Success, 30000);

            else
                ToastService.ShowToast($"Could not delted user account {userId}", ToastLevel.Error, 30000);
            await RefreshList();
            StateHasChanged();
        }


        public async void PostAddParentChildRelationship(string userId)
        {
            userIdParent = ids[userId];
            var res = await adminApiService.PostAddParentChildRelationship($"{userId}.{userIdParent}");
            if (res.StartsWith($"StatusCode: 200")) 
                ToastService.ShowToast($"User {userIdParent} successfully added as a parent to user {userId}", ToastLevel.Success, 30000);

            else
                ToastService.ShowToast($"Could not add user {userIdParent} as a parent to user {userId}", ToastLevel.Error, 30000);
            await RefreshList();
            StateHasChanged();
        }

        public async void PostRemoveParentChildRelationship(string userId)
        {
            var res = await adminApiService.PostRemoveParentChildRelationship(userId);
            if (res.StartsWith($"StatusCode: 200")) 
                ToastService.ShowToast($"Removed parent account from user {userId}", ToastLevel.Success, 30000);

            else
                ToastService.ShowToast($"Could not remove the parent account from user {userId}", ToastLevel.Error, 30000);
            await RefreshList();
            StateHasChanged();
        }
    }
}
