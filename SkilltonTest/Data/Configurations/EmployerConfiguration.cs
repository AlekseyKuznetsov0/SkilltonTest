using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkilltonTest.Entities;

namespace SkilltonTest.Data.Configurations;

public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
{
    public void Configure(EntityTypeBuilder<Employer> builder)
    {
        builder.ToTable("Employers");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnName("EmployerId")
            .HasColumnType("int");
        builder.Property(e => e.FirstName)
            .HasColumnName("FirstName")
            .HasColumnType("nvarchar(50)");
        builder.Property(e => e.LastName)
            .HasColumnName("LastName")
            .HasColumnType("nvarchar(50)");
        builder.Property(e => e.Email)
            .HasColumnName("Email")
            .HasColumnType("nvarchar(100)");
        builder.Property(e => e.DateOfBirth)
            .HasColumnName("DateOfBirth")
            .HasColumnType("date");
        builder.Property(e => e.Salary)
            .HasColumnName("Salary")
            .HasColumnType("decimal");
    }
}