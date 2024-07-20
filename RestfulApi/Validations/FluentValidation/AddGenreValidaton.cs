using FluentValidation;
using RestfulApi.Application.Genre.Commands.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class AddGenreValidaton : AbstractValidator<AddGenreCommandRequest>
    {
        public AddGenreValidaton()
        {
            RuleFor(x => x.GenreName).NotEmpty().NotNull().WithMessage("Genre name is required");
        }
    }
}
