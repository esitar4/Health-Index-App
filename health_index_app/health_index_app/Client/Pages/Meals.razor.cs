using health_index_app.Client.Services;
using Food = health_index_app.Shared.Models.Food;
using Meal = health_index_app.Shared.Models.Meal;
using MealFood = health_index_app.Shared.Models.MealFood;
using Microsoft.AspNetCore.Components;
using ResponseSearchFood = health_index_app.Shared.FatSecret.ResponseObjects.SearchedFood;
using ResponseGetFood = health_index_app.Shared.FatSecret.ResponseObjects.GetFoodResponse;
using health_index_app.Shared.DTObjects;
using health_index_app.Shared.FatSecret.ResponseObjects;
using health_index_app.Shared;
using System.Security.Cryptography.X509Certificates;

using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Text;
using health_index_app.Client.Components;

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
        protected IMealAPIServices MealAPIServices { get; set; }
        [Inject]
        protected IUserMealsAPIServices UserMealsAPIServices { get; set; }
        [Inject]
        protected ToastService ToastService { get; set; }


        const int NUMDESC = 7;

        private string SearchExpression = String.Empty;
        private string MealName = "";

        private bool searching = false;

        FoodsSearchResponse json = null!;
        GetFoodResponse getFood = null!;
        double healthIndex = 0;
        
        const string NOMEALNAME = "Meal name is required";
        const string SEARCHERROR = "An error occurred while searching the fatsecret database";

        string[,] SearchTable = new string[10, NUMDESC]; //id, name, serving description, calories
        List<string[]> MealTable = new List<string[]>();
        List<string[]> UserMealTable = new List<string[]>();

        private Dictionary<string, bool> isHidden = new();


        private string color = "#000";
        private bool disableEdit => MealTable.Count > 0 ? true : false;

        private void Show(string mealId)
        {
            if (isHidden.ContainsKey(mealId))
                isHidden[mealId] = !isHidden[mealId];
        }

        List<ResponseGetFood> getFoodResponses = new List<ResponseGetFood>();

        public MealAPIServices mealAPI { get; set; } = new(new HttpClient());

        protected override async void OnInitialized()
        {
            await PopulateUserMeals();
        }

        private async Task SearchForFood()
        {
            json = null;
            searching = true;
            StateHasChanged();

            Array.Clear(SearchTable);
            if (SearchExpression != String.Empty)
            {
                json = await ApiService.FoodsSearchAsync(SearchExpression);
            }
            int i = 0;
            foreach (var food in json.Foods.Food) { UserFoodSearch(i++, food); }
            searching = false;
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
            await GetFood(SearchTable[index, 0]);

            MealTable.Add(new string[NUMDESC]);
            MealTable.Last()[0] = SearchTable[index, 0]; //id
            MealTable.Last()[1] = SearchTable[index, 1]; //name
            MealTable.Last()[2] = SearchTable[index, 2]; //serving size
            MealTable.Last()[3] = SearchTable[index, 3]; //calories count
            MealTable.Last()[4] = SearchTable[index, 4]; //Pretty serving size
            MealTable.Last()[5] = SearchTable[index, 5]??"1"; //amount
            MealTable.Last()[6] = SearchTable[index, 6]??getFood.Food.Servings.Serving[0].Serving_Id; //serving id

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

            GetHealthIndex();
        }

        private async void GetHealthIndex()
        {
            List<Food> foods = new();
            
            foreach (var food in MealTable)
            {
                await GetFood(food[0]);
                foods.Add(await FoodAPIServices.CreateFood(food[6], getFood));
            }

            healthIndex = HealthIndex.generateHealthIndex(foods);
            StateHasChanged();
        }


        private async Task AddUserMealToMealTable(int index)
        {
            MealTable.Clear();

            var userMeal = UserMealTable[index];

            for (int i = 5; i <= userMeal.Length -NUMDESC; i += NUMDESC)
            {
                MealTable.Add(new string[NUMDESC]);
                MealTable.Last()[0] = userMeal[i+0]; //id
                MealTable.Last()[1] = userMeal[i+1]; //name
                MealTable.Last()[2] = userMeal[i+2]; //serving size
                MealTable.Last()[3] = userMeal[i+3]; //calories count
                MealTable.Last()[4] = userMeal[i+4]; //Pretty serving size
                MealTable.Last()[5] = userMeal[i+5]??"1"; //amount
                MealTable.Last()[6] = userMeal[i+6]; //amount
            }

            MealName = userMeal[1];

        }
        private async Task UpdateFoodRow(int index, Serving serving)
        {
            var serving_description = serving.Serving_Description ?? "";

            SearchTable[index, 2] = PrettyServingSize(serving);

            SearchTable[index, 3] = serving.Calories + "kcal";
            SearchTable[index, 6] = serving.Serving_Id??"0";
        }

        private string PrettyServingSize(Serving serving)
        {
            var serving_description = serving.Serving_Description ?? "";

            if (serving.Metric_Serving_Amount == null || serving.Metric_Serving_Amount == "0")
            {
                return serving_description;
            }

            return (!new Regex(@"\d+ (g|oz)|\d+(g|oz)").IsMatch(serving_description) && serving_description != "") || serving.Metric_Serving_Unit == "" ?
                                    serving_description + " (" + (serving.Metric_Serving_Amount).Split('.')[0] + serving.Metric_Serving_Unit + ")" :
                                    serving.Serving_Description ?? "";
        }

        private string PrettyServingSize(Food food)
        {
            var serving_description = food.ServingDescription ?? "";

            return (!new Regex(@"\d+ (g|oz)|\d+(g|oz)").IsMatch(serving_description) && serving_description != "") || food.MetricServingUnit == "" ?
                                    serving_description + " (" + (food.MetricServingAmount.ToString()??"").Split('.')[0] + food.MetricServingUnit + ")" :
                                    food.ServingDescription ?? "";
        }

        private async Task RemoveFoodFromMeal(string foodId)
        {
            MealTable.Remove(MealTable.Where(x => x[0] == foodId).First());
            GetHealthIndex();
        }

        private async Task RemoveFoodFromUserMeals(string mealId, int i)
        {
            UserMealTable.RemoveAt(i);
            isHidden.Remove(mealId);
            await UserMealsAPIServices.DeleteUserMeal(Convert.ToInt32(mealId));
        }

        private async Task PopulateUserMeals()
        {
            List<UserMealDTO> mealIdsToMealNames = await UserMealsAPIServices.GetAllUserMealIdsToMealNames();
            foreach (var userMeal in mealIdsToMealNames)
            {
                var mealId = userMeal.MealId;
                var mealName = userMeal.Name;
                double totalCalories = 0;
                double totalGrams = 0;
                var mealFoods = await MealFoodAPIServices.GetMealFoodList(mealId);

                Dictionary<Food, double> foods = new();
                foreach (var mealFood in mealFoods)
                {
                    var food = await FoodAPIServices.ReadFood(mealFood.FoodId);
                    totalCalories += Convert.ToInt32(food.Calories)*mealFood.Amount;
                    totalGrams += Convert.ToInt32(food.MetricServingAmount)*mealFood.Amount;
                    var foodCount = mealFood.Amount;

                    foods.Add(food, foodCount);
                }
                await AddNewUserMeal(mealId.ToString(), mealName, totalCalories.ToString(), totalGrams.ToString(), foods);

            }
            StateHasChanged();
        }

        private async Task CreateMeal(string mealName)
        {
            if (mealName != "")
            {
                Meal meal = await MealAPIServices.CreateMeal(new Meal() { HealthIndex = healthIndex});

                MealFood mealFood; UserMealDTO userMealDTO;

                double totalCalories = 0; double totalGrams = 0;

                foreach (string[] MealTableFood in MealTable)
                {
                    var foodId = MealTableFood[0];
                    var foodReponse = getFoodResponses.Where(x => x.Food.Food_Id == foodId).FirstOrDefault();

                    double foodAmount = 1;

                    try
                    {
                        foodAmount = Convert.ToDouble(MealTableFood[5]);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(@"The amount given for {0} is not valid, defaulted to 1", MealTableFood[1]);
                    }

                    var food = await FoodAPIServices.CreateFood(MealTableFood[6], foodReponse);

                    totalCalories += Convert.ToInt32(food.Calories)*foodAmount;
                    totalGrams += Convert.ToInt32(food.MetricServingAmount)*foodAmount;

                    mealFood = await MealFoodAPIServices.CreateMealFood(new MealFood { MealId = meal.Id, FoodId = food.Id, Amount = foodAmount });
                }
                userMealDTO = await UserMealsAPIServices.CreateUserMeal(new UserMealDTO() { MealId = meal.Id, Name = MealName != "" ? MealName : "Unnamed Meal" });

                await AddNewUserMeal(meal.Id.ToString(), userMealDTO.Name, totalCalories.ToString(), totalGrams.ToString());

                MealTable.Clear();
                MealName = "";

                healthIndex = 0;
            } else
            {
                ToastService.ShowToast(NOMEALNAME, ToastLevel.Warning, 3000);
            }
        }

        private async Task EditUserMeal(string mealId, int i)
        {
            await AddUserMealToMealTable(i);
            GetHealthIndex();
            await RemoveFoodFromUserMeals(mealId, i);

        }

        private async Task AddNewUserMeal(string mealId, string mealName, string totalCalories, string totalGrams, Dictionary<Food, double> foods = null)
        {
            if (foods == null)
            {
                UserMealTable.Add(new string[5+MealTable.Count()*NUMDESC]);
            }
            else
            {
                UserMealTable.Add(new string[5+foods.Count()*NUMDESC]);
            }

            UserMealTable.Last()[0] = mealId;
            isHidden.Add(UserMealTable.Last()[0], true);

            UserMealTable.Last()[1] = mealName;
            UserMealTable.Last()[2] = totalCalories;
            UserMealTable.Last()[3] = totalGrams;
            UserMealTable.Last()[4] = healthIndex.ToString();

            if (foods == null)
            {
                for (int i = 0; i < MealTable.Count(); i++)
                {
                    UserMealTable.Last()[5+i*NUMDESC] = MealTable[i][0];
                    UserMealTable.Last()[5+i*NUMDESC+1] = MealTable[i][1];
                    UserMealTable.Last()[5+i*NUMDESC+2] = MealTable[i][2];
                    UserMealTable.Last()[5+i*NUMDESC+3] = MealTable[i][3];
                    UserMealTable.Last()[5+i*NUMDESC+4] = MealTable[i][4];
                    UserMealTable.Last()[5+i*NUMDESC+5] = MealTable[i][5];
                    UserMealTable.Last()[5+i*NUMDESC+6] = MealTable[i][6];
                }
            }
            else
            {
                UserMealTable.Last()[4] = HealthIndex.generateHealthIndex(foods.Keys.ToList()).ToString();

                for (int i = 0; i < foods.Count(); i++)
                {
                    var food = foods.ElementAt(i).Key;
                    UserMealTable.Last()[5+i*NUMDESC] = food.Id.ToString(); //id
                    UserMealTable.Last()[5+i*NUMDESC+1] = food.FoodName; //name
                    UserMealTable.Last()[5+i*NUMDESC+2] = food.MetricServingAmount + " " + food.MetricServingUnit; //serving size
                    UserMealTable.Last()[5+i*NUMDESC+3] = food.Calories.ToString(); //calories count
                    UserMealTable.Last()[5+i*NUMDESC+4] = PrettyServingSize(food); //Pretty serving size
                    UserMealTable.Last()[5+i*NUMDESC+5] = foods.ElementAt(i).Value.ToString(); //amount
                    UserMealTable.Last()[5+i*NUMDESC+6] = food.ServingId.ToString(); //serving_id
                }
            }
        }

        private void ClearList()
        {
            MealTable.Clear();
            GetHealthIndex();
        }
    }
}