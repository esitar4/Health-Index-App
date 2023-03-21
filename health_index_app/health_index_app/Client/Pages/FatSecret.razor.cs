using health_index_app.Client.Services;
using health_index_app.Shared.FatSecret;
using health_index_app.Shared.FatSecret.Authentication;
using health_index_app.Shared.FatSecret.Requests;
using health_index_app.Shared.FatSecret.ResponseObjects;
using Microsoft.AspNetCore.Components;

namespace health_index_app.Client.Pages
{
    public partial class FatSecret
    {
        [Inject]FatSecretAPIServices F { get; set; }
        private string SearchExpression = String.Empty;
        //List<SearchedFood>? foods = new();
        FoodsSearchResponse json = null!;
        FatSecretClient client = new FatSecretClient( 
            new FatSecretCredentials
                {
                    ClientKey = "44a3ee4ca84b42ebb3234bc6bf66518c",
                    ClientSecret = "29c8029e8f1b4fdcae11abc7d1babfdd"
                },
                new HttpClient()
            );


        private async Task SearchFood()
        {
            //var foodSearch = await client.FoodsSearchAsync(new FoodsSearchRequest { SearchExpression = "apple", MaxResults = 10 });
            json = await F.FoodsSearchAsync("apple");
        }
    }

}
