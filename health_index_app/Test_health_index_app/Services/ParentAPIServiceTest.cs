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
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005/api/applicationuser/get-child-usernames")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var parentAPIService = new ParentAPIServices(client);

            //Act
            var result = await parentAPIService.GetChildUsernames();

            //Assert
            Assert.That(result.Count, Is.EqualTo(7));
            
        }

        [Test]
        public async Task GetChildMeals_Success()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005/api/applicationuser/get-child-meals")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var parentAPIService = new ParentAPIServices(client);

            //Act
            var result = await parentAPIService.GetChildMeals();

            //Assert
            //Assert.That(result.Count, Is.EqualTo(7));

        }

        [Test]
        public async Task GetChildFoods_Success()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            mockHttp.When("https://localhost:7005//mealfood/get-food-list?mealId=1234")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var parentAPIService = new ParentAPIServices(client);

            //Act
            var result = await parentAPIService.GetChildFoods(1234);

            //Assert
            //Assert.That(result.Count, Is.EqualTo(7));

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
