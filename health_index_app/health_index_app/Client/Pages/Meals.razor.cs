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
using System.Drawing;

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
        private string dropdown_desc = String.Empty;


        private List<int> currFoodIndexList = new List<int>();
        List<Food>? currFoodList = new();
        FoodsSearchResponse json = null!;
        GetFoodResponse getFood = null!;

        string[,] SearchTable = new string[10,6]; //id, name, serving description, calories
        List<string[]> MealTable = new List<string[]>();
        List<ResponseGetFood> getFoodResponses = new List<ResponseGetFood>();
        
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

        private async void UserFoodSearch(int i, ResponseSearchFood food)
        {
            SearchTable[i, 0] = food.Food_Id;
            SearchTable[i, 1] = food.Food_Name;
            SearchTable[i, 2] = food.Food_Description.Split('|')[0].Split('-')[0][4..].Trim(); //Serving size
            SearchTable[i, 3] = food.Food_Description.Split('|')[0].Split(':')[1].Trim(); //calorie count
            SearchTable[i, 4] = food.Food_Description.Split('|')[0].Split('-')[0][4..].Trim();
        }
        
        //Add foods from the search table to the meal table
        private async Task AddFoodToMeal(int index)
        {
            MealTable.Add(new string[6]);
            MealTable.Last()[0] = SearchTable[index, 0];
            MealTable.Last()[1] = SearchTable[index, 1];
            MealTable.Last()[2] = SearchTable[index, 2];
            MealTable.Last()[3] = SearchTable[index, 3];
            MealTable.Last()[4] = SearchTable[index, 4];
            MealTable.Last()[5] = SearchTable[index, 5]??"1";

            double foodAmount;
            try
            {
                Convert.ToDouble(SearchTable[index, 5]);
            }
            catch (FormatException ex)
            {
                MealTable.Last()[5] = "1";
                Console.WriteLine(@"The amount given for {0} is not valid, defaulted to 1", MealTable.Last()[1]);
            }
        }

        private async Task UpdateFoodRow(int index, Serving serving)
        {
            var serving_description = serving.Serving_Description ?? "";

            SearchTable[index, 2] = !new Regex(@"\d+ (g|oz)|\d+(g|oz)").IsMatch(serving_description) && serving_description != "" ?
                                    serving_description + " (" + (serving.Metric_Serving_Amount??"").Split('.')[0] + serving.Metric_Serving_Unit + ")" :
                                    serving.Serving_Description ?? "";

            SearchTable[index, 3] = serving.Calories + " kcal";

            StateHasChanged();
        }

        private async Task RemoveFoodFromMeal(string foodId)
        {
            MealTable.Remove(MealTable.Where(x => x[0] == foodId).First());
        }

        private async Task CreateMeal()
        {
            Meal meal = await MealAPIServices.CreateMeal(new Meal());

            foreach (var MealTableFood in MealTable)
            {
                var foodId = MealTableFood[0];
                var foodServing = MealTableFood[4];
                double foodAmount = 1;

                try
                {
                    foodAmount = Convert.ToDouble(MealTableFood[5]);
                } catch(FormatException ex)
                {
                    Console.WriteLine(@"The amount given for {0} is not valid, defaulted to 1", MealTableFood[1]);
                }

                var food = await FoodAPIServices.CreateFood(Convert.ToInt32(foodId));

                await MealFoodAPIServices.CreateMealFood(new MealFood { MealId = meal.Id, FoodId = food.Id, Amount = foodAmount });

            }

            /*foreach (var foodResponse in currFoodList)
            {
                var food = await FoodAPIServices.CreateFood(Convert.ToInt32(foodResponse.Food_Id));

                await MealFoodAPIServices.CreateMealFood( new MealFood { MealId = meal.Id, FoodId = food.Id, Amount = food.MetricServingAmount});
            }*/

            await UserMealsAPIServices.CreateUserMeal(new UserMealDTO { MealId = meal.Id, Name = MealName });
        }
    }
}