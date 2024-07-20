using CleanArchitectureDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureDemo.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void EnsureDataMigrations(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();

                InitializeData(context);
            }
        }

        public static void InitializeData(ApplicationDbContext context)
        {
            // Check if the database is already seeded
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User { Name = "Admin", Email = "admin@example.com" }
                );
            }

            if (!context.Teams.Any())
            {
                context.Teams.AddRange(
                    new Team { Name = "Develop", Email = "develop@example.com" }
                );
            }

            context.SaveChanges();
        }
    }
}