using MediatR;
using SkilltonTest.Entities;

namespace SkilltonTest.Queries;

public class GetEmployerByIdQuery : IRequest<Employer?>
{
    public int Id { get; set; }
}