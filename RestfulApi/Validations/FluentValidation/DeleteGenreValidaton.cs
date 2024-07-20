using FluentValidation;
using RestfulApi.Application.Genre.Commands.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class DeleteGenreValidaton : AbstractValidator<DeleteGenreCommandRequest>
    {
        public DeleteGenreValidaton()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be not null");
        }
    }
}
