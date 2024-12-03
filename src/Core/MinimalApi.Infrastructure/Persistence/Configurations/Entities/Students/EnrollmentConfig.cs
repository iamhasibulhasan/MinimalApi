using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalApi.Domain.Entities.Students;

namespace MinimalApi.Infrastructure.Persistence.Configurations.Entities.Students;

public sealed class EnrollmentConfig : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("Enrollments", "public");
        builder.HasKey(k => k.Id);

        builder.Property(k => k.EnrollmentCode)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(f => f.Student)
               .WithMany()
               .HasForeignKey(f => f.StudentId)
               .IsRequired();
        builder.HasOne(f => f.Course)
               .WithMany()
               .HasForeignKey(f => f.CourseId)
               .IsRequired();
    }
}
