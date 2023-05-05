using Duende.IdentityServer.EntityFramework.Options;
using health_index_app.Server.Models;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static System.Net.WebRequestMethods;
using System;

namespace health_index_app.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<UserMeal> UserMeals { get; set; }
        public DbSet<MealFood> MealFoods { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Admin
            string AdminUserId = "93513a22-cecd-4bdc-ae16-c0dd5c95e4e9";
            string AdminRoleId = "adf3001d-64d3-4dfb-b93f-3ad2503167e7";
            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = AdminRoleId, Name = "Admin", NormalizedName = "ADMIN"});
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            { 
                Id = AdminUserId, 
                UserName = "eric@cognizant.com", 
                PasswordHash = hasher.HashPassword(null, "Hell0!"), 
                Email = "eric@cognizant.com", 
                NormalizedUserName = "eric@cognizant.com".ToUpper(),
                NormalizedEmail = "eric@cognizant.com".ToUpper(),
                EmailConfirmed = true
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = AdminRoleId, UserId = AdminUserId });


            // Users
            List<string> userIds = new List<string>() { "ad4faee2-b1ff-4c19-bc85-2400fc2e9787", "3f2b23ed-0959-45a4-9499-8b1ee1f0f4d9", "e03b81e4-c2be-4a64-b26d-0782511cfbc4", "3aee0927-28c9-4308-92cc-296bf325521b", "5ac8f00d-f3bb-4c96-8570-6f8997cf2ae5" };
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userIds[0],
                UserName = "ravid@cognizant.com",
                PasswordHash = hasher.HashPassword(null, "Hell0!"),
                Email = "ravid@cognizant.com",
                NormalizedUserName = "ravid@cognizant.com".ToUpper(),
                NormalizedEmail = "ravid@cognizant.com".ToUpper(),
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userIds[1],
                UserName = "edward@cognizant.com",
                PasswordHash = hasher.HashPassword(null, "Hell0!"),
                Email = "edward@cognizant.com",
                NormalizedUserName = "edward@cognizant.com".ToUpper(),
                NormalizedEmail = "edward@cognizant.com".ToUpper(),
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userIds[2],
                UserName = "jessica@cognizant.com",
                PasswordHash = hasher.HashPassword(null, "Hell0!"),
                Email = "jessica@cognizant.com",
                NormalizedUserName = "jessica@cognizant.com".ToUpper(),
                NormalizedEmail = "jessica@cognizant.com".ToUpper(),
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userIds[3],
                UserName = "charles@cognizant.com",
                PasswordHash = hasher.HashPassword(null, "Hell0!"),
                Email = "charles@cognizant.com",
                NormalizedUserName = "charles@cognizant.com".ToUpper(),
                NormalizedEmail = "charles@cognizant.com".ToUpper(),
                EmailConfirmed = true,
                ParentId = AdminUserId
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = userIds[4],
                UserName = "scott@cognizant.com",
                PasswordHash = hasher.HashPassword(null, "Hell0!"),
                Email = "scott@cognizant.com",
                NormalizedUserName = "scott@cognizant.com".ToUpper(),
                NormalizedEmail = "scott@cognizant.com".ToUpper(),
                EmailConfirmed = true,
                ParentId = AdminUserId
            });


            //Food
            builder.Entity<Food>().HasData(
                new Food 
                {   Id = 26547,
                    FoodName = "Double-Double Burger",
                    FoodType = "Brand",
                    BrandName = "In-N-Out",
                    FoodURL = "https://www.fatsecret.com/calories-nutrition/in-n-out/double-double-burger",
                    ServingId = 66486,
                    ServingDescription = "1 burger",
                    ServingURL = "https://www.fatsecret.com/calories-nutrition/in-n-out/double-double-burger",
                    MetricServingAmount = 330,
                    MetricServingUnit = "g",
                    NumberOfUnits = 1,
                    MeasurementDescription = "serving",
                    Calories = 670,
                    CarboHydrate = 39,
                    Protein = 37,
                    Fat = 39,
                    SaturatedFat = 17,
                    PolyunsaturatedFat = 0,
                    Cholesterol = 120,
                    Sodium = 1520,
                    Potassium = 0,
                    Fiber = 3,
                    Sugar = 10,
                    VitaminD = 0,
                    VitaminA = 0,
                    VitaminC = 0,
                    Calcium = 0,
                    Iron = 0
                },
                new Food
                {
                    Id = 31818,
                    FoodName = "Classic Iceberg Salad",
                    FoodType = "Brand",
                    BrandName = "Dole",    
                    FoodURL = "https://www.fatsecret.com/calories-nutrition/dole/classic-iceberg-salad", 
                    ServingId = 101820, 
                    ServingDescription = "1 1/2 cups",
                    ServingURL = "https://www.fatsecret.com/calories-nutrition/dole/classic-iceberg-salad",
                    MetricServingAmount = 85,
                    MetricServingUnit = "g",
                    NumberOfUnits = 1,
                    MeasurementDescription = "serving",
                    Calories = 15,
                    CarboHydrate = 4,
                    Protein = 1,
                    Fat = 0,
                    SaturatedFat = 0,
                    PolyunsaturatedFat = 0,
                    Cholesterol = 0,
                    Sodium = 15,
                    Potassium = 0,
                    Fiber = 1,
                    Sugar = 2,
                    VitaminD = 0,
                    VitaminA = 0,
                    VitaminC = 0,
                    Calcium = 0,
                    Iron = 0
                },
                new Food
                {
                    Id = 251811,
                    FoodName = "Blue Moon Beer",
                    FoodType = "Brand",
                    BrandName = "Coors",
                    FoodURL = "https://www.fatsecret.com/calories-nutrition/coors/blue-moon-beer",
                    ServingId = 289802,
                    ServingDescription = "1 bottle",
                    ServingURL = "https://www.fatsecret.com/calories-nutrition/coors/blue-moon-beer",
                    MetricServingAmount = 12,
                    MetricServingUnit = "oz",
                    NumberOfUnits = 1,
                    MeasurementDescription = "serving",
                    Calories = 164,
                    CarboHydrate = 13,
                    Protein = 2,
                    Fat = 0,
                    SaturatedFat = 0,
                    PolyunsaturatedFat = 0,
                    Cholesterol = 0,
                    Sodium = 8,
                    Potassium = 0,
                    Fiber = 0,
                    Sugar = 0,
                    VitaminD = 0,
                    VitaminA = 0,
                    VitaminC = 0,
                    Calcium = 0,
                    Iron = 0
                },
                new Food
                {
                    Id = 568586,
                    FoodName = "Golden Delicious Apples",
                    FoodType = "Generic",
                    FoodURL = "https://www.fatsecret.com/calories-nutrition/generic/apples-golden-delicious",
                    ServingId = 591920,
                    ServingDescription = "1 small (2-1/2\" dia)",
                    ServingURL = "https://www.fatsecret.com/calories-nutrition/generic/apples-golden-delicious",
                    MetricServingAmount = 106,
                    MetricServingUnit = "g",
                    NumberOfUnits = 1,
                    MeasurementDescription = "small  (2-1/2\" dia)",
                    Calories = 56,
                    CarboHydrate = 14.64,
                    Protein = 0.27,
                    Fat = 0.18,
                    SaturatedFat = 0.029,
                    PolyunsaturatedFat = 0.055,
                    Cholesterol = 0,
                    Sodium = 1,
                    Potassium = 113,
                    Fiber = 2.5,
                    Sugar = 11.01,
                    VitaminD = 0,
                    VitaminA = 3,
                    VitaminC = 4.8,
                    Calcium = 6,
                    Iron = 0.1
                },
                new Food
                {
                    Id = 2861015,
                    FoodName = "Vietnamese Pho",
                    FoodType = "Brand",
                    BrandName = "Annie Chun's",
                    FoodURL = "https://www.fatsecret.com/calories-nutrition/annie-chuns/vietnamese-pho",
                    ServingId = 2787144,
                    ServingDescription = "1 bowl",
                    ServingURL = "https://www.fatsecret.com/calories-nutrition/annie-chuns/vietnamese-pho",
                    MetricServingAmount = 170,
                    MetricServingUnit = "g",
                    NumberOfUnits = 1,
                    MeasurementDescription = "serving",
                    Calories = 280,
                    CarboHydrate = 59,
                    Protein = 10,
                    Fat = 1,
                    SaturatedFat = 0,
                    PolyunsaturatedFat = 1,
                    Cholesterol = 0,
                    Sodium = 1030,
                    Potassium = 0,
                    Fiber = 3,
                    Sugar = 4,
                    VitaminD = 0,
                    VitaminA = 0,
                    VitaminC = 0,
                    Calcium = 0,
                    Iron = 0
                },
                new Food
                {
                    Id = 9771793,
                    FoodName = "Naan",
                    FoodType = "Brand",
                    BrandName = "Suraj",
                    FoodURL = "https://www.fatsecret.com/calories-nutrition/suraj/naan",
                    ServingId = 9336939,
                    ServingDescription = "1/2 naan",
                    ServingURL = "https://www.fatsecret.com/calories-nutrition/suraj/naan",
                    MetricServingAmount = 50,
                    MetricServingUnit = "g",
                    NumberOfUnits = 1,
                    MeasurementDescription = "serving",
                    Calories = 140,
                    CarboHydrate = 24,
                    Protein = 4,
                    Fat = 3,
                    SaturatedFat = 0.5,
                    PolyunsaturatedFat = 0,
                    Cholesterol = 0,
                    Sodium = 320,
                    Potassium = 0,
                    Fiber = 1,
                    Sugar = 2,
                    VitaminD = 0,
                    VitaminA = 0,
                    VitaminC = 0,
                    Calcium = 0,
                    Iron = 0
                },
                new Food
                {
                    Id = 41321916,
                    FoodName = "Tonkotsu Ramen",
                    FoodType = "Brand",
                    BrandName = "Nong Shim",
                    FoodURL = "https://www.fatsecret.com/calories-nutrition/nong-shim/tonkotsu-ramen",
                    ServingId = 36059775,
                    ServingDescription = "1 container",
                    ServingURL = "https://www.fatsecret.com/calories-nutrition/nong-shim/tonkotsu-ramen",
                    MetricServingAmount = 101,
                    MetricServingUnit = "g",
                    NumberOfUnits = 1,
                    MeasurementDescription = "serving",
                    Calories = 450,
                    CarboHydrate = 64,
                    Protein = 8,
                    Fat = 18,
                    SaturatedFat = 7,
                    PolyunsaturatedFat = 3,
                    Cholesterol = 5,
                    Sodium = 1550,
                    Potassium = 380,
                    Fiber = 5,
                    Sugar = 5,
                    VitaminD = 0,
                    VitaminA = 0,
                    VitaminC = 0,
                    Calcium = 20,
                    Iron = 2.2
                },
                new Food
                {
                    Id = 91707,
                    FoodName = "Stir Fry Vegetables",
                    FoodType = "Brand",
                    BrandName = "Wylwood",
                    FoodURL = "https://www.fatsecret.com/calories-nutrition/wylwood/stir-fry-vegetables",
                    ServingId = 132185,
                    ServingDescription = "3/4 cup",
                    ServingURL = "https://www.fatsecret.com/calories-nutrition/wylwood/stir-fry-vegetables",
                    MetricServingAmount = 75,
                    MetricServingUnit = "g",
                    NumberOfUnits = 1,
                    MeasurementDescription = "serving",
                    Calories = 30,
                    CarboHydrate = 6,
                    Protein = 2,
                    Fat = 0,
                    SaturatedFat = 0,
                    PolyunsaturatedFat = 0,
                    Cholesterol = 0,
                    Sodium = 15,
                    Potassium = 0,
                    Fiber = 2,
                    Sugar = 3,
                    VitaminD = 0,
                    VitaminA = 0,
                    VitaminC = 0,
                    Calcium = 0,
                    Iron = 0
                },
                new Food
                {
                    Id = 1921249,
                    FoodName = "Curry",
                    FoodType = "Brand",
                    BrandName = "Assi",
                    FoodURL = "https://www.fatsecret.com/calories-nutrition/assi/curry",
                    ServingId = 1886238,
                    ServingDescription = "1 serving",
                    ServingURL = "https://www.fatsecret.com/calories-nutrition/assi/curry",
                    MetricServingAmount = 180,
                    MetricServingUnit = "g",
                    NumberOfUnits = 1,
                    MeasurementDescription = "serving",
                    Calories = 123,
                    CarboHydrate = 15,
                    Protein = 3,
                    Fat = 3.1,
                    SaturatedFat = 2,
                    PolyunsaturatedFat = 0,
                    Cholesterol = 0,
                    Sodium = 802,
                    Potassium = 0,
                    Fiber = 5,
                    Sugar = 6,
                    VitaminD = 0,
                    VitaminA = 0,
                    VitaminC = 0,
                    Calcium = 0,
                    Iron = 0
                }
            );

            builder.Entity<Meal>().HasData(
                new Meal { Id = 10001, HealthIndex = 5},
                new Meal { Id = 10002, HealthIndex = 3},
                new Meal { Id = 10003, HealthIndex = 7},
                new Meal { Id = 10004, HealthIndex = 10},
                new Meal { Id = 10005, HealthIndex = 1},
                new Meal { Id = 10006, HealthIndex = 6}
            );

            builder.Entity<MealFood>().HasData(
                new MealFood { Id = 1, MealId = 10001, FoodId = 26547, ServingId = 66486, Amount = 1 },
                new MealFood { Id = 2, MealId = 10001, FoodId = 31818, ServingId = 101820, Amount = 1 },
                new MealFood { Id = 3, MealId = 10001, FoodId = 251811, ServingId = 289802, Amount = 1 },

                new MealFood { Id = 4, MealId = 10002, FoodId = 41321916, ServingId = 36059775, Amount = 1 },
                new MealFood { Id = 5, MealId = 10002, FoodId = 26547, ServingId = 66486, Amount = 2 },

                new MealFood { Id = 6, MealId = 10003, FoodId = 91707, ServingId = 132185, Amount = 1 },
                new MealFood { Id = 7, MealId = 10003, FoodId = 1921249, ServingId = 1886238, Amount = 1 },
                new MealFood { Id = 8, MealId = 10003, FoodId = 568586, ServingId = 591920, Amount = 1 },

                new MealFood { Id = 9, MealId = 10004, FoodId = 91707, ServingId = 132185, Amount = 1 },
                new MealFood { Id = 10, MealId = 10004, FoodId = 31818, ServingId = 101820, Amount = 1 },
                new MealFood { Id = 11, MealId = 10004, FoodId = 568586, ServingId = 591920, Amount = 1 },
                new MealFood { Id = 12, MealId = 10004, FoodId = 9771793, ServingId = 9336939, Amount = 1 },

                new MealFood { Id = 13, MealId = 10005, FoodId = 251811, ServingId = 289802, Amount = 10 },
                new MealFood { Id = 14, MealId = 10005, FoodId = 2861015, ServingId = 2787144, Amount = 1 },

                new MealFood { Id = 15, MealId = 10006, FoodId = 91707, ServingId = 132185, Amount = 2 },
                new MealFood { Id = 16, MealId = 10006, FoodId = 1921249, ServingId = 1886238, Amount = 1 }
            );

            builder.Entity<UserMeal>().HasData(
                new UserMeal { Id = 1, UserId = userIds[4], MealId = 10004, Name = "Lunch" },
                new UserMeal { Id = 2, UserId = userIds[1], MealId = 10001, Name = "Snack"},
                new UserMeal { Id = 3, UserId = userIds[4], MealId = 10005, Name = "Duck" },
                new UserMeal { Id = 4, UserId = userIds[3], MealId = 10004, Name = "Worcestershire" },
                new UserMeal { Id = 5, UserId = userIds[0], MealId = 10003, Name = "Truffle Oil" },
                new UserMeal { Id = 6, UserId = userIds[1], MealId = 10004, Name = "Feta" },
                new UserMeal { Id = 7, UserId = userIds[2], MealId = 10002, Name = "Fenugreek" },
                new UserMeal { Id = 8, UserId = userIds[4], MealId = 10006, Name = "Rocket" }
            );

            builder.Entity<Food>().HasKey(f => new { f.Id, f.ServingId });
            //builder.Entity<MealFood>().HasOne(mf => mf.Food).WithMany(mf => mf.MealFood).HasForeignKey(mf => new { mf.FoodId, mf.ServingId });
            builder.Entity<UserMeal>().HasIndex(um => new {um.UserId, um.MealId}).IsUnique();
            builder.Entity<MealFood>().HasIndex(mf => new {mf.MealId, mf.FoodId}).IsUnique();

            base.OnModelCreating(builder);
        }

    }
}