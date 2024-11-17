using MediatR;

namespace SkilltonTest.Commands;

public class AddEmployerCommand : IRequest<bool>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public double Salary { get; set; }

}