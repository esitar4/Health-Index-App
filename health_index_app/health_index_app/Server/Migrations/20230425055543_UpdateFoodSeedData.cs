using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace health_index_app.Server.Migrations
{
    public partial class UpdateFoodSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 26547, 66486 },
                column: "NumberOfUnits",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 31818, 101820 },
                column: "NumberOfUnits",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 91707, 132185 },
                column: "NumberOfUnits",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 251811, 289802 },
                column: "NumberOfUnits",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 568586, 591920 },
                column: "NumberOfUnits",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 1921249, 1886238 },
                column: "NumberOfUnits",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 2861015, 2787144 },
                column: "NumberOfUnits",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 9771793, 9336939 },
                column: "NumberOfUnits",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 41321916, 36059775 },
                column: "NumberOfUnits",
                value: 1.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 26547, 66486 },
                column: "NumberOfUnits",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 31818, 101820 },
                column: "NumberOfUnits",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 91707, 132185 },
                column: "NumberOfUnits",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 251811, 289802 },
                column: "NumberOfUnits",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 568586, 591920 },
                column: "NumberOfUnits",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 1921249, 1886238 },
                column: "NumberOfUnits",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 2861015, 2787144 },
                column: "NumberOfUnits",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 9771793, 9336939 },
                column: "NumberOfUnits",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumns: new[] { "Id", "ServingId" },
                keyValues: new object[] { 41321916, 36059775 },
                column: "NumberOfUnits",
                value: 0.0);
        }
    }
}
