using System.Net.Http.Json;

using Food = health_index_app.Shared.Models.Food;


namespace health_index_app.Client.Services
{
    public interface IFoodAPIServices
    {
        Task<Food> CreateFood(int foodId);
        Task<Food> ReadFood(int FoodId);
        Task<bool> UpdateFood(Food Food);
        Task<bool> DeleteFood(Food food);
        Task<Food> CreateFoodHelper(int foodId);
    }

    public class FoodAPIServices : IFoodAPIServices
    {
        private readonly HttpClient _client;
        private readonly IFatSecretAPIServices _fatSecretAPIServices;

        public FoodAPIServices(HttpClient client, IFatSecretAPIServices fatSecretAPIServices)
        {
            _client = client;
            _fatSecretAPIServices = fatSecretAPIServices;
        }

        public async Task<Food> CreateFood(int foodId)
        {
            Food food;
            try
            {
                food = await CreateFoodHelper(foodId);

                var response = await _client.PostAsJsonAsync("food/create", food);

                food = await response.Content.ReadFromJsonAsync<Food>();
            }
            catch
            {
                throw new Exception("Unable to create Food");
            }
            return food;
        }

        public async Task<Food> ReadFood(int FoodId)
        {
            Food response;
            try
            {
                var url = $"/food/read?FoodId={FoodId}";
                response = await _client.GetFromJsonAsync<Food>(url);
            }
            catch
            {
                throw new Exception("Unable to read Food, Food not found");
            }
            return response;
        }

        public async Task<bool> UpdateFood(Food food)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("Food/update", food);
            }
            catch
            {
                throw new Exception("Unable to update Food, Food not found");
            }
            return true;
        }

        public async Task<bool> DeleteFood(Food food)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("food/delete", food);
            }
            catch
            {
                throw new Exception("Unable to delete Food, Food not found");
            }
            return true;
        }


        public async Task<Food> CreateFoodHelper(int foodId)
        {
            Food food;
            try
            {
                food = new Food();

                var response = await _fatSecretAPIServices.FoodGetAsync(foodId);
                var responseFood = response.Food;

                //Add all of the food attributes from responseFood to food

                food.Id = Convert.ToInt32(responseFood.Food_Id);
                food.FoodName = responseFood.Food_Name ??= "";
                food.FoodType = responseFood.Food_Type ??= "";
                food.BrandName = responseFood.Brand_Name ??= "";
                food.FoodURL = responseFood.Food_Url ??= "";

                food.ServingId = Convert.ToInt32(responseFood.Servings.Serving[0].Serving_Id);
                food.ServingURL = responseFood.Food_Url ??= "";
                food.ServingDescription = responseFood.Servings.Serving[0].Serving_Description ??= "";
                food.MetricServingAmount = Convert.ToDouble(responseFood.Servings.Serving[0].Metric_Serving_Amount);
                food.MetricServingUnit = responseFood.Servings.Serving[0].Metric_Serving_Unit ??= "";
                food.MeasurementDescription = responseFood.Servings.Serving[0].Measurement_Description ??= "";

                food.Calories = Convert.ToDouble(responseFood.Servings.Serving[0].Calories);
                food.Calcium = Convert.ToDouble(responseFood.Servings.Serving[0].Calcium);
                food.CarboHydrate = Convert.ToDouble(responseFood.Servings.Serving[0].Carbohydrate);
                food.Cholesterol = Convert.ToDouble(responseFood.Servings.Serving[0].Cholesterol);
                food.Fat = Convert.ToDouble(responseFood.Servings.Serving[0].Fat);
                food.Fiber = Convert.ToDouble(responseFood.Servings.Serving[0].Fiber);
                food.Iron = Convert.ToDouble(responseFood.Servings.Serving[0].Iron);
                food.PolyunsaturatedFat = Convert.ToDouble(responseFood.Servings.Serving[0].Polyunsaturated_Fat);
                food.Potassium = Convert.ToDouble(responseFood.Servings.Serving[0].Potassium);
                food.Protein = Convert.ToDouble(responseFood.Servings.Serving[0].Protein);
                food.SaturatedFat = Convert.ToDouble(responseFood.Servings.Serving[0].Saturated_Fat);
                food.Sodium = Convert.ToDouble(responseFood.Servings.Serving[0].Sodium);
                food.Sugar = Convert.ToDouble(responseFood.Servings.Serving[0].Sugar);
                food.VitaminA = Convert.ToDouble(responseFood.Servings.Serving[0].Vitamin_A);
                food.VitaminC = Convert.ToDouble(responseFood.Servings.Serving[0].Vitamin_C);
                food.VitaminD = Convert.ToDouble(responseFood.Servings.Serving[0].Vitamin_D);
            }
            catch
            {
                throw new Exception("Unable to convert Food");
            }

            return food;
        }
    }
}
