using MediatR;
using Microsoft.EntityFrameworkCore;
using SkilltonTest.Commands;
using SkilltonTest.Data;

namespace SkilltonTest.Handlers;

public class EditEmployerCommandHandler : IRequestHandler<EditEmployerCommand, bool>
{
    private readonly EmployeeDbContext _dbContext;

    public EditEmployerCommandHandler(EmployeeDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<bool> Handle(EditEmployerCommand request, CancellationToken cancellationToken)
    {
        var employer = await _dbContext.Employers.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);
        
        if (employer is null) 
            return false;
        
        employer.FirstName = request.FirstName;
        employer.LastName = request.LastName;
        employer.DateOfBirth = request.DateOfBirth;
        employer.Email = request.Email;
        employer.Salary = request.Salary;

        _dbContext.Entry(employer).State = EntityState.Modified;
        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}