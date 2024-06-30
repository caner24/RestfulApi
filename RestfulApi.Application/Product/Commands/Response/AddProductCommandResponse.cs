using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Product.Commands.Response
{
    public record AddProductCommandResponse
    {
        public Guid Guid { get; init; }
        public bool IsAdded { get; init; }
    }
}
