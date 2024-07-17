using RestfulApi.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Entity
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public DateTime PublishDate { get; set; }
        private DateTime AdedDate => DateTime.Now;
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }

    }
}
