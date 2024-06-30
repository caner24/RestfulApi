using FluentValidation;
using RestfulApi.Application.Product.Commands.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class UpdatePartialValidation : AbstractValidator<UpdateProductPartialCommandRequest>
    {
        public UpdatePartialValidation()
        {
            RuleFor(x => x.Id).NotNull().WithErrorCode("Id alanı boş geçilemz !.");
        }
    }
}
