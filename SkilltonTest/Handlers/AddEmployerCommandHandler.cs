using MediatR;
using SkilltonTest.Commands;
using SkilltonTest.Data;
using SkilltonTest.Entities;

namespace SkilltonTest.Handlers;

public class AddEmployerCommandHandler : IRequestHandler<AddEmployerCommand, bool>
{
    private readonly EmployeeDbContext _dbContext;

    public AddEmployerCommandHandler(EmployeeDbContext dbContext)
    {
      
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(AddEmployerCommand request, CancellationToken cancellationToken)
    {
        Employer employer = new Employer()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            DateOfBirth = request.DateOfBirth,
            Salary = request.Salary
        };
        _dbContext.Employers.Add(employer);
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}