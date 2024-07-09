using MediatR;
using RestfulApi.Application.Book.Queries.Response;
using RestfulApi.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Book.Queries.Request
{
    public record GetBookByIdQueryRequest : GetBookByIdDto, IRequest<GetBookByIdQueryResponse>
    {

    }
}
