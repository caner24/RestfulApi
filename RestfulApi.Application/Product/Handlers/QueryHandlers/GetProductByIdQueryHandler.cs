using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Product.Queries.Request;
using RestfulApi.Data.Abstract;
using RestfulApi.Entity;
using RestfulApi.Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Product.Handlers.QueryHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, RestfulApi.Entity.Product>
    {
        private readonly IProductDal _productDal;
        public GetProductByIdQueryHandler(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public async Task<Entity.Product> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productDal.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (product is null)
                throw new ProductNotFoundException(request.Id);

            return product;
        }
    }
}
