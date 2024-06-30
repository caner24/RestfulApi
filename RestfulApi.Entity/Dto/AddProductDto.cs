using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Entity.Dto
{
    public record AddProductDto
    {
        public string? ProductName { get; init; }
        public double ProductPrice { get; init; }
        public int Amount { get; init; }
        public string? DetailText { get; init; }
    }
}
