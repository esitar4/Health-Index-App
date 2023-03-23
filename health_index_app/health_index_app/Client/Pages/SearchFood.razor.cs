using health_index_app.Client.Services;
using health_index_app.Shared.FatSecret.ResponseObjects;
using Microsoft.AspNetCore.Components;

namespace health_index_app.Client.Pages
{
    public partial class SearchFood
    {
        [Inject]
        protected IFatSecretAPIServices ApiService { get; set; }

        private string SearchExpression = String.Empty;
        //List<SearchedFood>? foods = new();
        FoodsSearchResponse json = null!;

        private async Task SearchForFood()
        {
            //var foodSearch = await client.FoodsSearchAsync(new FoodsSearchRequest { SearchExpression = "apple", MaxResults = 10 });
            json = await ApiService.FoodsSearchAsync(SearchExpression);
        }
    }

}
