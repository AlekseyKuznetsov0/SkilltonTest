using MediatR;

namespace SkilltonTest.Commands;

public class RemoveEmployerCommand : IRequest<bool>
{
    public int Id { get; set; }
}