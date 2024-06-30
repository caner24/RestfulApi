using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Product.Commands.Request;
using RestfulApi.Application.Product.Commands.Response;
using RestfulApi.Data.Abstract;
using RestfulApi.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Product.Handlers.CommandHandlers
{
    public class PartialUpdateProductCommandHandler : IRequestHandler<UpdateProductPartialCommandRequest, UpdateProductPartialCommandResponse>
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        public PartialUpdateProductCommandHandler(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }
        public async Task<UpdateProductPartialCommandResponse> Handle(UpdateProductPartialCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _productDal.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
            var employeeToPatch = _mapper.Map<UpdateProductDto>(product);
            request.ApplyTo(employeeToPatch);

            var isSuccess = await _productDal.UpdateAsync(_mapper.Map<RestfulApi.Entity.Product>(employeeToPatch));
            return new UpdateProductPartialCommandResponse { IsUpdated = isSuccess != null ? true : false };
        }
    }
}
