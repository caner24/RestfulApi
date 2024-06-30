using FluentValidation;
using RestfulApi.Application.Product.Commands.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class DeleteProductDtoValidation : AbstractValidator<DeleteProductCommandRequest>
    {
        public DeleteProductDtoValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id boş birakilamaz !.");

        }

    }
}
