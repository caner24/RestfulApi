using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Author.Commands.Response
{
    public record AddAuthorCommandResponse
    {
        public Guid Id { get; init; }
    }
}
