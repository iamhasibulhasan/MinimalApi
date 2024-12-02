using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MinimalApi.Infrastructure.Persistence;

public sealed class RndDbContext : DbContext
{
    public RndDbContext(DbContextOptions<RndDbContext> options) : base(options)
    {

    }

    // This is for entity (configuration) reading 
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
