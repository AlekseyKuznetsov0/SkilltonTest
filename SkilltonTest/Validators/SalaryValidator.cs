using FluentValidation;

namespace SkilltonTest.Validators;

public class SalaryValidator : AbstractValidator<double>
{
    public SalaryValidator()
    {
        RuleFor(salary => salary)
            .Must(salary => salary > 0);
    }
}