using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkilltonTest.Actions;
using SkilltonTest.Data;

namespace SkilltonTest;

public class Dependencies
{
    public static void ConfigureDependencies(IConfiguration configuration, IServiceCollection services)
    {
        services.AddDbContext<EmployeeDbContext>(options =>
        {
            options.UseInMemoryDatabase("EmployersDb");
            //options.UseSqlServer(configuration.GetConnectionString("connectionString"));
            //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
    
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient<AddNewEmployerAction>();
        services.AddTransient<EditEmployerAction>();
        services.AddTransient<RemoveEmployerAction>();
        services.AddTransient<GetAllEmployersAction>();
    }
}