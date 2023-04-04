using NUnit.Framework;
using health_index_app.Client.Services;
using RichardSzalay.MockHttp;
using System;
using System.Threading.Tasks;

namespace Test_health_index_app.Services
{
    [TestFixture]
    public class AdminAPIServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("1234567")]
        [TestCase("7654321")]
        public async Task PostAdminUser_AddsUserSuccessfully(string userId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";

            mockHttp.When("https://localhost:7005/api/admin/adduser")
                .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005");
            var adminAPIService = new AdminAPIServices(client);

            var result = await adminAPIService.PostAdminUser(userId);

            Assert.That(result.StartsWith("StatusCode: 200"));
            //Assert.That(result.ToString(), Is.EqualTo($"Successfully added user {userId} to admin role")
        }


        [Test]
        [TestCase("1234567")]
        [TestCase("7654321")]
        public async Task PostUnlockAccount_Success(string userId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";

            mockHttp.When("https://localhost:7005/api/admin/unlockAccount")
                .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005");
            var adminAPIService = new AdminAPIServices(client);

            var result = await adminAPIService.PostUnlockAccount(userId);
            Assert.That(result.StartsWith("StatusCode: 200"));
        }

        [Test]
        [TestCase("1234567")]
        [TestCase("7654321")]
        public async Task PostLockAccount_Success(string userId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";

            mockHttp.When("https://localhost:7005/api/admin/lockAccount")
                .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005");
            var adminAPIService = new AdminAPIServices(client);

            var result = await adminAPIService.PostLockAccount(userId);

            Assert.That(result.StartsWith("StatusCode: 200"));

        }


        [Test]
        [TestCase("1234567")]
        [TestCase("7654321")]
        public async Task PostDeleteAccount_Success(string userId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";

            mockHttp.When("https://localhost:7005/api/admin/deleteAccount")
                .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005");
            var adminAPIService = new AdminAPIServices(client);

            var result = await adminAPIService.PostDeleteAccount(userId);

            Assert.That(result.StartsWith("StatusCode: 200"));

        }

        [Test]
        [TestCase("1234567", "7654321")]
        [TestCase("987654321", "123456789")]
        public async Task PostAddParentChildRelationship_Success(string childId, string parentId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";

            mockHttp.When("https://localhost:7005/api/admin/addParentChildRelationship")
                .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005");
            var adminAPIService = new AdminAPIServices(client);

            var result = await adminAPIService.PostAddParentChildRelationship($"{childId}.{parentId}");

            Assert.That(result.StartsWith("StatusCode: 200"));

        }

        [Test]
        [TestCase("1234567")]
        [TestCase("7654321")]
        public async Task PostRemoveParentChildRelationship_Success(string userId)
        {
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{ }";

            mockHttp.When("https://localhost:7005/api/admin/removeParentChildRelationship")
                .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005");
            var adminAPIService = new AdminAPIServices(client);

            var result = await adminAPIService.PostRemoveParentChildRelationship(userId);

            Assert.That(result.StartsWith("StatusCode: 200"));

        }

    }
}
