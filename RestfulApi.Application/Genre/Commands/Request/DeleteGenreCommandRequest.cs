using MediatR;
using RestfulApi.Application.Genre.Commands.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Genre.Commands.Request
{
    public record DeleteGenreCommandRequest:IRequest<DeleteGenreCommandResponse>
    {
        public int Id { get; init; }
    }
}
