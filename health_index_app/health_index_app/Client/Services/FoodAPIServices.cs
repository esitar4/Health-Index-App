using health_index_app.Shared.FatSecret.ResponseObjects;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Food = health_index_app.Shared.Models.Food;


namespace health_index_app.Client.Services
{
    public interface IFoodAPIServices
    {
        Task<Food> CreateFood(string servingId, GetFoodResponse foodResponse);
        Task<Food> ReadFood(int FoodId);
        Task<bool> UpdateFood(Food Food);
        Task<bool> DeleteFood(Food food);
        Task<Food> CreateFoodHelper(string servingId, GetFoodResponse foodResponse);
    }

    public class FoodAPIServices : IFoodAPIServices
    {
        private readonly HttpClient _client;

        public FoodAPIServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<Food> CreateFood(string servingId, GetFoodResponse foodResponse)
        {
            Food food;
            try
            {
                food = await CreateFoodHelper(servingId, foodResponse);

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


        public async Task<Food> CreateFoodHelper(string servingId, GetFoodResponse foodResponse)
        {
            Food food;
            try
            {
                food = new Food();

                var responseFood = foodResponse.Food;
                var serving = responseFood.Servings.Serving.Where(x => x.Serving_Id == servingId).FirstOrDefault();
                //Add all of the food attributes from responseFood to food

                food.Id = Convert.ToInt32(responseFood.Food_Id);
                food.FoodName = responseFood.Food_Name ??= "";
                food.FoodType = responseFood.Food_Type ??= "";
                food.BrandName = responseFood.Brand_Name ??= "";
                food.FoodURL = responseFood.Food_Url ??= "";

                food.ServingId = Convert.ToInt32(serving.Serving_Id);
                food.ServingURL = responseFood.Food_Url ??= "";
                food.ServingDescription = serving.Serving_Description ??= "";
                food.MetricServingAmount = Convert.ToDouble(serving.Metric_Serving_Amount);
                food.MetricServingUnit = serving.Metric_Serving_Unit ??= "";
                food.MeasurementDescription = serving.Measurement_Description ??= "";

                food.Calories = Convert.ToDouble(serving.Calories);
                food.Calcium = Convert.ToDouble(serving.Calcium);
                food.CarboHydrate = Convert.ToDouble(serving.Carbohydrate);
                food.Cholesterol = Convert.ToDouble(serving.Cholesterol);
                food.Fat = Convert.ToDouble(serving.Fat);
                food.Fiber = Convert.ToDouble(serving.Fiber);
                food.Iron = Convert.ToDouble(serving.Iron);
                food.PolyunsaturatedFat = Convert.ToDouble(serving.Polyunsaturated_Fat);
                food.Potassium = Convert.ToDouble(serving.Potassium);
                food.Protein = Convert.ToDouble(serving.Protein);
                food.SaturatedFat = Convert.ToDouble(serving.Saturated_Fat);
                food.Sodium = Convert.ToDouble(serving.Sodium);
                food.Sugar = Convert.ToDouble(serving.Sugar);
                food.VitaminA = Convert.ToDouble(serving.Vitamin_A);
                food.VitaminC = Convert.ToDouble(serving.Vitamin_C);
                food.VitaminD = Convert.ToDouble(serving.Vitamin_D);
            }
            catch
            {
                throw new Exception("Unable to convert Food");
            }

            return food;
        }
    }
}
