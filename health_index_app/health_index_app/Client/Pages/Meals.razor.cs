using health_index_app.Client.Services;
using health_index_app.Shared.FatSecret.ResponseObjects;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace health_index_app.Client.Pages
{
    public partial class Meals
    {
        [Inject]
        protected IFatSecretAPIServices ApiService { get; set; }


        private string SearchExpression = String.Empty;
        private Meal? currMeal;
        //List<SearchedFood>? foods = new();
        FoodsSearchResponse json = null!;
        GetFoodResponse getFood = null!;

        public MealAPI mealAPI { get; set; } = new(new HttpClient());

        private async Task SearchForFood()
        {
            //var foodSearch = await client.FoodsSearchAsync(new FoodsSearchRequest { SearchExpression = "apple", MaxResults = 10 });
            if (SearchExpression != String.Empty)
            {
                json = await ApiService.FoodsSearchAsync(SearchExpression);
            }
        }

        private async Task GetFood(string foodId)
        {
            int parsedFoodId = Convert.ToInt32(foodId);
            getFood = await ApiService.FoodGetAsync(parsedFoodId);
        }

        private async Task CreateMeal()
        {
            var currMealId = await mealAPI.createMeal();

            currMeal = await mealAPI.readMeal(currMealId);


        }
    }
}