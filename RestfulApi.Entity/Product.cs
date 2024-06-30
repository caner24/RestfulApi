using RestfulApi.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Entity
{
    public class Product : IEntity
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        public ProductDetail ProductDetail { get; set; }
    }
}
