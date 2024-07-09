using MediatR;
using RestfulApi.Application.Book.Commands.Response;
using RestfulApi.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Book.Commands.Request
{
    public record UpdateBookCommandRequest : UpdateBookDto, IRequest<UpdateBookCommandResponse>
    {
    }
}
