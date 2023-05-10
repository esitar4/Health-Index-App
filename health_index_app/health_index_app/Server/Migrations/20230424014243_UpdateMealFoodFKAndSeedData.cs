using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace health_index_app.Server.Migrations
{
    public partial class UpdateMealFoodFKAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealFoods_Foods_FoodId",
                table: "MealFoods");

            migrationBuilder.DropIndex(
                name: "IX_MealFoods_FoodId",
                table: "MealFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "245c02db-22a5-4903-b86f-4634ba583d4a", "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9" });

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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "245c02db-22a5-4903-b86f-4634ba583d4a");

            migrationBuilder.AddColumn<int>(
                name: "ServingId",
                table: "MealFoods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                columns: new[] { "Id", "ServingId" });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[] { "adf3001d-64d3-4dfb-b93f-3ad2503167e7", "87babb54-c603-4b8e-a08c-85cde78c78ba", "Admin", "ADMIN" });

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

            //migrationBuilder.InsertData(
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[] { "adf3001d-64d3-4dfb-b93f-3ad2503167e7", "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9" });

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_FoodId_ServingId",
                table: "MealFoods",
                columns: new[] { "FoodId", "ServingId" });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_Id_ServingId",
                table: "Foods",
                columns: new[] { "Id", "ServingId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MealFoods_Foods_FoodId_ServingId",
                table: "MealFoods",
                columns: new[] { "FoodId", "ServingId" },
                principalTable: "Foods",
                principalColumns: new[] { "Id", "ServingId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealFoods_Foods_FoodId_ServingId",
                table: "MealFoods");

            migrationBuilder.DropIndex(
                name: "IX_MealFoods_FoodId_ServingId",
                table: "MealFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_Id_ServingId",
                table: "Foods");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "adf3001d-64d3-4dfb-b93f-3ad2503167e7", "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adf3001d-64d3-4dfb-b93f-3ad2503167e7");

            migrationBuilder.DropColumn(
                name: "ServingId",
                table: "MealFoods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "245c02db-22a5-4903-b86f-4634ba583d4a", "3d5204ed-9ec8-4593-84a7-afc574ca5478", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3aee0927-28c9-4308-92cc-296bf325521b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "546bfbc9-b795-4eea-a491-5d26243bbb41", "AQAAAAEAACcQAAAAEKBHgjxriWTH+qcRtOhCLF1hfqj575KJOlzSRaya4kZ9bEFeMpfaCdvz8B32eqeqSw==", "271571c7-8d74-4ff9-9d09-bfee8f5aaa26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2b23ed-0959-45a4-9499-8b1ee1f0f4d9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e23e26fb-36e9-4d47-9ec2-27158d519689", "AQAAAAEAACcQAAAAEPaLf6F21J0KFizNwaN4hMzUF8M162RWTP7s+hDmuEOlDR/g7pxLwxPnHo7ZhKWY5g==", "8d3dc3c5-82de-41ac-8250-9daa76143f66" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "665938c2-625a-4ac4-ace8-50a9157c019d", "AQAAAAEAACcQAAAAEL1xuSPgyRhYIidxX4TTpKjT/3QO5iK33waBEAuPp4DAXCu4aM50Kfpz77KrHGdbgg==", "b9f7475a-0e31-4fcb-a552-50fcf2381b6a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e32dfe57-4706-43b9-95e4-975119108278", "AQAAAAEAACcQAAAAEG/PRAlkhY7jienfN25eaXQk87NCcdf53xKsg2ytmfvtdMz4omDrUxrpiNHMCT+xsQ==", "d540a2bc-6b1f-4ec2-8c82-4ba6516f846a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ad4faee2-b1ff-4c19-bc85-2400fc2e9787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc95ecd2-357e-43e5-b457-74f8b86c487c", "AQAAAAEAACcQAAAAELMQ9eWT45kLygc+jFW+lo8EwgPUm8PmJblrmtrS9b/AZloSc8W87NETUQ7tkYd0nQ==", "1c14470e-2444-456f-a9e9-76daae7b39c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e03b81e4-c2be-4a64-b26d-0782511cfbc4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c660b8f-cab1-45b2-bb49-d578b788262d", "AQAAAAEAACcQAAAAEFLLB7+9ExWv/sem0DUWU0uizk7KRxCozNNnppvCxSc/RBZzzrQhVsT4NOQRt8wHXg==", "947aad0d-0bc5-4ca7-be09-56584000aada" });

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "245c02db-22a5-4903-b86f-4634ba583d4a", "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9" });

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_FoodId",
                table: "MealFoods",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealFoods_Foods_FoodId",
                table: "MealFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
