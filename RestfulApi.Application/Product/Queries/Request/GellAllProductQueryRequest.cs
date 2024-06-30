using MediatR;
using RestfulApi.Entity;
using RestfulApi.Entity.Dto;
using RestfulApi.Entity.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Product.Queries.Request
{
    public record GellAllProductQueryRequest : GetAllProductDto, IRequest<PagedList<ShapedEntity>>
    {

    }
}
