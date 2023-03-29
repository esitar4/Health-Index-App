using health_index_app.Client.Services;
using Food = health_index_app.Shared.Models.Food;
using Meal = health_index_app.Shared.Models.Meal;
using MealFood = health_index_app.Shared.Models.MealFood;
using UserMeal = health_index_app.Shared.Models.UserMeal;
using Microsoft.AspNetCore.Components;
using ResponseFood = health_index_app.Shared.FatSecret.ResponseObjects.SearchedFood;
using health_index_app.Shared.FatSecret.ResponseObjects;

namespace health_index_app.Client.Pages
{
    public partial class Meals
    {
        [Inject]
        protected IFatSecretAPIServices ApiService { get; set; }
        [Inject]
        protected IFoodAPIServices FoodAPIServices { get; set; }
        [Inject]
        protected IMealFoodAPIServices MealFoodAPIServices { get; set; }
        [Inject]
        protected IMealsAPIServices MealAPIServices { get; set; }
        [Inject]
        protected IUserMealsAPIServices UserMealsAPIServices { get; set; }

        private string SearchExpression = String.Empty;
        private int currMealId;
        private List<ResponseFood> currFoodList = new List<ResponseFood>();
        private List<UserMeal> currUserMeals = new List<UserMeal>();
        //List<SearchedFood>? foods = new();
        FoodsSearchResponse json = null!;
        GetFoodResponse getFood = null!;

        public MealsAPIServices mealAPI { get; set; } = new(new HttpClient());

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

        private async Task AddFoodToMeal(ResponseFood food)
        {
            currFoodList.Add(food);
            StateHasChanged();
        }

        private async Task RemoveFoodFromMeal(ResponseFood food)
        {
            currFoodList.Remove(food);
            StateHasChanged();
        }

        private async Task CreateMeal()
        {
            string MealName = "example";
            var MealId = await MealAPIServices.createMeal(new Meal());

            foreach (var foodResponse in currFoodList)
            {
                var food = await FoodAPIServices.createFood(Convert.ToInt32(foodResponse.Food_Id));

                await MealFoodAPIServices.createMealFood( new MealFood {MealId = MealId, FoodId = food.Id});
            }

            currUserMeals.Add(await UserMealsAPIServices.createUserMeal(MealId, MealName));
        }
    }
}