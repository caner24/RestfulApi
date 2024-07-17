using FluentValidation;
using RestfulApi.Application.Author.Queries.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class GetAuthorByIdDtoValidator : AbstractValidator<GetAuthorByIdQueryRequest>
    {
        public GetAuthorByIdDtoValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Id alani boş bırakılamaz !.");
        }
    }
}
