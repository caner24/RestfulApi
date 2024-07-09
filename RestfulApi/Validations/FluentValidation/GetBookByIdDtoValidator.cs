using FluentValidation;
using RestfulApi.Application.Book.Queries.Request;
using RestfulApi.Application.Product.Commands.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class GetBookByIdDtoValidator : AbstractValidator<GetBookByIdQueryRequest>
    {
        public GetBookByIdDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().GreaterThan(0).WithMessage("Id alani boş bırakılamaz !.");
        }
    }
}
