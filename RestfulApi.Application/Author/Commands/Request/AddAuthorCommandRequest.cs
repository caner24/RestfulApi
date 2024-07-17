using MediatR;
using RestfulApi.Application.Author.Commands.Response;
using RestfulApi.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Author.Commands.Request
{
    public record AddAuthorCommandRequest : AddAuthorDto, IRequest<AddAuthorCommandResponse>
    {

    }
}
