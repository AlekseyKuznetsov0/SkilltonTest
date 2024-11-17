using MediatR;
using SkilltonTest.Entities;

namespace SkilltonTest.Queries;

public class GetAllEmployersQuery : IRequest<IEnumerable<Employer>>
{
    
}