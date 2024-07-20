using FluentValidation;
using RestfulApi.Application.Genre.Queries.Request;

namespace RestfulApi.Validations.FluentValidation
{
    public class GetGenreValidator : AbstractValidator<GetGenreDetailQueryRequest>
    {
        public GetGenreValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be not null");
        }
    }
}
