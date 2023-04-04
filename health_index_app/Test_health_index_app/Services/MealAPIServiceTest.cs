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
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//meal/create")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealAPIService = new MealAPIServices(client);

            //Act
            var result = await mealAPIService.CreateMeal(meal);

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task ReadMeal_Success()
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//meal/read?mealId=1234")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var mealAPIService = new MealAPIServices(client);

            //Act
            var result = await mealAPIService.ReadMeal(1234);

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task UpdateMeal_Success()
        {
            Meal meal = new Meal()
            {
                Id = 10001,
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
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task DeleteMeal_Success()
        {
            Meal meal = new Meal()
            {
                Id = 10001,
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
            Assert.That(result, Is.Not.Null);
        }
    }
}
