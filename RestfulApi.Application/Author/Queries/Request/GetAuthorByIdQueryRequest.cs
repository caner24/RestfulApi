using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Author.Queries.Request
{
    public class GetAuthorByIdQueryRequest : IRequest<Entity.Author>
    {
        public Guid AuthorId { get; set; }
    }
}
