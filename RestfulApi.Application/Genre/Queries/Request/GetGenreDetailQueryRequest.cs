using MediatR;
using RestfulApi.Application.Genre.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Genre.Queries.Request
{
    public class GetGenreDetailQueryRequest:IRequest<GetGenreDetailQueryResponse>
    {
        public int Id { get; init; }
    }
}
