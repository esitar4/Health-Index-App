using Microsoft.AspNetCore.Authorization;
using health_index_app.Client.Services;
using Microsoft.AspNetCore.Components;

namespace health_index_app.Client.Pages
{
    public partial class Admin
    {
        [Inject]
        protected IAdminAPIServices adminApiService { get; set; }
        private string userId = String.Empty;

        public async void PostAdminUser()
        {
            await adminApiService.Post(userId);
        }
    }
}
