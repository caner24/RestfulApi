using RestfulApi.Entity.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestfulApi.Entity.Dto
{
    public record AddAuthorDto
    {
        public string? Name { get; init; }
        public string? Surname { get; init; }
        public DateTime BirthDate { get; init; }
    }
}
