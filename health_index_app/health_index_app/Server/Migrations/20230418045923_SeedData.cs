using System;
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
                values: new object[] { "adf3001d-64d3-4dfb-b93f-3ad2503167e7", "bec5f1b1-3338-46af-8ab3-784d2c36d626", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "Height", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight" },
                values: new object[,]
                {
                    { "3f2b23ed-0959-45a4-9499-8b1ee1f0f4d9", 0, "922a9cdf-a7ab-4f13-98c2-1ad9025610d5", null, "edward@cognizant.com", true, null, null, false, null, "EDWARD@COGNIZANT.COM", "EDWARD@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAENFtJ+Gb0beSEJx8o3oJ59gaTKHXFkEqW0Sefw2wOvyQuil+zi9/DqUFG+Uc+GMTgA==", null, false, "a7d01c79-a89b-4321-b7a9-abd9637e745e", false, "edward@cognizant.com", null },
                    { "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9", 0, "1aa1c5e3-389f-47ab-8147-d13b66db7c93", null, "eric@cognizant.com", true, null, null, false, null, "ERIC@COGNIZANT.COM", "ERIC@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAEPV2YPekwE+lHoVXlxiavgu8tGjXmF0ZIwREM0/QgoJ+/YizpB5/XTShKCAz3fNODA==", null, false, "f49cbc04-3b23-401e-b3fd-368b0e0557a8", false, "eric@cognizant.com", null },
                    { "ad4faee2-b1ff-4c19-bc85-2400fc2e9787", 0, "d45dac2b-8d68-4ba0-b14a-b48f0a43417e", null, "ravid@cognizant.com", true, null, null, false, null, "RAVID@COGNIZANT.COM", "RAVID@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAEH6kqaKe+K3ml2rX70eB20d9YF3vjfObLpQGX9RovshCfOBgR9bT0w/TD6lxKqcwDw==", null, false, "febc06cf-0551-4eda-a2c2-17a5777f3bf2", false, "ravid@cognizant.com", null },
                    { "e03b81e4-c2be-4a64-b26d-0782511cfbc4", 0, "5589dcf6-b510-4f47-a47c-377dfd32573c", null, "jessica@cognizant.com", true, null, null, false, null, "JESSICA@COGNIZANT.COM", "JESSICA@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAEORkn1sU5PmFaRCfYTQ0VC+zNrHT09OD0TYn358pXoONUDqhMyp6yQY/3AVGF4yAMg==", null, false, "5469d0b0-eba5-401f-aced-bd8093886a63", false, "jessica@cognizant.com", null }
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
                values: new object[] { "adf3001d-64d3-4dfb-b93f-3ad2503167e7", "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "Height", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight" },
                values: new object[,]
                {
                    { "3aee0927-28c9-4308-92cc-296bf325521b", 0, "b5c3d6a4-c23f-4f21-82cb-803d3bfb3ba7", null, "charles@cognizant.com", true, null, null, false, null, "CHARLES@COGNIZANT.COM", "CHARLES@COGNIZANT.COM", "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9", "AQAAAAEAACcQAAAAEHrFJG0ScDi8GaB5mm7Y20AaMz1AU8mYMtiVWxjdA53PZYYX8vWMQFrZ8ZFdbhMaiA==", null, false, "8244416d-c9b9-49c8-b60b-7c42be34d6d0", false, "charles@cognizant.com", null },
                    { "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5", 0, "657e6221-d8c7-4323-a379-5866b4889dd4", null, "scott@cognizant.com", true, null, null, false, null, "SCOTT@COGNIZANT.COM", "SCOTT@COGNIZANT.COM", "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9", "AQAAAAEAACcQAAAAENm03/EkSnz+OtVmewU6XlO0Bp8wJxaQT/xsxJtFbDvTxJb3nx+xbdr+r8yiR8/AkA==", null, false, "a3bc775c-097f-45e0-8bd8-85a9bd205546", false, "scott@cognizant.com", null }
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
                    { 2, 10001, "Snack", "3f2b23ed-0959-45a4-9499-8b1ee1f0f4d9" },
                    { 5, 10003, "Truffle Oil", "ad4faee2-b1ff-4c19-bc85-2400fc2e9787" },
                    { 6, 10004, "Feta", "3f2b23ed-0959-45a4-9499-8b1ee1f0f4d9" },
                    { 7, 10002, "Fenugreek", "e03b81e4-c2be-4a64-b26d-0782511cfbc4" }
                });

            migrationBuilder.InsertData(
                table: "UserMeals",
                columns: new[] { "Id", "MealId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, 10004, "Lunch", "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5" },
                    { 3, 10005, "Duck", "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5" },
                    { 4, 10004, "Worcestershire", "3aee0927-28c9-4308-92cc-296bf325521b" },
                    { 8, 10006, "Rocket", "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "MealFoods");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "UserMeals");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Meals");
        }
    }
}
