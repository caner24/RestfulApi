using RestfulApi.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Entity
{
    public class ProductDetail : IEntity
    {
        public int Amount { get; set; }
        public string? DetailText { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
