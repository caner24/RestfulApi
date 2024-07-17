using FluentValidation;
using RestfulApi.Application.Author.Commands.Request;
using RestfulApi.Application.Product.Commands.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class DeleteAuthorDtoValidator : AbstractValidator<DeleteAuthorCommandRequest>
    {

        public DeleteAuthorDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id boş birakilamaz !.");
        }

    }
}
