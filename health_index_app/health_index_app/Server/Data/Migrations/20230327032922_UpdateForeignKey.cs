using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace health_index_app.Server.Data.Migrations
{
    public partial class UpdateForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "UserMeals");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserMeals",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserMeals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ParentId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_MealId",
                table: "UserMeals",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMeals_UserId",
                table: "UserMeals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_FoodId",
                table: "MealFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_MealId",
                table: "MealFoods",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ParentId",
                table: "AspNetUsers",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ParentId",
                table: "AspNetUsers",
                column: "ParentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealFoods_Foods_FoodId",
                table: "MealFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealFoods_Meals_MealId",
                table: "MealFoods",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeals_AspNetUsers_UserId",
                table: "UserMeals",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMeals_Meals_MealId",
                table: "UserMeals",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_ParentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MealFoods_Foods_FoodId",
                table: "MealFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_MealFoods_Meals_MealId",
                table: "MealFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeals_AspNetUsers_UserId",
                table: "UserMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMeals_Meals_MealId",
                table: "UserMeals");

            migrationBuilder.DropIndex(
                name: "IX_UserMeals_MealId",
                table: "UserMeals");

            migrationBuilder.DropIndex(
                name: "IX_UserMeals_UserId",
                table: "UserMeals");

            migrationBuilder.DropIndex(
                name: "IX_MealFoods_FoodId",
                table: "MealFoods");

            migrationBuilder.DropIndex(
                name: "IX_MealFoods_MealId",
                table: "MealFoods");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ParentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserMeals");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserMeals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "UserMeals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ParentId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
