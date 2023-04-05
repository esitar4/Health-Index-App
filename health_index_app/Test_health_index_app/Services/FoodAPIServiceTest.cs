using NUnit.Framework;
using health_index_app.Client.Services;
using RichardSzalay.MockHttp;
using System;
using System.Threading.Tasks;
using health_index_app.Shared.Models;
using Newtonsoft.Json;
using health_index_app.Shared.FatSecret.ResponseObjects;

namespace Test_health_index_app.Services
{
    [TestFixture]
    public class FoodAPIServiceTest
    {
        [SetUp]
        public void Setup()
        {
 
        }
        [Test]
        [TestCase(0000, "284")]
        [TestCase(1000, "284")]
        [TestCase(1001, "284")]
        [TestCase(100 - 001, "284")]
        [TestCase(1234567, "284")]
        [TestCase(7654321, "284")]
        [TestCase(7654321 - 1234567, "284")]
        public async Task CreateFood_Success(int foodId, string servingId)
        {
            var json = @"{
    ""food"": {
        ""food_Id"": ""864"",
        ""food_Name"": ""Lowfat Fruit and Nuts Yogurt"",
        ""brand_Name"": null,
        ""food_Type"": ""Generic"",
        ""food_Url"": ""https://www.fatsecret.com/calories-nutrition/generic/yogurt-fruit-and-nuts-lowfat-milk"",
        ""servings"": {
            ""serving"": [
                {
                    ""calcium"": ""255"",
                    ""calories"": ""202"",
                    ""carbohydrate"": ""32.13"",
                    ""cholesterol"": ""7"",
                    ""fat"": ""5.32"",
                    ""fiber"": ""0.5"",
                    ""iron"": ""0.24"",
                    ""measurement_Description"": ""6 oz container"",
                    ""metric_Serving_Amount"": ""170.000"",
                    ""metric_Serving_Unit"": ""g"",
                    ""monounsaturated_Fat"": ""2.496"",
                    ""number_Of_Units"": ""1.000"",
                    ""polyunsaturated_Fat"": ""1.114"",
                    ""potassium"": ""342"",
                    ""protein"": ""7.67"",
                    ""saturated_Fat"": ""1.454"",
                    ""serving_Description"": ""1 6 oz container"",
                    ""serving_Id"": ""284"",
                    ""serving_Url"": ""https://www.fatsecret.com/calories-nutrition/generic/yogurt-fruit-and-nuts-lowfat-milk?portionid=284&portionamount=1.000"",
                    ""sodium"": ""95"",
                    ""sugar"": ""31.64"",
                    ""vitamin_A"": ""17"",
                    ""vitamin_C"": ""1.2"",
                    ""vitamin_D"": null
                },
                {
                    ""calcium"": ""340"",
                    ""calories"": ""270"",
                    ""carbohydrate"": ""42.90"",
                    ""cholesterol"": ""9"",
                    ""fat"": ""7.10"",
                    ""fiber"": ""0.7"",
                    ""iron"": ""0.32"",
                    ""measurement_Description"": ""8 oz container"",
                    ""metric_Serving_Amount"": ""227.000"",
                    ""metric_Serving_Unit"": ""g"",
                    ""monounsaturated_Fat"": ""3.333"",
                    ""number_Of_Units"": ""1.000"",
                    ""polyunsaturated_Fat"": ""1.487"",
                    ""potassium"": ""456"",
                    ""protein"": ""10.24"",
                    ""saturated_Fat"": ""1.941"",
                    ""serving_Description"": ""1 8 oz container"",
                    ""serving_Id"": ""186"",
                    ""serving_Url"": ""https://www.fatsecret.com/calories-nutrition/generic/yogurt-fruit-and-nuts-lowfat-milk?portionid=186&portionamount=1.000"",
                    ""sodium"": ""127"",
                    ""sugar"": ""42.25"",
                    ""vitamin_A"": ""23"",
                    ""vitamin_C"": ""1.6"",
                    ""vitamin_D"": null
                },
                {
                    ""calcium"": ""368"",
                    ""calories"": ""292"",
                    ""carbohydrate"": ""46.31"",
                    ""cholesterol"": ""10"",
                    ""fat"": ""7.67"",
                    ""fiber"": ""0.7"",
                    ""iron"": ""0.34"",
                    ""measurement_Description"": ""cup"",
                    ""metric_Serving_Amount"": ""245.000"",
                    ""metric_Serving_Unit"": ""g"",
                    ""monounsaturated_Fat"": ""3.597"",
                    ""number_Of_Units"": ""1.000"",
                    ""polyunsaturated_Fat"": ""1.605"",
                    ""potassium"": ""492"",
                    ""protein"": ""11.05"",
                    ""saturated_Fat"": ""2.095"",
                    ""serving_Description"": ""1 cup"",
                    ""serving_Id"": ""187"",
                    ""serving_Url"": ""https://www.fatsecret.com/calories-nutrition/generic/yogurt-fruit-and-nuts-lowfat-milk?portionid=187&portionamount=1.000"",
                    ""sodium"": ""137"",
                    ""sugar"": ""45.59"",
                    ""vitamin_A"": ""25"",
                    ""vitamin_C"": ""1.7"",
                    ""vitamin_D"": null
                },
                {
                    ""calcium"": ""340"",
                    ""calories"": ""270"",
                    ""carbohydrate"": ""42.90"",
                    ""cholesterol"": ""9"",
                    ""fat"": ""7.10"",
                    ""fiber"": ""0.7"",
                    ""iron"": ""0.32"",
                    ""measurement_Description"": ""serving (227g)"",
                    ""metric_Serving_Amount"": ""227.000"",
                    ""metric_Serving_Unit"": ""g"",
                    ""monounsaturated_Fat"": ""3.333"",
                    ""number_Of_Units"": ""1.000"",
                    ""polyunsaturated_Fat"": ""1.487"",
                    ""potassium"": ""456"",
                    ""protein"": ""10.24"",
                    ""saturated_Fat"": ""1.941"",
                    ""serving_Description"": ""1 serving (227 g)"",
                    ""serving_Id"": ""188"",
                    ""serving_Url"": ""https://www.fatsecret.com/calories-nutrition/generic/yogurt-fruit-and-nuts-lowfat-milk?portionid=188&portionamount=1.000"",
                    ""sodium"": ""127"",
                    ""sugar"": ""42.25"",
                    ""vitamin_A"": ""23"",
                    ""vitamin_C"": ""1.6"",
                    ""vitamin_D"": null
                },
                {
                    ""calcium"": ""150"",
                    ""calories"": ""119"",
                    ""carbohydrate"": ""18.90"",
                    ""cholesterol"": ""4"",
                    ""fat"": ""3.13"",
                    ""fiber"": ""0.3"",
                    ""iron"": ""0.14"",
                    ""measurement_Description"": ""g"",
                    ""metric_Serving_Amount"": ""100.000"",
                    ""metric_Serving_Unit"": ""g"",
                    ""monounsaturated_Fat"": ""1.468"",
                    ""number_Of_Units"": ""100.000"",
                    ""polyunsaturated_Fat"": ""0.655"",
                    ""potassium"": ""201"",
                    ""protein"": ""4.51"",
                    ""saturated_Fat"": ""0.855"",
                    ""serving_Description"": ""100 g"",
                    ""serving_Id"": ""49544"",
                    ""serving_Url"": ""https://www.fatsecret.com/calories-nutrition/generic/yogurt-fruit-and-nuts-lowfat-milk?portionid=49544&portionamount=100.000"",
                    ""sodium"": ""56"",
                    ""sugar"": ""18.61"",
                    ""vitamin_A"": ""10"",
                    ""vitamin_C"": ""0.7"",
                    ""vitamin_D"": null
                }
            ]
        }
    },
    ""successful"": true,
    ""error"": null
}";
            GetFoodResponse getFoodResponse = JsonConvert.DeserializeObject<GetFoodResponse>(json);

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = JsonConvert.SerializeObject(json);
            mockHttp.When("https://localhost:7005/food/create")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var foodAPIService = new FoodAPIServices(client);

