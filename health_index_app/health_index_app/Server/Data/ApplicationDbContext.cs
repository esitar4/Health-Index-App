using Duende.IdentityServer.EntityFramework.Options;
using health_index_app.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
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
        public DbSet<health_index_app.Server.Models.ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<health_index_app.Server.Models.Food> Foods { get; set; }
        public DbSet<health_index_app.Server.Models.Meal> Meals { get; set; }
        public DbSet<health_index_app.Server.Models.UserMeal> UserMeals { get; set; }
    }
}