using MediatR;

namespace SkilltonTest.Commands;

public class EditEmployerCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public double Salary { get; set; }

}