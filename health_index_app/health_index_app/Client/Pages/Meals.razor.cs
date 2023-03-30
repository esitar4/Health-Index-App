using health_index_app.Client.Services;
using Food = health_index_app.Shared.Models.Food;
using Meal = health_index_app.Shared.Models.Meal;
using MealFood = health_index_app.Shared.Models.MealFood;
using Microsoft.AspNetCore.Components;
using ResponseFood = health_index_app.Shared.FatSecret.ResponseObjects.SearchedFood;
using health_index_app.Shared.FatSecret.ResponseObjects;
using health_index_app.Shared.Models;

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
        //List<SearchedFood>? foods = new();
        FoodsSearchResponse json = null!;
        GetFoodResponse getFood = null!;

        public MealAPIServices mealAPI { get; set; } = new(new HttpClient());

        private async Task SearchForFood()
        {
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
            Meal meal = await MealAPIServices.CreateMeal(new Meal());

            foreach (var foodResponse in currFoodList)
            {
                var food = await FoodAPIServices.CreateFood(Convert.ToInt32(foodResponse.Food_Id));

                await MealFoodAPIServices.CreateMealFood( new MealFood { MealId = meal.Id, FoodId = food.Id});
            }

            await UserMealsAPIServices.CreateUserMeal(new UserMealDTO { MealId = meal.Id, Name = MealName });
        }

        private async Task Click()
        {
            await MealFoodAPIServices.UpdateMealFood(new MealFood { Id = 18, MealId = 3, FoodId = 1538, Amount = 50 });
        }
    }
}