using MediatR;
using Microsoft.EntityFrameworkCore;
using SkilltonTest.Data;
using SkilltonTest.Entities;
using SkilltonTest.Queries;

namespace SkilltonTest.Handlers;

public class GetAllEmployersQueryHandler : IRequestHandler<GetAllEmployersQuery, IEnumerable<Employer>>
{
    private readonly EmployeeDbContext _dbContext;
    
    public GetAllEmployersQueryHandler(EmployeeDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<IEnumerable<Employer>> Handle(GetAllEmployersQuery request, CancellationToken cancellationToken) => 
        await _dbContext.Employers.ToListAsync(cancellationToken);
    
}