using NUnit.Framework;
using health_index_app.Client.Services;
using RichardSzalay.MockHttp;
using System;
using System.Threading.Tasks;

namespace Test_health_index_app.Services
{
    public class FatSecretAPIServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestFoodSearchAsync()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{""foods"":
                                        {""food"":[
                                            {""brand_Name"":""Generic"",""food_Description"":""Per 99g - Calories: 51kcal | Fat: 0.17g | Carbs: 13.67g | Protein: 0.26g"",""food_Id"":""568597"",""food_Name"":""Gala Apples"",""food_Type"":""Generic"",""food_Url"":""https://www.fatsecret.com/calories-nutrition/generic/apples-gala""},
                                            {""brand_Name"":""Generic"",""food_Description"":""Per 99g - Calories: 51kcal | Fat: 0.17g | Carbs: 13.67g | Protein: 0.26g"",""food_Id"":""561206"",""food_Name"":""Fuji Apples"",""food_Type"":""Generic"",""food_Url"":""https://www.fatsecret.com/calories-nutrition/generic/apples-fuji""}
                                        ],
                                            ""max_Results"":""2"",
                                            ""page_Number"":""1"",
                                            ""total_Results"":""2004""
                                        },
                                    ""successful"":true,
                                    ""error"":null}";
            mockHttp.When("https://localhost:7005/api/fatsecret/foodsearch?searchExpression=apple")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var fatSecretAPIService = new FatSecretAPIServices(client);

            //Act
            var food = await fatSecretAPIService.FoodsSearchAsync("apple");

            //Assert
            Assert.That(food.Successful, Is.True);
            Assert.That(food.Foods.Food.Count, Is.EqualTo(2));
            Assert.That(food.Foods.Food[0].Food_Name, Is.EqualTo("Gala Apples"));
        }

        [Test]
        public async Task TestFoodGetAsync()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{""food"":
                                        {""food_Id"":""34321"",""food_Name"":""Light Butter (Stick Without Salt)"",""brand_Name"":null,""food_Type"":""Generic"",""food_Url"":""https://www.fatsecret.com/calories-nutrition/usda/light-butter-(stick-without-salt)"",
                                        ""servings"":
                                            {""serving"":[
                                                {""calcium"":""14"",""calories"":""141"",""carbohydrate"":""0"",""cholesterol"":""30"",""fat"":""15.62"",""fiber"":""0"",""iron"":""0.31"",""measurement_Description"":""oz"",""metric_Serving_Amount"":""28.350"",""metric_Serving_Unit"":""g"",""monounsaturated_Fat"":""4.515"",""number_Of_Units"":""1.000"",""polyunsaturated_Fat"":""0.580"",""potassium"":""20"",""protein"":""0.94"",""saturated_Fat"":""9.730"",""serving_Description"":""1 oz"",""serving_Id"":""42294"",""serving_Url"":""https://www.fatsecret.com/calories-nutrition/usda/light-butter-(stick-without-salt)?portionid=42294&portionamount=1.000"",""sodium"":""10"",""sugar"":""0"",""vitamin_A"":""132"",""vitamin_C"":""0.0"",""vitamin_D"":null},
                                                {""calcium"":""48"",""calories"":""499"",""carbohydrate"":""0"",""cholesterol"":""106"",""fat"":""55.10"",""fiber"":""0"",""iron"":""1.09"",""measurement_Description"":""g"",""metric_Serving_Amount"":""100.000"",""metric_Serving_Unit"":""g"",""monounsaturated_Fat"":""15.927"",""number_Of_Units"":""100.000"",""polyunsaturated_Fat"":""2.046"",""potassium"":""71"",""protein"":""3.30"",""saturated_Fat"":""34.321"",""serving_Description"":""100 g"",""serving_Id"":""57052"",""serving_Url"":""https://www.fatsecret.com/calories-nutrition/usda/light-butter-(stick-without-salt)?portionid=57052&portionamount=100.000"",""sodium"":""36"",""sugar"":""0"",""vitamin_A"":""465"",""vitamin_C"":""0"",""vitamin_D"":null}
                                            ]}
                                        },
                                    ""successful"":true,
                                    ""error"":null}";
            mockHttp.When("https://localhost:7005/api/fatsecret/foodget?foodId=34321")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var fatSecretAPIService = new FatSecretAPIServices(client);

            //Act
            var food = await fatSecretAPIService.FoodGetAsync(34321);

            //Assert
            Assert.That(food.Successful, Is.True);
            Assert.That(food.Food.Servings.Serving.Count, Is.EqualTo(2));
            Assert.That(food.Food.Food_Id, Is.EqualTo("34321"));
        }


        [Test]
        public async Task TestFoodSearchAsyncErrorMessage()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{""foods"": null,
                                    ""error"": {
                                        ""code"": ""4"", 
                                        ""message"": ""Invalid signature method: oauth_signature_method 'PLAINTEXT'"" }
                                    }";
            mockHttp.When("https://localhost:7005/api/fatsecret/foodsearch?searchExpression=apple")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var fatSecretAPIService = new FatSecretAPIServices(client);

            //Act
            var food = await fatSecretAPIService.FoodsSearchAsync("apple");

            //Assert
            Assert.That(food.Successful, Is.False);
            Assert.That(food.Error.Code, Is.EqualTo(4));
            Assert.That(food.Error.Message, Does.Contain("Invalid signature method"));
        }

        [Test]
        public async Task TestFoodGetAsyncErrorMessage()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();
            string testResponse = @"{""foods"": null,
                                    ""error"": {
                                        ""code"": ""4"", 
                                        ""message"": ""Invalid signature method: oauth_signature_method 'PLAINTEXT'"" }
                                    }";
            mockHttp.When("https://localhost:7005/api/fatsecret/foodget?foodId=34321")
                    .Respond("application/json", testResponse);

            var client = mockHttp.ToHttpClient();
            client.BaseAddress = new Uri("https://localhost:7005/");
            var fatSecretAPIService = new FatSecretAPIServices(client);

            //Act
            var food = await fatSecretAPIService.FoodGetAsync(34321);

            //Assert
            Assert.That(food.Successful, Is.False);
            Assert.That(food.Error.Code, Is.EqualTo(4));
            Assert.That(food.Error.Message, Does.Contain("Invalid signature method"));
        }
    }
}