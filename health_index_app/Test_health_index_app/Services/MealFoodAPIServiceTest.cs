using NUnit.Framework;
using health_index_app.Client.Services;
using RichardSzalay.MockHttp;
using System;
using System.Threading.Tasks;
using health_index_app.Shared.Models;

namespace Test_health_index_app.Services
{
    [TestFixture]
    public class MealFoodAPIServiceTest
    {
        [Test]
        public async Task CreateMealFood_Success()
        {
            MealFood mealFood = new MealFood() {
                Id = 1,
                Meal = new Meal(),
                Food = new Food(),
                Amount = 1.0
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//mealfood/create")
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
        public async Task ReadMealFood_Success(int mealFoodId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//mealfood/read?mealFoodId=1234")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealFoodAPIService = new MealFoodAPIServices(client);

            //Act
            var result = await mealFoodAPIService.ReadMealFood(1234);

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task UpdateMealFood_Success()
        {
            MealFood mealFood = new MealFood()
            {
                Id = 1,
                Meal = new Meal(),
                Food = new Food(),
                Amount = 1.0
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//mealfood/update")
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
        public async Task DeleteMealFood_Success()
        {
            MealFood mealFood = new MealFood()
            {
                Id = 1,
                Meal = new Meal(),
                Food = new Food(),
                Amount = 1.0
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//mealfood/delete")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealFoodAPIService = new MealFoodAPIServices(client);

            //Act
            var result = await mealFoodAPIService.DeleteMealFood(mealFood);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
