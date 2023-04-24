using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace health_index_app.Server.Migrations
{
    public partial class UpdateMealFoodSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adf3001d-64d3-4dfb-b93f-3ad2503167e7",
                column: "ConcurrencyStamp",
                value: "b909518e-222c-441e-8ebf-a6c8276a1a4e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3aee0927-28c9-4308-92cc-296bf325521b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "442825d8-4994-4187-b2e4-ada18987881d", "AQAAAAEAACcQAAAAEJkUYO8GC+AahJjLw/XSwb5a8pXmgv6h+GhjiZP81I/4CD6au81LzxzuvHYO5fVv9w==", "9bd46b0d-86c0-499c-a627-918d6d2d7e8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2b23ed-0959-45a4-9499-8b1ee1f0f4d9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62f87937-d0b9-44c4-a19e-bd676babd7eb", "AQAAAAEAACcQAAAAEFO/hcP2aQud2A1an5PKj4xZq+Po9l9J4SsP4+QCjm6qzPPSqWsJHHNE19PFndq7Qg==", "bc5e1d58-a570-4977-86a9-1bbc1feedcfd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abd77adf-4337-45fb-b180-47123278eb4b", "AQAAAAEAACcQAAAAEGxBSGRU4g7Am5iKZSilXt8CcZYYWEK6yKBfLIOEDEAsYVG0qrvv9VUMNer7XAJ7rw==", "69e9df30-4f09-4be7-ae44-89510e905c72" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "426ac449-e79a-4993-9bcb-0271d931f311", "AQAAAAEAACcQAAAAECvLHTRz6+/FeFxIBciOELlA8N7K2Hqu6tbY/wDmGhtCjq+AH1N1R1d0DkhlS5jOVA==", "c635eec3-d72c-4426-939f-554d94be1460" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ad4faee2-b1ff-4c19-bc85-2400fc2e9787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65d52ad1-392f-4a70-8fd4-e0f0faca2679", "AQAAAAEAACcQAAAAEOYR9HSM2ere4661iKtZ6ibWcC/AYaRgp9w1PP2CAVyOMUxKQVBd7Ia11M56d0Jqtg==", "582bee3d-3b4d-4ad1-af98-a8d2141181c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e03b81e4-c2be-4a64-b26d-0782511cfbc4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a000eb8-165c-4342-aea6-2ed4b7ec4c0a", "AQAAAAEAACcQAAAAENy2RQdmnFXTiSHXdoDCITFqhUpjETQXxPOBl41g9tj6GAgw2fDXmezz61xBNXSymw==", "7eedbbc0-bb8a-4003-93b5-83ab4db1d17b" });

            migrationBuilder.InsertData(
                table: "MealFoods",
                columns: new[] { "Id", "Amount", "FoodId", "MealId", "ServingId" },
                values: new object[,]
                {
                    { 1, 1.0, 26547, 10001, 66486 },
                    { 2, 1.0, 31818, 10001, 101820 },
                    { 3, 1.0, 251811, 10001, 289802 },
                    { 4, 1.0, 41321916, 10002, 36059775 },
                    { 5, 2.0, 26547, 10002, 66486 },
                    { 6, 1.0, 91707, 10003, 132185 },
                    { 7, 1.0, 1921249, 10003, 1886238 },
                    { 8, 1.0, 568586, 10003, 591920 },
                    { 9, 1.0, 91707, 10004, 132185 },
                    { 10, 1.0, 31818, 10004, 101820 },
                    { 11, 1.0, 568586, 10004, 591920 },
                    { 12, 1.0, 9771793, 10004, 9336939 },
                    { 13, 10.0, 251811, 10005, 289802 },
                    { 14, 1.0, 2861015, 10005, 2787144 },
                    { 15, 2.0, 91707, 10006, 132185 },
                    { 16, 1.0, 1921249, 10006, 1886238 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adf3001d-64d3-4dfb-b93f-3ad2503167e7",
                column: "ConcurrencyStamp",
                value: "87babb54-c603-4b8e-a08c-85cde78c78ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3aee0927-28c9-4308-92cc-296bf325521b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0bcce475-c117-4132-8c7c-0cb4db578665", "AQAAAAEAACcQAAAAEDbocw9EgX1+DoFcAGFt6ACKmjJXZ0xFYh7nSTqBzDoFJSINA24qlA1xswGb8JFqHQ==", "e0f6fb49-040b-4c08-956e-518f5b37acb4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2b23ed-0959-45a4-9499-8b1ee1f0f4d9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24331fc0-16b4-4646-9c02-489cad2c6865", "AQAAAAEAACcQAAAAEItwzDM/7QIhwLZkuKPHfJGOSLgmbufJqqYilpRcOVHMR388mxXvQgYihQxkwhuTpw==", "a22e43d6-3132-493d-80a1-da95aff84d0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ad151c0-a6e2-4218-b14f-911c9a41d367", "AQAAAAEAACcQAAAAEMSPMfWrbWdpJV6qDypWxt8NLqn1IYuTU1DlX0VV89Ehb2jJ63FtaBHwLnEYq9gbYQ==", "651f8282-bedd-4936-b6c7-8ae6bc5ca090" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "149454b4-2612-4bea-bf88-c61cf145bc8d", "AQAAAAEAACcQAAAAEN56X+Sw/ByTCkcypT8NIDH4TlxK8e9hMaqWiq5T1OrKzb8N3ZY+RIKy7sCLLDP44A==", "d1e80a88-c41a-4e5c-91d2-089ac9bafe30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ad4faee2-b1ff-4c19-bc85-2400fc2e9787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34a6a144-dd4c-461c-b8ab-9c8c8ea770cd", "AQAAAAEAACcQAAAAEIcWBIzr9B9JjCDyrMkw6OwRTXwTJjPRxdfKjz0ywToEC7LmylSjy6Jfq5UvzXsrng==", "d18eb043-0692-4e8c-9608-d117aa3b1bc8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e03b81e4-c2be-4a64-b26d-0782511cfbc4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ac15788-1524-402f-a4ed-2655f57fd1d6", "AQAAAAEAACcQAAAAEKIdBO5nyMvy35w4/n6MIPScPUxm5OevmEr4LDlCpKHRnHC2tqVOSSsFraEDDTnw6Q==", "f760f24b-58af-49ab-a378-fc10cf0606e7" });
        }
    }
}
