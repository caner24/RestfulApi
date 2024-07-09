using FluentValidation;
using RestfulApi.Application.Book.Commands.Request;
using RestfulApi.Application.Book.Queries.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookCommandRequest>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0).WithMessage("Id alani boş bırakılamaz !.");
            RuleFor(x => x.Author).NotNull().NotEmpty().WithMessage("Author alani boş bırakılamaz !.");
            RuleFor(x => x.BookName).NotNull().NotEmpty().WithMessage("BookName alani boş bırakılamaz !.");
            RuleFor(x => x.PublishDate).NotEmpty().WithMessage("PublishDate alani boş bırakılamaz !.");

        }
    }
}
