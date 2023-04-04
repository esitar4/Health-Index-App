using Duende.IdentityServer.EntityFramework.Options;
using health_index_app.Server.Models;
using health_index_app.Shared.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
            string AdminUserId = Guid.NewGuid().ToString();
            string AdminRoleId = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = AdminRoleId, Name = "Admin", NormalizedName = "ADMIN"});
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            { 
                Id = AdminUserId, 
                UserName = "admin@cognizant.com", 
                PasswordHash = hasher.HashPassword(null, "Hell0!"), 
                Email = "admin@cognizant.com", 
                NormalizedUserName = "admin@cognizant.com".ToUpper(),
                NormalizedEmail = "admin@cognizant.com".ToUpper(),
                EmailConfirmed = true
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId = AdminRoleId, UserId = AdminUserId });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Ravid@cognizant.com",
                PasswordHash = hasher.HashPassword(null, "Hell0!"),
                Email = "Ravid@cognizant.com",
                NormalizedUserName = "Ravid@cognizant.com".ToUpper(),
                NormalizedEmail = "Ravid@cognizant.com".ToUpper(),
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Edward@cognizant.com",
                PasswordHash = hasher.HashPassword(null, "Hell0!"),
                Email = "Edward@cognizant.com",
                NormalizedUserName = "Edward@cognizant.com".ToUpper(),
                NormalizedEmail = "Edward@cognizant.com".ToUpper(),
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Jessica@cognizant.com",
                PasswordHash = hasher.HashPassword(null, "Hell0!"),
                Email = "Jessica@cognizant.com",
                NormalizedUserName = "Jessica@cognizant.com".ToUpper(),
                NormalizedEmail = "Jessica@cognizant.com".ToUpper(),
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Charles@cognizant.com",
                PasswordHash = hasher.HashPassword(null, "Hell0!"),
                Email = "Charles@cognizant.com",
                NormalizedUserName = "Charles@cognizant.com".ToUpper(),
                NormalizedEmail = "Charles@cognizant.com".ToUpper(),
                EmailConfirmed = true,
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Scott@cognizant.com",
                PasswordHash = hasher.HashPassword(null, "Hell0!"),
                Email = "Scott@",
                NormalizedUserName = "Scott@cognizant.com".ToUpper(),
                NormalizedEmail = "Scott@cognizant.com".ToUpper(),
                EmailConfirmed = true,
            });

            base.OnModelCreating(builder);
        }

    }
}