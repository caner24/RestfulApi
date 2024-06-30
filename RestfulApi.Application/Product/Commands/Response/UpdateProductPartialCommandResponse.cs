using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Product.Commands.Response
{
    public record UpdateProductPartialCommandResponse
    {
        public bool IsUpdated { get; set; }
    }
}
