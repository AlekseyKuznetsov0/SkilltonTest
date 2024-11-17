using MediatR;
using Microsoft.EntityFrameworkCore;
using SkilltonTest.Commands;
using SkilltonTest.Data;

namespace SkilltonTest.Handlers;

public class RemoveEmployerCommandHandler : IRequestHandler<RemoveEmployerCommand, bool>
{
    private readonly EmployeeDbContext _dbContext;

    public RemoveEmployerCommandHandler(EmployeeDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<bool> Handle(RemoveEmployerCommand request, CancellationToken cancellationToken)
    {
        var employer = await _dbContext.Employers.FirstOrDefaultAsync(e => e.Id == request.Id,
                cancellationToken: cancellationToken);

        if (employer is null)
            return true;

        _dbContext.Entry(employer).State = EntityState.Deleted;

        return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}