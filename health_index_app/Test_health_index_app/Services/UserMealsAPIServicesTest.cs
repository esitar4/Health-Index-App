using NUnit.Framework;
using health_index_app.Client.Services;
using RichardSzalay.MockHttp;
using System;
using System.Threading.Tasks;
using health_index_app.Shared.Models;

namespace Test_health_index_app.Services
{
    [TestFixture]
    public class UserMealsAPIServicesTest
    {
        [Test]
        public async Task CreateUserMeal_Success(UserMealDTO userMealDTO)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//usermeal/create")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var userMealsAPIService = new UserMealsAPIServices(client);

            //Act
            var result = await userMealsAPIService.CreateUserMeal(userMealDTO);

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task CreateUserMeal_Success()
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//usermeal/read?mealId=1234")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var userMealsAPIService = new UserMealsAPIServices(client);

            //Act
            var result = await userMealsAPIService.ReadUserMeal(1234);

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task UpdateUserMeal_Success(UserMealDTO userMealDTO)
        {
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
        [TestCase("1234567")]
        [TestCase("7654321")]
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
        [TestCase("1234567")]
        [TestCase("7654321")]
        public async Task GetAllUserMealId_Success()
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//usermeal/get-all-meal-ids")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var userMealsAPIService = new UserMealsAPIServices(client);

            //Act
            var result = await userMealsAPIService.GetAllUserMealId();

            //Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}
