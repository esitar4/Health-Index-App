using health_index_app.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;

namespace health_index_app.Client.Pages
{
    partial class AddMeals
    {
        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        protected IFatSecretAPIServices FatSecretAPIServices { get; set; }

        private int y = 0;
        public async Task click()
        {
            var x = await FatSecretAPIServices.FoodGetAsync(y, true);
            Console.WriteLine(x);
        }
    }
}
