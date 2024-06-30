using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Product.Commands.Request;
using RestfulApi.Application.Product.Commands.Response;
using RestfulApi.Data.Abstract;
using RestfulApi.Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Product.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductDal _productDal;
        public DeleteProductCommandHandler(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productDal.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (product is null)
                throw new ProductNotFoundException(request.Id);

            var deletedProduct = _productDal.DeleteAsync(product);

            return new DeleteProductCommandResponse { IsDeleted = deletedProduct != null };
        }
    }
}
