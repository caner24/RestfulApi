using AutoMapper;
using MediatR;
using RestfulApi.Application.Product.Commands.Request;
using RestfulApi.Application.Product.Commands.Response;
using RestfulApi.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Product.Handlers.CommandHandlers
{
    public class AddProductCommandHandler:IRequestHandler<AddProductCommandRequest,AddProductCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductDal _productDal;

        public AddProductCommandHandler(IMapper mapper,IProductDal productDal)
        {
            _mapper = mapper;
            _productDal = productDal;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            var mappedProduct = _mapper.Map<RestfulApi.Entity.Product>(request);
            var addedProduct = await _productDal.AddAsync(mappedProduct);
            return new AddProductCommandResponse { IsAdded = addedProduct != null, Guid = addedProduct.Id };        }
    }
}
