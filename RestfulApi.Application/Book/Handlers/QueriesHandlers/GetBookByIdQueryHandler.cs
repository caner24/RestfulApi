using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Book.Queries.Request;
using RestfulApi.Application.Book.Queries.Response;
using RestfulApi.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Book.Handlers.QueriesHandlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQueryRequest, GetBookByIdQueryResponse>
    {
        private readonly IBookDal _bookDal;
        private readonly IMapper _mapper;
        public GetBookByIdQueryHandler(IBookDal bookDal, IMapper mapper)
        {
            _bookDal = bookDal;
            _mapper = mapper;
        }
        public async Task<GetBookByIdQueryResponse> Handle(GetBookByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookDal.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (book == null)
                throw new Exception("You searched book did not found");

            var response = _mapper.Map<GetBookByIdQueryResponse>(book);
            return response;

        }
    }
}
