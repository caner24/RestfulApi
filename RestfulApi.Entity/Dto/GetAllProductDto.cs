using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Entity.Dto
{
    public record GetAllProductDto
    {
        public string? Name { get; init; }
        public double MinPrice { get; init; }
        public double MaxPrice { get; init; }
        public string? OrderBy { get; init; }
        public string? Fields { get; init; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }


    }
}
