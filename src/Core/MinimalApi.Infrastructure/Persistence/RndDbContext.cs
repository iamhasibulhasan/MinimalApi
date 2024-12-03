using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities.Students;
using System.Reflection;

namespace MinimalApi.Infrastructure.Persistence;

public sealed class RndDbContext : DbContext
{
    public RndDbContext(DbContextOptions<RndDbContext> options) : base(options)
    {

    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Attendance> Attendance { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Course> Courses { get; set; }

    // This is for entity (configuration) reading 
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
