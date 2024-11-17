using Microsoft.EntityFrameworkCore;
using SkilltonTest.Entities;

namespace SkilltonTest.Data;

public class EmployeeDbContext : DbContext
{
    public DbSet<Employer> Employers { get; set; }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {
    }
}