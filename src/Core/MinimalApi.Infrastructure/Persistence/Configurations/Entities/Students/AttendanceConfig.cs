using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalApi.Domain.Common;
using MinimalApi.Domain.Entities.Students;

namespace MinimalApi.Infrastructure.Persistence.Configurations.Entities.Students;

public sealed class AttendanceConfig : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("Attendance", "public");
        builder.HasKey(k => k.Id);

        builder.Property(k => k.Date)
           .IsRequired();

        builder.Property(k => k.StudentStatus)
           .HasDefaultValue((int)EntityConstants.StudentStatus.Present);

        builder.HasOne(f => f.Enrollment)
              .WithMany()
              .HasForeignKey(f => f.EnrollmentId)
              .IsRequired();
    }
}
