using FluentValidation;
using RestfulApi.Application.Product.Commands.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class UpdateProductDtoValidation : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductDtoValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id boş birakilamaz !.");
            RuleFor(x => x.ProductPrice).GreaterThan(0).WithMessage("Ürün fiytı boş birakilamaz !.");
            RuleFor(x => x.ProductName).NotNull().WithMessage("Ürün adı boş birakilamaz !.");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Ürün miktarı boş birakilamaz !.");
            RuleFor(x => x.DetailText).NotNull().WithMessage("Ürün detayı boş birakilamaz !.");
        }

    }
}
