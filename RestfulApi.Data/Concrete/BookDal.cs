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
    public class BookDal : EFRepositoryBase<RestfulApiContext, Book>, IBookDal
    {
        public BookDal(RestfulApiContext tContext) : base(tContext)
        {
        }
    }
}
