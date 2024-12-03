using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalApi.Domain.Entities.Students;

namespace MinimalApi.Infrastructure.Persistence.Configurations.Entities.Students;

public sealed class GradeConfig : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.ToTable("Grades", "public");
        builder.HasKey(k => k.Id);

        builder.Property(p => p.GradeValue)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(f => f.Enrollment)
               .WithMany()
               .HasForeignKey(f => f.EnrollmentId)
               .IsRequired();
    }
}
