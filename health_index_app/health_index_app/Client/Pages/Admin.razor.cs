using Microsoft.AspNetCore.Authorization;
using health_index_app.Client.Services;
using Microsoft.AspNetCore.Components;
using health_index_app.Shared;
using health_index_app.Shared.DTObjects;

namespace health_index_app.Client.Pages
{
    public partial class Admin
    {
        [Inject]
        protected IAdminAPIServices adminApiService { get; set; }
        private string userIdUnlock = String.Empty;
        private string userIdDelete = String.Empty;
        private string userIdChild = String.Empty;
        private string userIdParent = String.Empty;
        private string userIdRemoveParent = String.Empty;

        private Dictionary<string, string> ids = new Dictionary<string, string>();

        private List<ApplicationUserDTO> users = new();


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

        public async void PostAdminUser(string userId)
        {
            await adminApiService.PostAdminUser(userId);
            await RefreshList();
            StateHasChanged();

        }

        public async void RemoveAdminUser(string userId)
        {
            await adminApiService.RemoveAdminUser(userId);
            await RefreshList();
            StateHasChanged();
        }

        public async void PostUnlockAccount(string userId)
        {
            await adminApiService.PostUnlockAccount(userId);
            await RefreshList();
            StateHasChanged();
        }

        public async void PostLockAccount(string userId)
        {
            await adminApiService.PostLockAccount(userId);
            await RefreshList();
            StateHasChanged();
        }

        public async void PostDeleteAccount(string userId)
        {
            await adminApiService.PostDeleteAccount(userId);
            await RefreshList();
            StateHasChanged();
        }


        public async void PostAddParentChildRelationship(string userId)
        {
            userIdParent = ids[userId];
            await adminApiService.PostAddParentChildRelationship($"{userId}.{userIdParent}");
            await RefreshList();
            StateHasChanged();
        }

        public async void PostRemoveParentChildRelationship(string userId)
        {
            await adminApiService.PostRemoveParentChildRelationship(userId);
            await RefreshList();
            StateHasChanged();
        }

    }
}
