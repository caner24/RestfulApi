using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Book.Commands.Response
{
    public record DeleteBookByIdCommandResponse
    {
        public bool IsDeleted { get; init; }
    }
}
