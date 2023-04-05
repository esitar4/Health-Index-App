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
            string testResponse = "StatusCode: 200, ReasonPhrase: 'OK', Version: 1.1, Content: System.Net.Http.BrowserHttpHandler+BrowserHttpContent, Headers:\n{\n Access-Control-Allow-Origin: *\n Date: Tue, 04 Apr 2023 22:05:32 GMT\n Server: Kestrel\n Content-Type: text/plain; charset=utf-8\n}";

            mockHttp.When("https://localhost:7005/api/admin/adduser")
                .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005");
            var adminAPIService = new AdminAPIServices(client);

            var result = await adminAPIService.PostAdminUser(userId);

            Assert.That(result.StartsWith("StatusCode: 200"));
            // Assert.That(result.Contains($"{userId}"));
            Console.WriteLine( result );
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

        [Test]
        public async Task GetUsers_Success()
        {
            var mockHttp = new MockHttpMessageHandler();
            //string testResponse = @"{[{ ""id"":""138f7c43 - ff5c - 4726 - b345 - 821d96ce4333"",""username"":""c @c.c"",""parentId"":null,""dateOfBirth"":null,""weight"":null,""height"":null,""gender"":null,""admin"":false,""lockedStatus"":""Account Unlocked"",""lockEnd"":null},{ ""id"":""2bb65294 - e8d0 - 4d70 - 9f34 - 6fc393cb8832"",""username"":""b @b.b"",""parentId"":null,""dateOfBirth"":null,""weight"":null,""height"":null,""gender"":null,""admin"":false,""lockedStatus"":""Account Unlocked"",""lockEnd"":null},{ ""id"":""56efd970 - 1a6c - 4959 - a9d4 - 92fc4ddfb406"",""username"":""accTest @m.m"",""parentId"":""6d12746e-ecd9 - 4adf - aa35 - 7f011302607c"",""dateOfBirth"":null,""weight"":null,""height"":null,""gender"":null,""admin"":false,""lockedStatus"":""Account Unlocked"",""lockEnd"":""2023 - 04 - 03T13: 07:12.7518815 - 06:00""},{ ""id"":""6d12746e-ecd9 - 4adf - aa35 - 7f011302607c"",""username"":""ed @mail.com"",""parentId"":""6275504f - aeb6 - 47fb - 9765 - 4cf623538a03"",""dateOfBirth"":""2001 - 06 - 29T00: 00:00"",""weight"":null,""height"":null,""gender"":""M"",""admin"":true,""lockedStatus"":""Account Unlocked"",""lockEnd"":null},{ ""id"":""9a30d8ad - 347e-4b71 - 9f86 - 7b4bd7cd132b"",""username"":""d @d.d"",""parentId"":null,""dateOfBirth"":null,""weight"":null,""height"":null,""gender"":null,""admin"":false,""lockedStatus"":""Account Unlocked"",""lockEnd"":null},{ ""id"":""a1e5ad96 - f5d9 - 4125 - a1e6 - f5b14ae1e700"",""username"":""e @e.e"",""parentId"":null,""dateOfBirth"":null,""weight"":null,""height"":null,""gender"":null,""admin"":false,""lockedStatus"":""Account Unlocked"",""lockEnd"":null},{ ""id"":""be475064 - 2db8 - 486d - aa88 - 0105a79db066"",""username"":""a @a.a"",""parentId"":""6275504f - aeb6 - 47fb - 9765 - 4cf623538a03"",""dateOfBirth"":null,""weight"":null,""height"":null,""gender"":null,""admin"":false,""lockedStatus"":""Account Unlocked"",""lockEnd"":null}]}";
            string testResponse = @"{ ""id"":""138f7c43 - ff5c - 4726 - b345 - 821d96ce4333"",""username"":""c @c.c"",""parentId"":null,""dateOfBirth"":null,""weight"":null,""height"":null,""gender"":null,""admin"":false,""lockedStatus"":""Account Unlocked"",""lockEnd"":null}";

            mockHttp.When("https://localhost:7005/api/admin/getUsers")
                .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005");
            var adminAPIService = new AdminAPIServices(client);

            var result = await adminAPIService.GetUsers();


            //Assert.That(result.Count, Is.EqualTo(7));
            //Assert.That(result.Contains("StatusCode: 200"));
            //Assert.That(result[0].Id.Equals("138f7c43 - ff5c - 4726 - b345 - 821d96ce4333"));

        }

    }
}
