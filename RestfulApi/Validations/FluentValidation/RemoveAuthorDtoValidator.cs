using FluentValidation;
using RestfulApi.Application.Author.Commands.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class RemoveAuthorDtoValidator:AbstractValidator<DeleteAuthorCommandRequest>
    {
        public RemoveAuthorDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id alani boş bırakılamaz !.");
        }
    }
}
