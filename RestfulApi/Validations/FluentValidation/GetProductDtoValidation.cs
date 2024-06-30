using FluentValidation;
using RestfulApi.Application.Product.Commands.Request;
using RestfulApi.Application.Product.Queries.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class GetProductDtoValidation : AbstractValidator<GetProductByIdQueryRequest>
    {
        public GetProductDtoValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id boş birakilamaz !.");

        }
    }
}
