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
    public class AuthorDal : EFRepositoryBase<RestfulApiContext, Author>, IAuthorDal
    {
        public AuthorDal(RestfulApiContext tContext) : base(tContext)
        {
        }
    }
}
