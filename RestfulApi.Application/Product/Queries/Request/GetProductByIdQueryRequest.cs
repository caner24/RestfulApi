using MediatR;
using RestfulApi.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Product.Queries.Request
{
    public record GetProductByIdQueryRequest : GetProductByIdDto, IRequest<RestfulApi.Entity.Product>
    {
    }
}
