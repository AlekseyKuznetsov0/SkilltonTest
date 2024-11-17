using MediatR;
using Microsoft.EntityFrameworkCore;
using SkilltonTest.Data;
using SkilltonTest.Entities;
using SkilltonTest.Queries;

namespace SkilltonTest.Handlers;

public class GetEmployerByIdQueryHandler : IRequestHandler<GetEmployerByIdQuery, Employer?>
{
    private readonly EmployeeDbContext _dbContext;
    public GetEmployerByIdQueryHandler(EmployeeDbContext dbContext) =>
        _dbContext = dbContext;
    public async Task<Employer?> Handle(GetEmployerByIdQuery request, CancellationToken cancellationToken) =>
        await _dbContext.Employers.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);
}