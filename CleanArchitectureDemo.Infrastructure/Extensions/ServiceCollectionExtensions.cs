using CleanArchitectureDemo.Application.Configuration;
using CleanArchitectureDemo.Application.Interfaces;
using CleanArchitectureDemo.Application.Repositories;
using CleanArchitectureDemo.Application.Services;
using CleanArchitectureDemo.Application.Teams.Queries;
using CleanArchitectureDemo.Application.Users.Commands;
using CleanArchitectureDemo.Application.Users.Queries;
using CleanArchitectureDemo.Infrastructure.Data;
using CleanArchitectureDemo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureDemo.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
            {
                switch (configuration["SqlProvider"])
                {
                    case "sqlserver":
                        options.UseSqlServer(configuration["SqlConnectionString"])
                            .EnableSensitiveDataLogging();
                        break;

                    case "sqlite":
                        services.AddDbContext<ApplicationDbContext>((_, options) =>
                        {
                            options.UseSqlite(configuration["SqlConnectionString"]);
                        });
                        break;

                    case "inmemory":
                        services.AddDbContext<ApplicationDbContext>((_, options) =>
                        {
                            options.UseInMemoryDatabase(databaseName: "CleanArchitectureDemoInmemory");
                        });
                        break;
                }
            });

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserQueries, UserQueries>();
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();

            return services;
        }

        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTeamsHandle).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetTeamsHandle>());

            return services;
        }
    }
}