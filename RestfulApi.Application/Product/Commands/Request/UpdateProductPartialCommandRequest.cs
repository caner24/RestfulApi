using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using RestfulApi.Application.Product.Commands.Response;
using RestfulApi.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Product.Commands.Request
{
    public class UpdateProductPartialCommandRequest : JsonPatchDocument<UpdateProductDto>, IRequest<UpdateProductPartialCommandResponse>
    {
        public Guid Id { get; set; }

    }
}
