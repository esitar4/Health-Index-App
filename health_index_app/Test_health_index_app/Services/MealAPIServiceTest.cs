using NUnit.Framework;
using health_index_app.Client.Services;
using RichardSzalay.MockHttp;
using System;
using System.Threading.Tasks;
using health_index_app.Shared.Models;

namespace Test_health_index_app.Services
{
    [TestFixture]
    public class MealAPIServiceTest
    {
        [Test]
        public async Task CreateMeal_Success()
        {
            Meal meal = new Meal() { 
                Id = 10001,
                HealthIndex = 5
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{""id"":10001,""healthIndex"":0}";
            mockHttp.When("https://localhost:7005/meal/create")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealAPIService = new MealAPIServices(client);

            //Act
            var result = await mealAPIService.CreateMeal(meal);

            //Assert
            Assert.That(result.Id, Is.EqualTo(10001));
        }

        [Test]
        public async Task ReadMeal_Success()
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{""id"":10001,""healthIndex"":0}";
            mockHttp.When("https://localhost:7005/meal/read?mealId=10001")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealAPIService = new MealAPIServices(client);

            //Act
            var result = await mealAPIService.ReadMeal(10001);

            //Assert
            Assert.That(result.Id, Is.EqualTo(10001));
        }

        [Test]
        [TestCase(0000)]
        [TestCase(1000)]
        [TestCase(1001)]
        [TestCase(100 - 001)]
        [TestCase(1234567)]
        [TestCase(7654321)]
        [TestCase(7654321 - 1234567)]
        public async Task UpdateMeal_Success(int id)
        {
            Meal meal = new Meal()
            {
                Id = id,
                HealthIndex = 5
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//meal/update")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealAPIService = new MealAPIServices(client);

            //Act
            var result = await mealAPIService.UpdateMeal(meal);

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
        public async Task DeleteMeal_Success(int id)
        {
            Meal meal = new Meal()
            {
                Id = id,
                HealthIndex = 5
            };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//meal/delete")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealAPIService = new MealAPIServices(client);

            //Act
            var result = await mealAPIService.DeleteMeal(meal);

            //Assert
            Assert.IsTrue(result);
        }
    }
}
