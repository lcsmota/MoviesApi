using FluentValidation;
using MoviesApi.Models;

namespace MoviesApi.Validations;

public class MovieValidator : AbstractValidator<Movie>
{
    public MovieValidator()
    {
        RuleFor(e => e.Title)
            .NotEmpty().WithMessage("Title is required")
            .NotNull().WithMessage("Title is required")
            .MinimumLength(6).WithMessage("Title must contain a minimum of 6 characters")
            .MaximumLength(80).WithMessage("Title must contain a maximum of 80 characters");

        RuleFor(e => e.Genre)
            .NotEmpty().WithMessage("Genre is required")
            .NotNull().WithMessage("Genre is required")
            .MinimumLength(3).WithMessage("Genre must contain a minimum of 4 characters")
            .MaximumLength(20).WithMessage("Genre must contain a maximum of 20 characters");

        RuleFor(e => e.ReleaseDate)
            .NotEmpty().WithMessage("ReleaseDate is required")
            .NotNull().WithMessage("ReleaseDate is required")
            .LessThan(DateTime.Now);
    }
}
