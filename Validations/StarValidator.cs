using FluentValidation;
using MoviesApi.Models;

namespace MoviesApi.Validations;

public class StarValidator : AbstractValidator<Star>
{
    public StarValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("Name is required")
            .NotNull().WithMessage("Name is required")
            .MinimumLength(6).WithMessage("Name must contain a minimum of 6 characters")
            .MaximumLength(20).WithMessage("Name must contain a maximum of 20 characters");

        RuleFor(e => e.Surname)
            .NotEmpty().WithMessage("Surname is required")
            .NotNull().WithMessage("Surname is required")
            .MinimumLength(4).WithMessage("Surname must contain a minimum of 4 characters")
            .MaximumLength(20).WithMessage("Surname must contain a maximum of 20 characters");

        RuleFor(e => e.Nationality)
            .NotEmpty().WithMessage("Nationality is required")
            .NotNull().WithMessage("Nationality is required")
            .MinimumLength(4).WithMessage("Nationality must contain a minimum of 4 characters")
            .MaximumLength(20).WithMessage("Nationality must contain a maximum of 20 characters");

        RuleFor(e => e.BirthDate)
            .NotEmpty().WithMessage("BirthDate is required")
            .NotNull().WithMessage("BirthDate is required")
            .LessThan(DateTime.Now);

        RuleFor(e => e.WonOscar)
            .NotEmpty().WithMessage("WonOscar is required")
            .NotNull().WithMessage("WonOscar is required");
    }
}
