using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinimalApi.Domain.Entities.Students;

namespace MinimalApi.Infrastructure.Persistence.Configurations.Entities.Students;

public sealed class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students", "public");
        builder.HasKey(k => k.Id);

        builder.Property(k => k.StudentCode)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(k => k.FirstName)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(k => k.LastName)
            .HasMaxLength(200);
        builder.Property(k => k.Email)
            .IsRequired();
        builder.Property(k => k.Phone)
            .IsRequired();
    }
}
