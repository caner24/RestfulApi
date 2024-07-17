using MediatR;
using RestfulApi.Entity.Dto;
using RestfulApi.Entity.Helpers;
using RestfulApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Author.Queries.Request
{
    public record GetAllAuthorQueryRequest : GetAllAuthorDto, IRequest<PagedList<ShapedEntity>>
    {
    }
}
