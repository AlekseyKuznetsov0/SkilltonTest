using System.Text.RegularExpressions;
using FluentValidation;

namespace SkilltonTest.Validators;

public class NameValidator : AbstractValidator<string?>
{
    public NameValidator()
    {
        RuleFor(name => name)
            .NotNull()
            .NotEmpty()
            .WithMessage("Значение не может быть пустым")
            .MinimumLength(2)
            .WithMessage("Значение слишком короткое")
            .MaximumLength(50)
            .WithMessage("Значение слишком длинное")
            .Must(firstName => Regex.IsMatch(firstName, "^[A-Z,a-z,А-Я,а-я]+"))
            .WithMessage("Значение должно содержать только буквы");
    }
}