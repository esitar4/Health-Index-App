using health_index_app.Client.Services;
using health_index_app.Shared.FatSecret.ResponseObjects;

namespace health_index_app.Client.Pages
{
    public partial class FatSecret
    {
        FatSecretAPIServices F { get; set; } = new(new HttpClient());
        private string SearchExpression = String.Empty;
        //List<SearchedFood>? foods = new();
        FoodsSearchResponse json = null!;

        private async Task SearchFood()
        {
            //var foodSearch = await client.FoodsSearchAsync(new FoodsSearchRequest { SearchExpression = "apple", MaxResults = 10 });
            json = await F.FoodsSearchAsync("apple");
        }
    }

}
