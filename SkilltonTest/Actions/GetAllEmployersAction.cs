using MediatR;
using SkilltonTest.Queries;

namespace SkilltonTest.Actions;

public class GetAllEmployersAction : IConsoleAction
{
    private readonly IMediator _mediator;
    public GetAllEmployersAction(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async void Start()
    {
        var employers = await _mediator.Send(new GetAllEmployersQuery());
        foreach (var e in employers)
            Console.WriteLine($"{e.Id} - {e.FirstName} - {e.LastName} - {e.Email} - {e.DateOfBirth.ToString("yyyy-M-d")} - {e.Salary}");
    }
}