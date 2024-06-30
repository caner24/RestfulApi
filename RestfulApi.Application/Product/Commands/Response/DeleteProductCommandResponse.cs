using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Product.Commands.Response
{
    public record DeleteProductCommandResponse
    {
        public bool IsDeleted { get; init; }
    }
}
