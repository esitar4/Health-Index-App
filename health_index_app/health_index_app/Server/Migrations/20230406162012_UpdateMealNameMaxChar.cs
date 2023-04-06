using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace health_index_app.Server.Migrations
{
    public partial class UpdateMealNameMaxChar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "07cfe6f7-54f1-4c9a-951a-82f88235ccf5", "79181ade-a68d-4b30-8ba2-74367631e1f5" });

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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07cfe6f7-54f1-4c9a-951a-82f88235ccf5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "79181ade-a68d-4b30-8ba2-74367631e1f5");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserMeals",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86a69b2b-3fa5-4698-b7f4-4a77243e815b", "2915c3f6-56a1-49a3-a02f-ff08dad543d3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "Height", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight" },
                values: new object[,]
                {
                    { "3f2b23ed-0959-45a4-9499-8b1ee1f0f4d9", 0, "b4c78866-0b97-4f51-9da7-0a3cee914187", null, "edward@cognizant.com", true, null, null, false, null, "EDWARD@COGNIZANT.COM", "EDWARD@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAEKSvLj9BZ9HEnqC8GKRL9N0a2djWXUov+kBWlFa4uvdWhsxTu1iqQ2xXTDg3P2CLCA==", null, false, "5626211f-0aac-4c7c-882c-c420354f468b", false, "edward@cognizant.com", null },
                    { "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9", 0, "df588d91-e7ef-48d2-a300-2831b5da5259", null, "eric@cognizant.com", true, null, null, false, null, "ERIC@COGNIZANT.COM", "ERIC@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAELkzc+v3jgNXEEjmes6gC1QgosluZNY/lNiFHcb7B0tIYhenQ+YLryWN1xcZvFbZqg==", null, false, "5a4bcef6-3bc7-4ab3-b02b-5b49af9e3528", false, "eric@cognizant.com", null },
                    { "ad4faee2-b1ff-4c19-bc85-2400fc2e9787", 0, "1d37998a-7bed-4f49-b5fb-6892dcddc87f", null, "ravid@cognizant.com", true, null, null, false, null, "RAVID@COGNIZANT.COM", "RAVID@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAELZnR9QL/hM71me6WBTncVmqNtm2ecbRfnEnPI77S0TMKZPAUk9hJvABtd1+8N78Rg==", null, false, "12bb5727-a7b7-4199-8f5b-99c904597331", false, "ravid@cognizant.com", null },
                    { "e03b81e4-c2be-4a64-b26d-0782511cfbc4", 0, "48aefbc0-ff3f-4de1-884f-fd96d82abd85", null, "jessica@cognizant.com", true, null, null, false, null, "JESSICA@COGNIZANT.COM", "JESSICA@COGNIZANT.COM", null, "AQAAAAEAACcQAAAAEFc2JbPv/ncWB2suZ2U8Oylt0xEEY3pwVcUh00DbjoD/g86I9EQngH4SYzzsLak2RQ==", null, false, "64bdf398-6b3d-4fc1-9d1d-26d3ed9a1865", false, "jessica@cognizant.com", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "86a69b2b-3fa5-4698-b7f4-4a77243e815b", "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Gender", "Height", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "ParentId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight" },
                values: new object[,]
                {
                    { "3aee0927-28c9-4308-92cc-296bf325521b", 0, "2d2e29cb-edca-4dc4-a0ea-ed2dd17ed76c", null, "charles@cognizant.com", true, null, null, false, null, "CHARLES@COGNIZANT.COM", "CHARLES@COGNIZANT.COM", "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9", "AQAAAAEAACcQAAAAEE2qcsALMMYh77YSgdhFu/BNHJFka3QJbNO1viWzDinO7hmo2nX08B97y4wBgrIHLg==", null, false, "ab6e3205-c86e-4911-8300-8a4a92af9253", false, "charles@cognizant.com", null },
                    { "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5", 0, "c1fe1694-de8a-4aad-b3ad-70e07d0c5090", null, "scott@cognizant.com", true, null, null, false, null, "SCOTT@COGNIZANT.COM", "SCOTT@COGNIZANT.COM", "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9", "AQAAAAEAACcQAAAAEKT0e1KhdO3APAhrgsMhVOoi8h8IDDAUqaoY9ByQIz51OjNgFCg7mJhTizKJFX9OEQ==", null, false, "7fb4724c-1911-4ba6-8c0e-769796b1eaf9", false, "scott@cognizant.com", null }
                });

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "3f2b23ed-0959-45a4-9499-8b1ee1f0f4d9");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: "ad4faee2-b1ff-4c19-bc85-2400fc2e9787");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: "3f2b23ed-0959-45a4-9499-8b1ee1f0f4d9");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: "e03b81e4-c2be-4a64-b26d-0782511cfbc4");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: "3aee0927-28c9-4308-92cc-296bf325521b");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "86a69b2b-3fa5-4698-b7f4-4a77243e815b", "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3aee0927-28c9-4308-92cc-296bf325521b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f2b23ed-0959-45a4-9499-8b1ee1f0f4d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ad4faee2-b1ff-4c19-bc85-2400fc2e9787");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e03b81e4-c2be-4a64-b26d-0782511cfbc4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86a69b2b-3fa5-4698-b7f4-4a77243e815b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserMeals",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

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

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "25ab57d4-1ec1-45a4-b479-1b0a05e2483a");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: "3afeb668-c51a-4f4c-91f5-7e4aa9322d01");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 6,
                column: "UserId",
                value: "25ab57d4-1ec1-45a4-b479-1b0a05e2483a");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 7,
                column: "UserId",
                value: "6f1372e5-7f5b-4cac-bf87-408c987cdb0c");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "ee505841-aec9-41c3-90ce-ead4fc82818f");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "ee505841-aec9-41c3-90ce-ead4fc82818f");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: "c148fe3a-8c82-48e2-a3bf-9bf3708d1f2a");

            migrationBuilder.UpdateData(
                table: "UserMeals",
                keyColumn: "Id",
                keyValue: 8,
                column: "UserId",
                value: "ee505841-aec9-41c3-90ce-ead4fc82818f");
        }
    }
}
