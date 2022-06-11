using FluentValidation;
using Movie.Core.Request;

namespace Movie.Core.Validator
{
    public class MovieValidator : AbstractValidator<MovieRequest>
    {
        public MovieValidator()
        {
            RuleFor(m => m.MovieId).NotNull();
            RuleFor(m => m.Title).NotEmpty().NotNull();
            RuleFor(m => m.DateAdd).NotEmpty().NotNull();
            RuleFor(m => m.Duration).NotEmpty().NotNull();
            RuleFor(m => m.Year).GreaterThan(0);
            RuleFor(m => m.Description).NotEmpty().NotNull();
            RuleFor(m => m.Rate).NotEmpty().NotNull();
        }
    }
}