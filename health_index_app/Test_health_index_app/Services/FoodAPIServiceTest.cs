using NUnit.Framework;
using health_index_app.Client.Services;
using RichardSzalay.MockHttp;
using System;
using System.Threading.Tasks;
using health_index_app.Shared.Models;

namespace Test_health_index_app.Services
{
    [TestFixture]
    public class FoodAPIServiceTest
    {
        [Test]
        [TestCase("1234567")]
        [TestCase("7654321")]
        public async Task CreateFood_Success(int foodId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//food/create")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var foodAPIService = new FoodAPIServices(client);

            //Act
            var result = await foodAPIService.CreateFood(foodId);

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task ReadFood_Success(int foodId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//food/read?FoodId=1234")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var foodAPIService = new FoodAPIServices(client);

            //Act
            var result = await foodAPIService.CreateFood(foodId);

            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task UpdateFood_Success(Food food)
        {
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
        public async Task DeleteFood_Success(Food food)
        {
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
