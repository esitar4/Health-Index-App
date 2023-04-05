using NUnit.Framework;
using health_index_app.Client.Services;
using RichardSzalay.MockHttp;
using System;
using System.Threading.Tasks;

namespace Test_health_index_app.Services
{
    [TestFixture]
    internal class ParentAPIServiceTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetChildUserNames_Success()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"[""scott @cognizant.com""]";
            mockHttp.When("https://localhost:7005/api/applicationuser/get-child-usernames")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var parentAPIService = new ParentAPIServices(client);

            //Act
            var result = await parentAPIService.GetChildUsernames();

            //Assert
            Assert.That(result.Count, Is.EqualTo(1));
            
        }

        [Test]
        public async Task GetChildMeals_Success()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"[{""childUsername"":""scott@cognizant.com"",""mealId"":10004,""name"":"""",""healthIndex"":10},{""childUsername"":""scott@cognizant.com"",""mealId"":10005,""name"":"""",""healthIndex"":1},{""childUsername"":""scott@cognizant.com"",""mealId"":10006,""name"":"""",""healthIndex"":6}]";
            mockHttp.When("https://localhost:7005/api/applicationuser/get-child-meals")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var parentAPIService = new ParentAPIServices(client);

            //Act
            var result = await parentAPIService.GetChildMeals();

            //Assert
            Assert.That(result.Count, Is.EqualTo(3));

        }

        [Test]
        public async Task GetChildFoods_Success()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"[{""mealId"":10004,""food"":{""id"":91707,""foodName"":""Stir Fry Vegetables"",""foodType"":""Brand"",""brandName"":""Wylwood"",""foodURL"":""https://www.fatsecret.com/calories-nutrition/wylwood/stir-fry-vegetables"",""servingId"":132185,""servingDescription"":""3/4 cup"",""servingURL"":""https://www.fatsecret.com/calories-nutrition/wylwood/stir-fry-vegetables"",""metricServingAmount"":75,""metricServingUnit"":""g"",""numberOfUnits"":0,""measurementDescription"":""serving"",""calories"":30,""carboHydrate"":6,""protein"":2,""fat"":0,""saturatedFat"":0,""polyunsaturatedFat"":0,""monounsaturatedFat"":null,""cholesterol"":0,""sodium"":15,""potassium"":0,""fiber"":2,""sugar"":3,""addedSugar"":null,""vitaminD"":0,""vitaminA"":0,""vitaminC"":0,""calcium"":0,""iron"":0},""amount"":1},{""mealId"":10004,""food"":{""id"":31818,""foodName"":""Classic Iceberg Salad"",""foodType"":""Brand"",""brandName"":""Dole"",""foodURL"":""https://www.fatsecret.com/calories-nutrition/dole/classic-iceberg-salad"",""servingId"":101820,""servingDescription"":""1 1/2 cups"",""servingURL"":""https://www.fatsecret.com/calories-nutrition/dole/classic-iceberg-salad"",""metricServingAmount"":85,""metricServingUnit"":""g"",""numberOfUnits"":0,""measurementDescription"":""serving"",""calories"":15,""carboHydrate"":4,""protein"":1,""fat"":0,""saturatedFat"":0,""polyunsaturatedFat"":0,""monounsaturatedFat"":null,""cholesterol"":0,""sodium"":15,""potassium"":0,""fiber"":1,""sugar"":2,""addedSugar"":null,""vitaminD"":0,""vitaminA"":0,""vitaminC"":0,""calcium"":0,""iron"":0},""amount"":1},{""mealId"":10004,""food"":{""id"":568586,""foodName"":""Golden Delicious Apples"",""foodType"":""Generic"",""brandName"":"""",""foodURL"":""https://www.fatsecret.com/calories-nutrition/generic/apples-golden-delicious"",""servingId"":591920,""servingDescription"":""1 small (2-1/2\"" dia)"",""servingURL"":""https://www.fatsecret.com/calories-nutrition/generic/apples-golden-delicious"",""metricServingAmount"":106,""metricServingUnit"":""g"",""numberOfUnits"":0,""measurementDescription"":""small  (2-1/2\"" dia)"",""calories"":56,""carboHydrate"":14.64,""protein"":0.27,""fat"":0.18,""saturatedFat"":0.029,""polyunsaturatedFat"":0.055,""monounsaturatedFat"":null,""cholesterol"":0,""sodium"":1,""potassium"":113,""fiber"":2.5,""sugar"":11.01,""addedSugar"":null,""vitaminD"":0,""vitaminA"":3,""vitaminC"":4.8,""calcium"":6,""iron"":0.1},""amount"":1},{""mealId"":10004,""food"":{""id"":9771793,""foodName"":""Naan"",""foodType"":""Brand"",""brandName"":""Suraj"",""foodURL"":""https://www.fatsecret.com/calories-nutrition/suraj/naan"",""servingId"":9336939,""servingDescription"":""1/2 naan"",""servingURL"":""https://www.fatsecret.com/calories-nutrition/suraj/naan"",""metricServingAmount"":50,""metricServingUnit"":""g"",""numberOfUnits"":0,""measurementDescription"":""serving"",""calories"":140,""carboHydrate"":24,""protein"":4,""fat"":3,""saturatedFat"":0.5,""polyunsaturatedFat"":0,""monounsaturatedFat"":null,""cholesterol"":0,""sodium"":320,""potassium"":0,""fiber"":1,""sugar"":2,""addedSugar"":null,""vitaminD"":0,""vitaminA"":0,""vitaminC"":0,""calcium"":0,""iron"":0},""amount"":1}]";
            mockHttp.When("https://localhost:7005//mealfood/get-food-list?mealId=10004")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var parentAPIService = new ParentAPIServices(client);

            //Act
            var result = await parentAPIService.GetChildFoods(10004);

            //Assert
            Assert.That(result.Count, Is.EqualTo(7));

        }


        [Test]
        [TestCase("1234567")]
        [TestCase("7654321")]
        public async Task DeleteChild_Success(string userId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";

            mockHttp.When("https://localhost:7005/api/applicationuser/remove-child-from-user")
                .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005");
            var parentAPIService = new ParentAPIServices(client);

            var result = await parentAPIService.DeleteChild(userId);

            Assert.IsTrue(result);

        }

        [Test]
        [TestCase("1234567")]
        [TestCase("7654321")]
        public async Task AddChild_Success(string userId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";

            mockHttp.When("https://localhost:7005/api/applicationuser/add-child-to-user")
                .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005");
            var parentAPIService = new ParentAPIServices(client);

            var result = await parentAPIService.AddChild(userId);

            Assert.IsTrue(result);

        }
    }
}
