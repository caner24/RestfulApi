using FluentValidation;
using RestfulApi.Application.Book.Queries.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class DeleteBookByIdValidator : AbstractValidator<DeleteBookByIdCommandRequest>
    {
        public DeleteBookByIdValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0).WithMessage("Id alani boş bırakılamaz !.");

        }
    }
}
