using MediatR;
using SkilltonTest.Commands;
using SkilltonTest.Entities;
using SkilltonTest.Queries;
using SkilltonTest.Validators;

namespace SkilltonTest.Actions;

public class EditEmployerAction : IConsoleAction
{
    private readonly NameValidator _nameValidator;
    private readonly EmailValidator _emailValidator;
    private readonly BirthDateValidator _birthDateValidator;
    private readonly SalaryValidator _salaryValidator;
    private readonly IMediator _mediator;
    
    public EditEmployerAction(
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
        EditEmployerCommand employer = new EditEmployerCommand();
        Employer? oldEmployerData;
        
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

            oldEmployerData = await _mediator.Send(new GetEmployerByIdQuery() { Id = id });
            if (oldEmployerData is null)
            {
                Console.WriteLine("Сотрудника с таким Id не существует");
                continue;
            }
            
            employer.Id = id;
            break;
        }
        
        while (true)
        {
            Console.WriteLine("Ведите имя сотрудника (- выход, > пропустить)");
            string? firstName = Console.ReadLine();
            
            if(firstName is not null && firstName.Equals("-"))
                return;
            
            if (firstName is not null && firstName.Equals(">"))
            {
                employer.FirstName = oldEmployerData.FirstName;
                break;
            }
            
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
            Console.WriteLine("Ведите фамилию сотрудника (- выход, > пропустить)");
            string? lastName = Console.ReadLine();
            
            if(lastName is not null && lastName.Equals("-"))
                return;
            
            if (lastName is not null && lastName.Equals(">"))
            {
                employer.LastName = oldEmployerData.LastName;
                break;
            }

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
            Console.WriteLine("Ведите email сотрудника (- выход, > пропустить)");
            string? email = Console.ReadLine();
            
            if(email is not null && email.Equals("-"))
                return;
            
            if (email is not null && email.Equals(">"))
            {
                employer.Email = oldEmployerData.Email;
                break;
            }

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
            Console.WriteLine("Ведите дату рождения сотрудника (- выход, > пропустить)");
            string? s = Console.ReadLine();
            
            if(s is not null && s.Equals("-"))
                return;
            
            if (s is not null && s.Equals(">"))
            {
                employer.DateOfBirth = oldEmployerData.DateOfBirth;
                break;
            }

            if (String.IsNullOrEmpty(s))
                continue;

            DateOnly birthDate;
            try
            {
                birthDate = DateOnly.FromDateTime(Convert.ToDateTime(s));
            }
            catch
            {
                continue;
            }

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
            Console.WriteLine("Ведите зарплату сотрудника (- выход, > пропустить)");
            string? s = Console.ReadLine();
            
            if(s is not null && s.Equals("-"))
                return;
            
            if (s is not null && s.Equals(">"))
            {
                employer.FirstName = oldEmployerData.FirstName;
                break;
            }

            if (String.IsNullOrEmpty(s))
                continue;

            double salary;
            try
            {
                salary = Convert.ToDouble(s);
            }
            catch
            {
                continue;
            }
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