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
        }
    }
}