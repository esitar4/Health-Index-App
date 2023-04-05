using health_index_app.Client.Services;
using health_index_app.Server.Controllers;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_health_index_app.Controllers
{
    public class AdminControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("1234567")]
        [TestCase("7654321")]
        public async Task AddsUserToAdminSuccessfully(string userId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = $"Successfully added user {userId} to admin role";

            mockHttp.When("https://localhost:7005/api/admin/adduser")
                .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();

            var result = await client.GetStringAsync("https://localhost:7005/api/admin/adduser");

            Assert.That(result.Equals($"Successfully added user {userId} to admin role"));
            Assert.That(result.Contains($"{userId}"));
        }

        [Test]
        [TestCase(null)]
        public async Task AddsUserToAdminUnsuccessfully(string userId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = $"User with the given id was not found";

            mockHttp.When("https://localhost:7005/api/admin/adduser")
                .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();

            var result = await client.GetStringAsync("https://localhost:7005/api/admin/adduser");

            Assert.That(result.Equals($"User with the given id was not found"));
        }
    }
}
