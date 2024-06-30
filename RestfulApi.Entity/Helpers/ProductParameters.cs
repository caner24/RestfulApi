using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Entity.Helpers
{
    public class ProductParameters : QueryStringParameters
    {
        public ProductParameters()
        {
            OrderBy = "ProductName";
        }

        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }

        public bool ValidYearRange => MaxPrice > MinPrice;

        public string Name { get; set; }
    }
}
