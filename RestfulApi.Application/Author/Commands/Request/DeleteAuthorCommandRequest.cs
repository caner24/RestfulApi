using MediatR;
using RestfulApi.Application.Author.Commands.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Author.Commands.Request
{
    public record DeleteAuthorCommandRequest : IRequest<DeleteAuthorCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
