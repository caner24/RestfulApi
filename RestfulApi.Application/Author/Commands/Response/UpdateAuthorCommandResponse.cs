using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Author.Commands.Response
{
    public record UpdateAuthorCommandResponse
    {
        public bool IsUpdated { get; init; }
    }
}
