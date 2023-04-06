using NUnit.Framework;
using health_index_app.Client.Services;
using RichardSzalay.MockHttp;
using System;
using System.Threading.Tasks;
using health_index_app.Shared.Models;
using Newtonsoft.Json;

namespace Test_health_index_app.Services
{
    [TestFixture]
    public class MealFoodAPIServiceTest
    {
        [Test]
        [TestCase(0000)]
        [TestCase(1000)]
        [TestCase(1001)]
        [TestCase(100 - 001)]
        [TestCase(1234567)]
        [TestCase(7654321)]
        [TestCase(7654321 - 1234567)]
        public async Task CreateMealFood_Success(int id)
        {
            MealFood mealFood = new MealFood() {
                Id = id,
                Meal = new Meal(),
                Food = new Food(),
                Amount = 1.0
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005/mealfood/create")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealFoodAPIService = new MealFoodAPIServices(client);

            //Act
            var result = await mealFoodAPIService.CreateMealFood(mealFood);

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [TestCase(0000)]
        [TestCase(1000)]
        [TestCase(1001)]
        [TestCase(100 - 001)]
        [TestCase(1234567)]
        [TestCase(7654321)]
        [TestCase(7654321 - 1234567)]
        public async Task ReadMealFood_Success(int id)
        {
            MealFood mealFood = new MealFood()
            {
                Id = id,
                Meal = new Meal(),
                Food = new Food(),
                Amount = 1.0
            };


            var mockHttp = new MockHttpMessageHandler();
            string testResponse = JsonConvert.SerializeObject(mealFood);
            mockHttp.When($"https://localhost:7005/mealfood/read?mealFoodId={id}")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealFoodAPIService = new MealFoodAPIServices(client);

            //Act
            var result = await mealFoodAPIService.ReadMealFood(id);

            //Assert
            Assert.That(result.Id, Is.EqualTo(id));
        }

        [Test]
        [TestCase(0000)]
        [TestCase(1000)]
        [TestCase(1001)]
        [TestCase(100 - 001)]
        [TestCase(1234567)]
        [TestCase(7654321)]
        [TestCase(7654321 - 1234567)]
        public async Task UpdateMealFood_Success(int id)
        {
            MealFood mealFood = new MealFood()
            {
                Id = id,
                Meal = new Meal(),
                Food = new Food(),
                Amount = 1.0
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = "StatusCode: 200, ReasonPhrase: 'OK', Version: 1.1, Content: System.Net.Http.BrowserHttpHandler+BrowserHttpContent, Headers:\n{\n Access-Control-Allow-Origin: *\n Date: Tue, 04 Apr 2023 22:05:32 GMT\n Server: Kestrel\n Content-Type: text/plain; charset=utf-8\n}";

            mockHttp.When("https://localhost:7005/mealfood/update")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealFoodAPIService = new MealFoodAPIServices(client);

            //Act
            var result = await mealFoodAPIService.UpdateMealFood(mealFood);

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
        public async Task UpdateMealFood_Fail(int id)
        {
            MealFood mealFood = new MealFood()
            {
                Id = id,
                Meal = new Meal(),
                Food = new Food(),
                Amount = 1.0
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"false";
            mockHttp.When("https://localhost:7005//mealfood/update")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealFoodAPIService = new MealFoodAPIServices(client);

            //Act
            var result = await mealFoodAPIService.UpdateMealFood(mealFood);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase(0000)]
        [TestCase(1000)]
        [TestCase(1001)]
        [TestCase(100 - 001)]
        [TestCase(1234567)]
        [TestCase(7654321)]
        [TestCase(7654321 - 1234567)]
        public async Task DeleteMealFood_Success(int id)
        {
            MealFood mealFood = new MealFood()
            {
                Id = id,
                Meal = new Meal(),
                Food = new Food(),
                Amount = 1.0
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = "StatusCode: 200, ReasonPhrase: 'OK', Version: 1.1, Content: System.Net.Http.BrowserHttpHandler+BrowserHttpContent, Headers:\n{\n Access-Control-Allow-Origin: *\n Date: Tue, 04 Apr 2023 22:05:32 GMT\n Server: Kestrel\n Content-Type: text/plain; charset=utf-8\n}";
            mockHttp.When("https://localhost:7005/mealfood/delete")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealFoodAPIService = new MealFoodAPIServices(client);

            //Act
            var result = await mealFoodAPIService.DeleteMealFood(mealFood);

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
        public async Task DeleteMealFood_Fail(int id)
        {
            MealFood mealFood = new MealFood()
            {
                Id = id,
                Meal = new Meal(),
                Food = new Food(),
                Amount = 1.0
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"false";
            mockHttp.When("https://localhost:7005//mealfood/delete")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealFoodAPIService = new MealFoodAPIServices(client);

            //Act
            var result = await mealFoodAPIService.DeleteMealFood(mealFood);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
