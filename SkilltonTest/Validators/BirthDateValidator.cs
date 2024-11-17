using FluentValidation;

namespace SkilltonTest.Validators;

public class BirthDateValidator : AbstractValidator<DateOnly>
{
    public BirthDateValidator()
    {
        RuleFor(date => date)
            .Must(date => DateTime.Now.Year - date.Year > 17 && DateTime.Now.Year - date.Year < 150)
            .WithMessage("Не верная дата");
    }
}