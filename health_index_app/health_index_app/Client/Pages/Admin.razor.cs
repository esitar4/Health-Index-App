using Microsoft.AspNetCore.Authorization;
using health_index_app.Client.Services;
using Microsoft.AspNetCore.Components;

namespace health_index_app.Client.Pages
{
    public partial class Admin
    {
        [Inject]
        protected IAdminAPIServices adminApiService { get; set; }
        private string userIdUnlock = String.Empty;
        private string userIdAddAdmin = String.Empty;
        private string userIdDelete = String.Empty;
        private string userIdChild = String.Empty;
        private string userIdParent = String.Empty;
        private string userIdRemoveParent = String.Empty;

        public async void PostAdminUser()
        {
            await adminApiService.PostAdminUser(userIdAddAdmin);
        }

        public async void PostUnlockAccount()
        {
            await adminApiService.PostUnlockAccount(userIdUnlock);
        }

        public async void PostDeleteAccount()
        {
            await adminApiService.PostDeleteAccount(userIdDelete);
        }

        public async void PostAddParentChildRelationship()
        {
            await adminApiService.PostAddParentChildRelationship($"{userIdChild}.{userIdParent}");
        }

        public async void PostRemoveParentChildRelationship()
        {
            await adminApiService.PostRemoveParentChildRelationship(userIdRemoveParent);
        }
    }
}
