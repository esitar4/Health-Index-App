using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace health_index_app.Server.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07cfe6f7-54f1-4c9a-951a-82f88235ccf5", "95b70b77-6408-4563-b60d-3cbb75a36fe8", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "Height", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight" },
                values: new object[,]
                {
                    { "25ab57d4-1ec1-45a4-b479-1b0a05e2483a", 0, "8b535116-2833-40f8-b6ab-f550ffdc6e7d", null, "edward@cognizant.com", true, null, null, false, null, "EDWARD@COGNIZANT.COM", "EDWARD@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAEEbvFC+huQ5A5ubv8cOWLeaOCecNBlkVa8foDd4w5H9LVIH2jXEYaZNzCBz+Z7z4WA==", null, false, "30c900a1-882b-40fd-8793-eca0aadf0bd5", false, "edward@cognizant.com", null },
                    { "3afeb668-c51a-4f4c-91f5-7e4aa9322d01", 0, "51d81afe-bc33-4d1e-ac26-32fa61674acd", null, "ravid@cognizant.com", true, null, null, false, null, "RAVID@COGNIZANT.COM", "RAVID@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAEHcHFZVNhbbm+fm94eQN8T747eYInAVsJxmfPQzvfqwlpvkOrDeEwpckW/4mNAQSPg==", null, false, "bbc8dfe5-4d1f-4e06-b6ea-1010141dbc77", false, "ravid@cognizant.com", null },
                    { "6f1372e5-7f5b-4cac-bf87-408c987cdb0c", 0, "f1127fe9-f808-42d5-b27e-405b747658f3", null, "jessica@cognizant.com", true, null, null, false, null, "JESSICA@COGNIZANT.COM", "JESSICA@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAEJnaQA/SWpVsk1OzV2yqbOt8nVW1y7tenuECbiOC6vdxSOlVdqjU2BC+xUVy4CxcFw==", null, false, "bc2d6712-6356-4b8c-b141-0caf4ed069db", false, "jessica@cognizant.com", null },
                    { "79181ade-a68d-4b30-8ba2-74367631e1f5", 0, "4690c9a0-d9d5-46ad-99da-532aee153cc9", null, "eric@cognizant.com", true, null, null, false, null, "ERIC@COGNIZANT.COM", "ERIC@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAELrGiIIjJ9Q75rpBD8rFwRAZ6shVLE4BHAgaOWkIsglwptk2+vlMyYD1Ar4SEc6sKw==", null, false, "3ed24d85-06ee-4764-8848-adc6cbd61238", false, "eric@cognizant.com", null }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "AddedSugar", "BrandName", "Calcium", "Calories", "CarboHydrate", "Cholesterol", "Fat", "Fiber", "FoodName", "FoodType", "FoodURL", "Iron", "MeasurementDescription", "MetricServingAmount", "MetricServingUnit", "MonounsaturatedFat", "NumberOfUnits", "PolyunsaturatedFat", "Potassium", "Protein", "SaturatedFat", "ServingDescription", "ServingId", "ServingURL", "Sodium", "Sugar", "VitaminA", "VitaminC", "VitaminD" },
                values: new object[,]
                {
                    { 26547, null, "In-N-Out", 0.0, 670.0, 39.0, 120.0, 39.0, 3.0, "Double-Double Burger", "Brand", "https://www.fatsecret.com/calories-nutrition/in-n-out/double-double-burger", 0.0, "serving", 330.0, "g", null, 0.0, 0.0, 0.0, 37.0, 17.0, "1 burger", 66486, "https://www.fatsecret.com/calories-nutrition/in-n-out/double-double-burger", 1520.0, 10.0, 0.0, 0.0, 0.0 },
                    { 31818, null, "Dole", 0.0, 15.0, 4.0, 0.0, 0.0, 1.0, "Classic Iceberg Salad", "Brand", "https://www.fatsecret.com/calories-nutrition/dole/classic-iceberg-salad", 0.0, "serving", 85.0, "g", null, 0.0, 0.0, 0.0, 1.0, 0.0, "1 1/2 cups", 101820, "https://www.fatsecret.com/calories-nutrition/dole/classic-iceberg-salad", 15.0, 2.0, 0.0, 0.0, 0.0 },
                    { 91707, null, "Wylwood", 0.0, 30.0, 6.0, 0.0, 0.0, 2.0, "Stir Fry Vegetables", "Brand", "https://www.fatsecret.com/calories-nutrition/wylwood/stir-fry-vegetables", 0.0, "serving", 75.0, "g", null, 0.0, 0.0, 0.0, 2.0, 0.0, "3/4 cup", 132185, "https://www.fatsecret.com/calories-nutrition/wylwood/stir-fry-vegetables", 15.0, 3.0, 0.0, 0.0, 0.0 },
                    { 251811, null, "Coors", 0.0, 164.0, 13.0, 0.0, 0.0, 0.0, "Blue Moon Beer", "Brand", "https://www.fatsecret.com/calories-nutrition/coors/blue-moon-beer", 0.0, "serving", 12.0, "oz", null, 0.0, 0.0, 0.0, 2.0, 0.0, "1 bottle", 289802, "https://www.fatsecret.com/calories-nutrition/coors/blue-moon-beer", 8.0, 0.0, 0.0, 0.0, 0.0 },
                    { 568586, null, "", 6.0, 56.0, 14.640000000000001, 0.0, 0.17999999999999999, 2.5, "Golden Delicious Apples", "Generic", "https://www.fatsecret.com/calories-nutrition/generic/apples-golden-delicious", 0.10000000000000001, "small  (2-1/2\" dia)", 106.0, "g", null, 0.0, 0.055, 113.0, 0.27000000000000002, 0.029000000000000001, "1 small (2-1/2\" dia)", 591920, "https://www.fatsecret.com/calories-nutrition/generic/apples-golden-delicious", 1.0, 11.01, 3.0, 4.7999999999999998, 0.0 },
                    { 1921249, null, "Assi", 0.0, 123.0, 15.0, 0.0, 3.1000000000000001, 5.0, "Curry", "Brand", "https://www.fatsecret.com/calories-nutrition/assi/curry", 0.0, "serving", 180.0, "g", null, 0.0, 0.0, 0.0, 3.0, 2.0, "1 serving", 1886238, "https://www.fatsecret.com/calories-nutrition/assi/curry", 802.0, 6.0, 0.0, 0.0, 0.0 },
                    { 2861015, null, "Annie Chun's", 0.0, 280.0, 59.0, 0.0, 1.0, 3.0, "Vietnamese Pho", "Brand", "https://www.fatsecret.com/calories-nutrition/annie-chuns/vietnamese-pho", 0.0, "serving", 170.0, "g", null, 0.0, 1.0, 0.0, 10.0, 0.0, "1 bowl", 2787144, "https://www.fatsecret.com/calories-nutrition/annie-chuns/vietnamese-pho", 1030.0, 4.0, 0.0, 0.0, 0.0 },
                    { 9771793, null, "Suraj", 0.0, 140.0, 24.0, 0.0, 3.0, 1.0, "Naan", "Brand", "https://www.fatsecret.com/calories-nutrition/suraj/naan", 0.0, "serving", 50.0, "g", null, 0.0, 0.0, 0.0, 4.0, 0.5, "1/2 naan", 9336939, "https://www.fatsecret.com/calories-nutrition/suraj/naan", 320.0, 2.0, 0.0, 0.0, 0.0 },
                    { 41321916, null, "Nong Shim", 20.0, 450.0, 64.0, 5.0, 18.0, 5.0, "Tonkotsu Ramen", "Brand", "https://www.fatsecret.com/calories-nutrition/nong-shim/tonkotsu-ramen", 2.2000000000000002, "serving", 101.0, "g", null, 0.0, 3.0, 380.0, 8.0, 7.0, "1 container", 36059775, "https://www.fatsecret.com/calories-nutrition/nong-shim/tonkotsu-ramen", 1550.0, 5.0, 0.0, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "HealthIndex" },
                values: new object[,]
                {
                    { 10001, 5.0 },
                    { 10002, 3.0 },
                    { 10003, 7.0 },
                    { 10004, 10.0 },
                    { 10005, 1.0 },
                    { 10006, 6.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "07cfe6f7-54f1-4c9a-951a-82f88235ccf5", "79181ade-a68d-4b30-8ba2-74367631e1f5" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "Height", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight" },
                values: new object[,]
                {
                    { "c148fe3a-8c82-48e2-a3bf-9bf3708d1f2a", 0, "4822c0bc-d85a-4f1e-844b-5e3962e03129", null, "charles@cognizant.com", true, null, null, false, null, "CHARLES@COGNIZANT.COM", "CHARLES@COGNIZANT.COM", "79181ade-a68d-4b30-8ba2-74367631e1f5", "AQAAAAEAACcQAAAAEEMT5fDhgHfoOgacOEm3iIaI6QWJVD10C0c2ek0zDbFQ2OLd2P+1LbSPq6f9VVOogA==", null, false, "1815f6ab-7bbb-4de2-b3b3-e0f035ff1324", false, "charles@cognizant.com", null },
                    { "ee505841-aec9-41c3-90ce-ead4fc82818f", 0, "0a94233c-bf71-422e-8f58-a0da85575772", null, "scott@cognizant.com", true, null, null, false, null, "SCOTT@COGNIZANT.COM", "SCOTT@COGNIZANT.COM", "79181ade-a68d-4b30-8ba2-74367631e1f5", "AQAAAAEAACcQAAAAENBNluBubPzBAL+wcdMwRsfQfrInT/8OAJKApOYuzcrHci8aH+jXl17h4ulEA6+0lQ==", null, false, "53404c29-aff6-4950-8b6a-df941b501ff3", false, "scott@cognizant.com", null }
                });

            migrationBuilder.InsertData(
                table: "MealFoods",
                columns: new[] { "Id", "Amount", "FoodId", "MealId" },
                values: new object[,]
                {
                    { 1, 1.0, 26547, 10001 },
                    { 2, 1.0, 31818, 10001 },
                    { 3, 1.0, 251811, 10001 },
                    { 4, 1.0, 41321916, 10002 },
                    { 5, 2.0, 26547, 10002 },
                    { 6, 1.0, 91707, 10003 },
                    { 7, 1.0, 1921249, 10003 },
                    { 8, 1.0, 568586, 10003 },
                    { 9, 1.0, 91707, 10004 },
                    { 10, 1.0, 31818, 10004 },
                    { 11, 1.0, 568586, 10004 },
                    { 12, 1.0, 9771793, 10004 },
                    { 13, 10.0, 251811, 10005 },
                    { 14, 1.0, 2861015, 10005 },
                    { 15, 2.0, 91707, 10006 },
                    { 16, 1.0, 1921249, 10006 }
                });

            migrationBuilder.InsertData(
                table: "UserMeals",
                columns: new[] { "Id", "MealId", "Name", "UserId" },
                values: new object[,]
                {
                    { 2, 10001, "Snack", "25ab57d4-1ec1-45a4-b479-1b0a05e2483a" },
                    { 5, 10003, "Truffle Oil", "3afeb668-c51a-4f4c-91f5-7e4aa9322d01" },
                    { 6, 10004, "Feta", "25ab57d4-1ec1-45a4-b479-1b0a05e2483a" },
                    { 7, 10002, "Fenugreek", "6f1372e5-7f5b-4cac-bf87-408c987cdb0c" }
                });

            migrationBuilder.InsertData(
                table: "UserMeals",
                columns: new[] { "Id", "MealId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, 10004, "Lunch", "ee505841-aec9-41c3-90ce-ead4fc82818f" },
                    { 3, 10005, "Duck", "ee505841-aec9-41c3-90ce-ead4fc82818f" },
                    { 4, 10004, "Worcestershire", "c148fe3a-8c82-48e2-a3bf-9bf3708d1f2a" },
                    { 8, 10006, "Rocket", "ee505841-aec9-41c3-90ce-ead4fc82818f" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "07cfe6f7-54f1-4c9a-951a-82f88235ccf5", "79181ade-a68d-4b30-8ba2-74367631e1f5" });

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MealFoods",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07cfe6f7-54f1-4c9a-951a-82f88235ccf5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "25ab57d4-1ec1-45a4-b479-1b0a05e2483a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3afeb668-c51a-4f4c-91f5-7e4aa9322d01");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f1372e5-7f5b-4cac-bf87-408c987cdb0c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c148fe3a-8c82-48e2-a3bf-9bf3708d1f2a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ee505841-aec9-41c3-90ce-ead4fc82818f");

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 26547);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 31818);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 91707);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 251811);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 568586);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 1921249);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 2861015);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 9771793);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "Id",
                keyValue: 41321916);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 10001);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 10002);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 10003);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 10004);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 10005);

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: 10006);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79181ade-a68d-4b30-8ba2-74367631e1f5");
        }
    }
}