            //Act
            var result = await foodAPIService.CreateFood(servingId, getFoodResponse);

            //Assert
            Assert.That(result.ServingId, Is.EqualTo(servingId));
        }

        [Test]
        [TestCase(0000)]
        [TestCase(1000)]
        [TestCase(1001)]
        [TestCase(100 - 001)]
        [TestCase(1234567)]
        [TestCase(7654321)]
        [TestCase(7654321 - 1234567)]
        public async Task ReadFood_Success(int foodId)
        {
            health_index_app.Shared.Models.Food food = new health_index_app.Shared.Models.Food()
            {
                Id = foodId,
                FoodName = "Double-Double Burger",
                FoodType = "Brand",
                BrandName = "In-N-Out",
                FoodURL = "https://www.fatsecret.com/calories-nutrition/in-n-out/double-double-burger",
                ServingId = 66486,
                ServingDescription = "1 burger",
                ServingURL = "https://www.fatsecret.com/calories-nutrition/in-n-out/double-double-burger",
                MetricServingAmount = 330,
                MetricServingUnit = "g",
                NumberOfUnits = 0,
                MeasurementDescription = "serving",
                Calories = 670,
                CarboHydrate = 39,
                Protein = 37,
                Fat = 39,
                SaturatedFat = 17,
                PolyunsaturatedFat = 0,
                Cholesterol = 120,
                Sodium = 1520,
                Potassium = 0,
                Fiber = 3,
                Sugar = 10,
                VitaminD = 0,
                VitaminA = 0,
                VitaminC = 0,
                Calcium = 0,
                Iron = 0
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = JsonConvert.SerializeObject(food);
            mockHttp.When($"https://localhost:7005/food/read?FoodId={foodId}")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var foodAPIService = new FoodAPIServices(client);

            //Act
            var result = await foodAPIService.ReadFood(foodId);

            //Assert
            Assert.That(result.Id, Is.EqualTo(foodId));
        }

        [Test]
        [TestCase(0000)]
        [TestCase(1000)]
        [TestCase(1001)]
        [TestCase(100 - 001)]
        [TestCase(1234567)]
        [TestCase(7654321)]
        [TestCase(7654321 - 1234567)]
        public async Task UpdateFood_Success(int foodId)
        {
            health_index_app.Shared.Models.Food food = new health_index_app.Shared.Models.Food()
            {
                Id = foodId,
                FoodName = "Double-Double Burger",
                FoodType = "Brand",
                BrandName = "In-N-Out",
                FoodURL = "https://www.fatsecret.com/calories-nutrition/in-n-out/double-double-burger",
                ServingId = 66486,
                ServingDescription = "1 burger",
                ServingURL = "https://www.fatsecret.com/calories-nutrition/in-n-out/double-double-burger",
                MetricServingAmount = 330,
                MetricServingUnit = "g",
                NumberOfUnits = 0,
                MeasurementDescription = "serving",
                Calories = 670,
                CarboHydrate = 39,
                Protein = 37,
                Fat = 39,
                SaturatedFat = 17,
                PolyunsaturatedFat = 0,
                Cholesterol = 120,
                Sodium = 1520,
                Potassium = 0,
                Fiber = 3,
                Sugar = 10,
                VitaminD = 0,
                VitaminA = 0,
                VitaminC = 0,
                Calcium = 0,
                Iron = 0
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//Food/update")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var foodAPIService = new FoodAPIServices(client);

            //Act
            var result = await foodAPIService.UpdateFood(food);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(0000)]
        [TestCase(1000)]
        [TestCase(1001)]
        [TestCase(100 - 001)]
        [TestCase(1234567)]
        [TestCase(7654321)]
        [TestCase(7654321 - 1234567)]
        public async Task DeleteFood_Success(int foodId)
        {
            health_index_app.Shared.Models.Food food = new health_index_app.Shared.Models.Food()
            {
                Id = foodId,
                FoodName = "Double-Double Burger",
                FoodType = "Brand",
                BrandName = "In-N-Out",
                FoodURL = "https://www.fatsecret.com/calories-nutrition/in-n-out/double-double-burger",
                ServingId = 66486,
                ServingDescription = "1 burger",
                ServingURL = "https://www.fatsecret.com/calories-nutrition/in-n-out/double-double-burger",
                MetricServingAmount = 330,
                MetricServingUnit = "g",
                NumberOfUnits = 0,
                MeasurementDescription = "serving",
                Calories = 670,
                CarboHydrate = 39,
                Protein = 37,
                Fat = 39,
                SaturatedFat = 17,
                PolyunsaturatedFat = 0,
                Cholesterol = 120,
                Sodium = 1520,
                Potassium = 0,
                Fiber = 3,
                Sugar = 10,
                VitaminD = 0,
                VitaminA = 0,
                VitaminC = 0,
                Calcium = 0,
                Iron = 0
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//food/delete")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var foodAPIService = new FoodAPIServices(client);

            //Act
            var result = await foodAPIService.DeleteFood(food);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
