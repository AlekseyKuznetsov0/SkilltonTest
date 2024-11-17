using FluentValidation;

namespace SkilltonTest.Validators;

public class EmailValidator : AbstractValidator<string?>
{
    public EmailValidator()
    {
        RuleFor(email => email)
            .NotNull()
            .NotEmpty()
            .WithMessage("Email не может быть пустым")
            .MaximumLength(100)
            .WithMessage("Email слишком длинный")
            .EmailAddress()
            .WithMessage("Это не Email");
    }
}