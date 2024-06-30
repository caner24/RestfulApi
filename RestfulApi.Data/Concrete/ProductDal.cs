using RestfulApi.Core.DataAccess.EntityFramework;
using RestfulApi.Data.Abstract;
using RestfulApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Data.Concrete
{
    public class ProductDal : EFRepositoryBase<RestfulApiContext, Product>, IProductDal
    {
        public ProductDal(RestfulApiContext tContext) : base(tContext)
        {

        }
    }
}
