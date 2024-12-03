using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalApi.Domain.Entities.Students;

namespace MinimalApi.Infrastructure.Persistence.Configurations.Entities.Students;

public sealed class CourseConfig : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses", "public");
        builder.HasKey(k => k.Id);

        builder.Property(k => k.CourseName)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(k => k.CourseCode)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(k => k.Credits)
            .IsRequired();
    }
}
