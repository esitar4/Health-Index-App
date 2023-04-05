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
    public class UserMealsAPIServicesTest
    {
        [Test]
        [TestCase(0000)]
        [TestCase(1000)]
        [TestCase(1001)]
        [TestCase(100-001)]
        [TestCase(1234567)]
        [TestCase(7654321)]
        [TestCase(7654321-1234567)]
        public async Task CreateUserMeal_Success(int mealId)
        {
            UserMealDTO userMealDTO = new UserMealDTO { MealId = mealId, Name = "test" };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = JsonConvert.SerializeObject(userMealDTO);
            mockHttp.When($"https://localhost:7005/usermeal/create")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var userMealsAPIService = new UserMealsAPIServices(client);

            //Act
            var result = await userMealsAPIService.CreateUserMeal(userMealDTO);

            //Assert
            Assert.That(result.MealId, Is.EqualTo(mealId));
        }

        [Test]
        [TestCase(0000)]
        [TestCase(1000)]
        [TestCase(1001)]
        [TestCase(100 - 001)]
        [TestCase(1234567)]
        [TestCase(7654321)]
        [TestCase(7654321 - 1234567)]
        public async Task UpdateUserMeal_Success(int mealId)
        {
            UserMealDTO userMealDTO = new UserMealDTO { MealId = mealId, Name = "test" };

            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//usermeal/update")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var userMealsAPIService = new UserMealsAPIServices(client);

            //Act
            var result = await userMealsAPIService.UpdateUserMeal(userMealDTO);

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
        public async Task DeleteUserMeal_Success(int mealId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//usermeal/delete")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var userMealsAPIService = new UserMealsAPIServices(client);

            //Act
            var result = await userMealsAPIService.DeleteUserMeal(mealId);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetAllUserMealId_Success()
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{""mealId"": 1234567}";
            mockHttp.When("https://localhost:7005/usermeal/get-all-meal-ids")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var userMealsAPIService = new UserMealsAPIServices(client);

            //Act
            var result = await userMealsAPIService.GetAllUserMealId();

            //Assert
            Assert.That(result[0], Is.EqualTo(1234567));
        }
    }
}
