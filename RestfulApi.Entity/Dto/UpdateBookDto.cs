using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Entity.Dto
{
    public record UpdateBookDto
    {
        public int Id { get; init; }
        public string BookName { get; init; }
        public string Author { get; init; }
        public DateTime PublishDate { get; init; }
    }
}
