using health_index_app.Client.Services;
using Food = health_index_app.Shared.Models.Food;
using Meal = health_index_app.Shared.Models.Meal;
using MealFood = health_index_app.Shared.Models.MealFood;
using Microsoft.AspNetCore.Components;
using ResponseSearchFood = health_index_app.Shared.FatSecret.ResponseObjects.SearchedFood;
using ResponseGetFood = health_index_app.Shared.FatSecret.ResponseObjects.GetFoodResponse;
using health_index_app.Shared.FatSecret.ResponseObjects;
using health_index_app.Shared.Models;
using System.Security.Cryptography.X509Certificates;

using System.Text.RegularExpressions;

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
        private string MealName = String.Empty;
        private int currMealId;


        private List<ResponseSearchFood> currFoodList = new List<ResponseSearchFood>();
        //List<SearchedFood>? foods = new();
        FoodsSearchResponse json = null!;
        GetFoodResponse getFood = null!;

        string[,] SearchTable = new string[10,4];
        List<ResponseGetFood> getFoodResponses = new List<ResponseGetFood>();

        string foodId_toUpdate = "";
        string serving_description = "";
        string calorie_count = "";
        
        public MealAPIServices mealAPI { get; set; } = new(new HttpClient());

        private async Task SearchForFood()
        {
            Array.Clear(SearchTable);
            if (SearchExpression != String.Empty)
            {
                json = await ApiService.FoodsSearchAsync(SearchExpression);
            }
        }

        private async Task GetFood(string foodId)
        {
            var food = getFoodResponses.Where(x => x.Food.Food_Id == foodId);
            if (food.Count() == 1)
            {
                getFood = food.FirstOrDefault();
            }
            else
            {
                int parsedFoodId = Convert.ToInt32(foodId);
                getFood = await ApiService.FoodGetAsync(parsedFoodId);
                getFoodResponses.Add(getFood);
            }
        }

        private async Task AddFoodToMeal(ResponseSearchFood food)
        {
            currFoodList.Add(food);
            StateHasChanged();
        }

        private async Task UpdateFoodRow(string new_foodId, Serving serving)
        {
            foodId_toUpdate = new_foodId;

            serving_description = serving.Serving_Description ?? "";

            if (!new Regex(@"\d+ (g|oz)|\d+(g|oz)").IsMatch(serving_description) && serving_description != "")
            {
                serving_description += "(" + serving.Metric_Serving_Amount + serving.Metric_Serving_Unit + ")";
            }
            calorie_count = serving.Calories ?? "";

            StateHasChanged();
        }

        private async Task RemoveFoodFromMeal(ResponseSearchFood food)
        {
            currFoodList.Remove(food);
            StateHasChanged();
        }

        private async Task CreateMeal()
        {
            Meal meal = await MealAPIServices.CreateMeal(new Meal());

            foreach (var foodResponse in currFoodList)
            {
                var food = await FoodAPIServices.CreateFood(Convert.ToInt32(foodResponse.Food_Id));

                await MealFoodAPIServices.CreateMealFood( new MealFood { MealId = meal.Id, FoodId = food.Id});
            }

            await UserMealsAPIServices.CreateUserMeal(new UserMealDTO { MealId = meal.Id, Name = MealName });
        }
    }
}