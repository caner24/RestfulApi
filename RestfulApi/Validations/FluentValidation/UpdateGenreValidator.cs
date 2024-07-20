using FluentValidation;
using RestfulApi.Application.Genre.Commands.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenreCommandRequest>
    {
        public UpdateGenreValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be not null");
            RuleFor(x => x.GenreName).NotEmpty().NotNull().WithMessage("Genre name is required");

        }
    }
}
