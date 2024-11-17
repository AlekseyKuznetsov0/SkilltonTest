using MediatR;
using SkilltonTest.Commands;
using SkilltonTest.Validators;

namespace SkilltonTest.Actions;

public class AddNewEmployerAction : IConsoleAction
{
    private readonly NameValidator _nameValidator;
    private readonly EmailValidator _emailValidator;
    private readonly BirthDateValidator _birthDateValidator;
    private readonly SalaryValidator _salaryValidator;
    private readonly IMediator _mediator;
    
    public AddNewEmployerAction(
        NameValidator nameValidator, 
        EmailValidator emailValidator, 
        BirthDateValidator birthDateValidator, 
        SalaryValidator salaryValidator,
        IMediator mediator)
    {
        _nameValidator = nameValidator;
        _emailValidator = emailValidator;
        _birthDateValidator = birthDateValidator;
        _salaryValidator = salaryValidator;
        _mediator = mediator;
    }
    
    public async void Start()
    {
        AddEmployerCommand employer = new AddEmployerCommand();    
        
        while (true)
        {
            Console.WriteLine("Ведите имя сотрудника (- выход)");
            string? firstName = Console.ReadLine();
            
            if(firstName is not null && firstName.Equals("-"))
                return;
            
            var validationResult = await _nameValidator.ValidateAsync(firstName);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    Console.WriteLine(error);
                continue;
            }
            
            employer.FirstName = firstName!;
            break;
        }
        
        while (true)
        {
            Console.WriteLine("Ведите фамилию сотрудника (- выход)");
            string? lastName = Console.ReadLine();
            
            if(lastName is not null && lastName.Equals("-"))
                return;
            
            var validationResult = await _nameValidator.ValidateAsync(lastName);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    Console.WriteLine(error);
                continue;
            }
            
            employer.LastName = lastName!;
            break;
        }
        
        while (true)
        {
            Console.WriteLine("Ведите email сотрудника (- выход)");
            string? email = Console.ReadLine();
            
            if(email is not null && email.Equals("-"))
                return;
            
            var validationResult = await _emailValidator.ValidateAsync(email);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    Console.WriteLine(error);
                continue;
            }
            employer.Email = email!;
            break;
        }
        
        while (true)
        {
            Console.WriteLine("Ведите дату рождения сотрудника (- выход)");
            string? s = Console.ReadLine();
            
            if(s is not null && s.Equals("-"))
                return;
            
            if (String.IsNullOrEmpty(s))
                continue;
            
            DateOnly birthDate = DateOnly.FromDateTime(Convert.ToDateTime(s));
            var validationResult = await _birthDateValidator.ValidateAsync(birthDate);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    Console.WriteLine(error);
                continue;
            }
            
            employer.DateOfBirth = birthDate;
            break;
        }
        
        while (true)
        {
            Console.WriteLine("Ведите зарплату сотрудника (- выход)");
            string? s = Console.ReadLine();
            if(s is not null && s.Equals("-"))
                return;
            
            if (String.IsNullOrEmpty(s))
                continue;
            double salary = Convert.ToDouble(s);
            var validationResult = await _salaryValidator.ValidateAsync(salary);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    Console.WriteLine(error);
                continue;
            }
            
            employer.Salary = salary;
            break;
        }

        try
        {
            await _mediator.Send(employer);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}