using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace health_index_app.Server.Migrations
{
    public partial class AddUniqueConstraintUMMF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserMeals_UserId",
                table: "UserMeals");

            migrationBuilder.DropIndex(
                name: "IX_MealFoods_MealId",
                table: "MealFoods");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adf3001d-64d3-4dfb-b93f-3ad2503167e7",
                column: "ConcurrencyStamp",
                value: "cd4de5d1-e104-4121-83a4-5ffe4c2ca2af");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3aee0927-28c9-4308-92cc-296bf325521b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "23e6bd11-9fb6-47ae-9ff4-ba9de4d9542b", "AQAAAAEAACcQAAAAEEDUG3GprCyg+FQihHjj+j/Pb+NuLuuvAYm9ImV9v+149clj1PZhKHzp7+Zhhc0vXg==", "6624f992-f118-48ea-92fe-cccfc512d2d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2b23ed-0959-45a4-9499-8b1ee1f0f4d9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3162b90f-ccb8-453c-9a92-d8a2bc2409d7", "AQAAAAEAACcQAAAAEEN6iSCMQd39yGcQtCvHoqY0Kzo6O/9COImcua69U9fFsnQCMj2p9q6JutiFQ9FIfg==", "d54000f7-9541-4bab-b495-a4c0bc954927" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef3cc75c-6f8a-4393-af33-c67c107204d3", "AQAAAAEAACcQAAAAEC249MqpifcJYiiF84bS3tD8hVE+vxDdSfVfCOc2rgcXr/B1QG227cKNBVZzdrdr7g==", "0e5a9c02-a3f1-4ab7-a52d-19a9ddc40984" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98a78878-aca7-4a0f-b264-02a678d2ea06", "AQAAAAEAACcQAAAAEFMcywwRSlLKzIhCxSMtYEfuiWh9CM6/fper56YAC+ohFdHO7UL64CFoJfLw77KfQg==", "3ce14e7d-9491-4a7e-ba32-9a9fae5e0a17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ad4faee2-b1ff-4c19-bc85-2400fc2e9787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fad96655-bef8-434f-b0eb-43ad327d0a45", "AQAAAAEAACcQAAAAEBmKuLDlUAq6YuU8PChQVhZnSPMA4XcXVXYznaIoYXZc13Jzev4NkdVZDg1wOAVtRw==", "8c3d05e4-5cce-458e-b098-fb5dd73b02ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e03b81e4-c2be-4a64-b26d-0782511cfbc4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e641f298-1b93-46b0-b26c-639056f2f297", "AQAAAAEAACcQAAAAEB23n806c1gnHXiUfdOrt1AnTuF8fF5XAHc06HZpsb0mbRzuMJa/BNy4D3ZxVi70YA==", "17179565-93da-4152-b049-78a34e5749a8" });

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_UserId_MealId",
                table: "UserMeals",
                columns: new[] { "UserId", "MealId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_MealId_FoodId",
                table: "MealFoods",
                columns: new[] { "MealId", "FoodId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserMeals_UserId_MealId",
                table: "UserMeals");

            migrationBuilder.DropIndex(
                name: "IX_MealFoods_MealId_FoodId",
                table: "MealFoods");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adf3001d-64d3-4dfb-b93f-3ad2503167e7",
                column: "ConcurrencyStamp",
                value: "b876f107-55d8-45ba-8369-a5099886c5ee");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3aee0927-28c9-4308-92cc-296bf325521b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "474e6ca7-8a06-4bd7-8a16-5868b14b3f2f", "AQAAAAEAACcQAAAAEAE02vmHzqYOnB6hD6ISiF+YVI6n15wGBng0yFZRClqHKf4NGiRk2sh3XdUUKGO4bA==", "a302900f-1335-4dc1-abbf-5a66d8f9acd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2b23ed-0959-45a4-9499-8b1ee1f0f4d9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0a256161-21ba-4897-ab79-8dba86691c56", "AQAAAAEAACcQAAAAEBdSdEQ37ulyiTrshHbwpJXcRe5qisLmGAWtDVJ968sQmYn4PZNcEOPbaVWhfG+5zg==", "50191ff2-ab8d-4fd5-b947-edd37f41adb5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79e01d9b-c428-4770-8d58-17b51dd482c3", "AQAAAAEAACcQAAAAEMrmWQbsIWV7fro3TflhpQmPt2PhMWcOFk0dAHN31FzfdeTBIsOc0FlQvDgzCHvLSA==", "26f39cbe-44a7-4423-998d-32e003f302e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2810bcca-660d-4b9f-8936-8f265edfaadf", "AQAAAAEAACcQAAAAEBeZa3nsD73Z0Id2aTThY3AHFLZeGCtA8psWlOBlrs/WDk2DqMpZBFvn6Xk6a7gU5A==", "368cb026-2c8b-4c24-81be-29009d659a9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ad4faee2-b1ff-4c19-bc85-2400fc2e9787",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a144a95-bf4d-4834-8ea2-f61b5aba0716", "AQAAAAEAACcQAAAAEObYBN8+cm3eL+CzrqnPCiAGdmgZ/+7SaWomVmc7BDFBE8RtvQyb7qUS7XW3dyJjVw==", "9d9a875a-ecb3-4dfb-b3a8-d4a49494aba4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e03b81e4-c2be-4a64-b26d-0782511cfbc4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "918538d0-01d6-4465-8760-56432897f963", "AQAAAAEAACcQAAAAEHap9i/2+WwSen//V2vqUiZdw0dcmAoOZKYuwHK1a9FI/XsQ+EpFx8tcnI8YAifrxg==", "251ad396-9191-4e12-af86-9b397bd232a5" });

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_UserId",
                table: "UserMeals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_MealId",
                table: "MealFoods",
                column: "MealId");
        }
    }
}
