using MediatR;
using RestfulApi.Application.Author.Commands.Response;
using RestfulApi.Application.Genre.Commands.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Genre.Commands.Request
{
    public record AddGenreCommandRequest : IRequest<AddGenreCommandResponse>
    {
        public string? GenreName { get; init; }
    }
}
