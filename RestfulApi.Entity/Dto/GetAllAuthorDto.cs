using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Entity.Dto
{
    public record GetAllAuthorDto
    {
        public string? Name { get; init; }
        public DateTime MinBirthDate { get; init; }
        public DateTime MaxBirthDate { get; init; }
        public string? OrderBy { get; init; }
        public string? Fields { get; init; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
