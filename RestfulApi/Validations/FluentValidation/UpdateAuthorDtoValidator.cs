using FluentValidation;
using RestfulApi.Application.Author.Commands.Request;
using RestfulApi.Entity.Dto;

namespace RestfulApi.Validations.FluentValidation
{
    public class UpdateAuthorDtoValidator : AbstractValidator<UpdateAuthorCommandRequest>
    {
        public UpdateAuthorDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage($"{nameof(UpdateAuthorDto.Id)} alanı boş birakilamaz");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage($"{nameof(UpdateAuthorDto.Name)} alanı boş birakilamaz");
            RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage($"{nameof(UpdateAuthorDto.Surname)} alanı boş birakilamaz");
            RuleFor(x => x.BirthDate).LessThan(DateTime.Now.Date).WithMessage($"{nameof(UpdateAuthorDto.BirthDate)} alanı boş birakilamaz");


        }



    }
}
