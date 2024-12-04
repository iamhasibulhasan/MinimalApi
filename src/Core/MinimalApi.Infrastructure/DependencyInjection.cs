using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Infrastructure.Persistence;
using MinimalApi.Infrastructure.RepositoryImplementations.Students;
using MinimalApi.Infrastructure.ServiceImplementations.Students;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace MinimalApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RndDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("DbConnection"), b => b.MigrationsAssembly(typeof(RndDbContext).Assembly.FullName)));

        Dependency(services);
        return services;
    }
    public static void Dependency(this IServiceCollection services)
    {
        var assembliesToScan = new[]
        {
            Assembly.GetExecutingAssembly(),
            Assembly.GetAssembly(typeof(StudentService)),
            Assembly.GetAssembly(typeof(StudentRepository))
        };
        services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
            .Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("Repository"))
            .AsPublicImplementedInterfaces();
    }
}

