using RestfulApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Book.Queries.Response
{
    public record GetBookByIdQueryResponse
    {
        public int Id { get; init; }
        public string BookName { get; init; }
        public string Author { get; init; }
        public DateTime PublishDate { get; init; }
        private DateTime AdedDate { get; init; }

    }
}
