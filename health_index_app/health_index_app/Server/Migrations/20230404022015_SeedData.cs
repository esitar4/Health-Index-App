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
                values: new object[] { "cd7e9f2f-d755-43a5-93e4-b0e3f3311a58", "a7595f36-599d-4a90-81b5-61129c4f4881", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "Height", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight" },
                values: new object[,]
                {
                    { "5820a983-c7b4-4153-9a97-950714bb5a8f", 0, "e0161783-ff1e-41f4-8f2a-a5f4448f42a1", null, "edward@cognizant.com", true, null, null, false, null, "EDWARD@COGNIZANT.COM", "EDWARD@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAEGPJtFICCGlIEecxFEuUsz+7g7OZegKm1YWwEeGDJdGPLPt93QZA+YCiqvNgK1LCNQ==", null, false, "a1b0ccd9-e4cf-4b7a-8b2d-d70fbe27c82a", false, "edward@cognizant.com", null },
                    { "6d4f586b-3e43-4655-a23d-70f120eeee08", 0, "6869cd0c-f8eb-4d1d-935b-47acd18bde8b", null, "jessica@cognizant.com", true, null, null, false, null, "JESSICA@COGNIZANT.COM", "JESSICA@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAEM5ZDClicA78jWWG8P2ZE/Lr34xKzEBU4NFuRQNgSgi6D4C2FgeiLm2qveOgyWmuxg==", null, false, "93b17f53-9b7c-4ca4-bfa0-9c8dd18a6426", false, "jessica@cognizant.com", null },
                    { "877dffea-9501-4237-b437-b95dea46a2a5", 0, "25b17198-35b6-4c03-a42b-b7b6bae50499", null, "ravid@cognizant.com", true, null, null, false, null, "RAVID@COGNIZANT.COM", "RAVID@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAEFJxNshchHiaXBIdqwGI2o/Sf9H5bENe7Md6eN7XhW4qsnlcsTSAyvLpI9vWc4ML9Q==", null, false, "f0b78aad-f961-43ef-8fd0-ba9f2cf2c973", false, "ravid@cognizant.com", null },
                    { "a142f5eb-7cd1-4c7e-849c-95f2c73d9f09", 0, "1d3ac3da-5209-477d-8893-b4685f633c09", null, "admin@cognizant.com", true, null, null, false, null, "ADMIN@COGNIZANT.COM", "ADMIN@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAENdy0nPca/D0Orw4Du4NjyrSjn8emaJxWhIF+awOctDpoa+nYq+CC1A8h9Hkc+VUwQ==", null, false, "777bc1b9-ef89-404c-899e-3ea5e5e9ce35", false, "admin@cognizant.com", null },
                    { "fa1b4867-9195-4bdc-8286-da2b47df22ed", 0, "6c507d56-d637-46ab-8910-8cb2b33142db", null, "charles@cognizant.com", true, null, null, false, null, "CHARLES@COGNIZANT.COM", "CHARLES@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAEADaw36vj4suVZQ3kpA41WBKed9yC08HtAZC6z87tYqCqePrx5HJYMlmCR95tla3RQ==", null, false, "0343ad73-4d8d-42cc-8b8e-d13ee030ada7", false, "charles@cognizant.com", null }
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
                values: new object[] { "cd7e9f2f-d755-43a5-93e4-b0e3f3311a58", "a142f5eb-7cd1-4c7e-849c-95f2c73d9f09" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "Height", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight" },
                values: new object[] { "5a4458e5-6edb-4879-8d71-4077669149d9", 0, "41d3ef90-4c4c-487b-8865-e08994ac7353", null, "scott@cognizant.com", true, null, null, false, null, "SCOTT@COGNIZANT.COM", "SCOTT@COGNIZANT.COM", "a142f5eb-7cd1-4c7e-849c-95f2c73d9f09", "AQAAAAEAACcQAAAAEDOlW+z6QZl7rQ8lECxM7XQPLFcpjncdIoGqOytOkL/JmQSH4aQNavyeyatxl3V3JA==", null, false, "1699900b-410d-41d2-a242-e3df0a8f1f10", false, "scott@cognizant.com", null });

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
                    { 2, 10001, "", "5820a983-c7b4-4153-9a97-950714bb5a8f" },
                    { 4, 10004, "", "fa1b4867-9195-4bdc-8286-da2b47df22ed" },
                    { 5, 10003, "", "877dffea-9501-4237-b437-b95dea46a2a5" },
                    { 6, 10004, "", "5820a983-c7b4-4153-9a97-950714bb5a8f" },
                    { 7, 10002, "", "6d4f586b-3e43-4655-a23d-70f120eeee08" }
                });

            migrationBuilder.InsertData(
                table: "UserMeals",
                columns: new[] { "Id", "MealId", "Name", "UserId" },
                values: new object[] { 1, 10004, "", "5a4458e5-6edb-4879-8d71-4077669149d9" });

            migrationBuilder.InsertData(
                table: "UserMeals",
                columns: new[] { "Id", "MealId", "Name", "UserId" },
                values: new object[] { 3, 10005, "", "5a4458e5-6edb-4879-8d71-4077669149d9" });

            migrationBuilder.InsertData(
                table: "UserMeals",
                columns: new[] { "Id", "MealId", "Name", "UserId" },
                values: new object[] { 8, 10006, "", "5a4458e5-6edb-4879-8d71-4077669149d9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cd7e9f2f-d755-43a5-93e4-b0e3f3311a58", "a142f5eb-7cd1-4c7e-849c-95f2c73d9f09" });

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
                keyValue: "cd7e9f2f-d755-43a5-93e4-b0e3f3311a58");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5820a983-c7b4-4153-9a97-950714bb5a8f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a4458e5-6edb-4879-8d71-4077669149d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d4f586b-3e43-4655-a23d-70f120eeee08");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "877dffea-9501-4237-b437-b95dea46a2a5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fa1b4867-9195-4bdc-8286-da2b47df22ed");

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
                keyValue: "a142f5eb-7cd1-4c7e-849c-95f2c73d9f09");
        }
    }
}
