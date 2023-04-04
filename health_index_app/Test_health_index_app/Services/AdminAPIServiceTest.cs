using NUnit.Framework;
using health_index_app.Client.Services;
using RichardSzalay.MockHttp;
using System;
using System.Threading.Tasks;

namespace Test_health_index_app.Services
{
    public class AdminAPIServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task PostAdminUser_AddsUserSuccessfully()
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";
            var userId = "1234567";

            mockHttp.When("https://localhost:7005/api/admin/adduser")
                .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005");
            var adminAPIService = new AdminAPIServices(client);

            var result = await adminAPIService.PostAdminUser(userId);

            Assert.That(result.StartsWith("StatusCode: 200"));
            //Assert.That(result.ToString(), Is.EqualTo($"Successfully added user {userId} to admin role")



        }

    }
}
