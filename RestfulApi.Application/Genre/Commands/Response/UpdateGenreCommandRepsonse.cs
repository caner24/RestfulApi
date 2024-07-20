using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Genre.Commands.Response
{
    public record UpdateGenreCommandRepsonse
    {
        public bool IsUpdated { get; init; }
    }
}
