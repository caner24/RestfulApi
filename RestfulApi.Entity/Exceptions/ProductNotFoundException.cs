using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Entity.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(Guid id) : base($"Aradığnız id ile ürün bulunamadı : {id}")
        {
        }
    }
}
