using FluentValidation;
using RestfulApi.Application.Author.Commands.Request;
using RestfulApi.Entity.Dto;

namespace RestfulApi.Validations.FluentValidation
{
    public class AddAuthorDtoValidator : AbstractValidator<AddAuthorCommandRequest>
    {

        public AddAuthorDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage($"{nameof(AddAuthorCommandRequest.Name)} alanı boş birakilamaz");
            RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage($"{nameof(AddAuthorCommandRequest.Surname)} alanı boş birakilamaz");
            RuleFor(x => x.BirthDate).LessThan(DateTime.Now.Date).WithMessage($"{nameof(AddAuthorCommandRequest.BirthDate)} alanı boş birakilamaz");
        }

    }
}
