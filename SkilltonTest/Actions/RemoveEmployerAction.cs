using MediatR;
using SkilltonTest.Commands;
using SkilltonTest.Queries;

namespace SkilltonTest.Actions;

public class RemoveEmployerAction : IConsoleAction
{
    private readonly IMediator _mediator;
    
    public RemoveEmployerAction(IMediator mediator) =>
        _mediator = mediator;

    public async void Start()
    {
        while (true)
        {
            Console.WriteLine("Ведите Id сотрудника (- выход)");
            string? s = Console.ReadLine();
            
            if(s is not null && s.Equals("-"))
                return;
            
            if (String.IsNullOrEmpty(s))
                continue;
            
            int id;
            try
            {
                id = Convert.ToInt32(s);
            }
            catch
            {
                continue;
            }
            
            var employerData = await _mediator.Send(new GetEmployerByIdQuery() { Id = id });
            if (employerData is null)
            {
                Console.WriteLine("Сотрудника с таким Id не существует");
                continue;
            }

            try
            {
                await _mediator.Send(new RemoveEmployerCommand(){Id = id});
                break;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}