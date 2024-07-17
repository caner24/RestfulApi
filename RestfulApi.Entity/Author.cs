using RestfulApi.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Entity
{
    public class Author : IEntity
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime BirthDate { get; set; }

        public HashSet<Book> Books { get; set; }

    }
}
