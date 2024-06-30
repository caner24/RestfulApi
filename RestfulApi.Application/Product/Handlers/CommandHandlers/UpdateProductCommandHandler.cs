using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Product.Commands.Request;
using RestfulApi.Application.Product.Commands.Response;
using RestfulApi.Data.Abstract;
using RestfulApi.Entity;
using RestfulApi.Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Product.Handlers.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IProductDal productDal, IMapper mapper)
        {
            _mapper = mapper;
            _productDal = productDal;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productDal.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (product is null)
                throw new ProductNotFoundException(request.Id);

            _mapper.Map(request, product);
            var updatedProduct = await _productDal.UpdateAsync(product);
            return new UpdateProductCommandResponse { IsUpdated = true };
        }
    }
}
