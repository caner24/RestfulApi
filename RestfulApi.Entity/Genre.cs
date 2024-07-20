using RestfulApi.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Entity
{
    public class Genre : IEntity
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }
        public int Id { get; set; }
        public string? GenreName { get; set; }
        public HashSet<Book> Books { get; set; }
    }
}
