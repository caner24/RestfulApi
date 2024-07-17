using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Book.Commands.Request;
using RestfulApi.Application.Book.Commands.Response;
using RestfulApi.Data.Abstract;
using RestfulApi.Data.Concrete;
using RestfulApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Book.Handlers.CommandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommandRequest, UpdateBookCommandResponse>
    {
        private readonly IBookDal _bookDal;
        private readonly IAuthorDal _authorDal;

        private readonly IMapper _mapper;
        public UpdateBookCommandHandler(IBookDal bookDal, IMapper mapper, IAuthorDal authorDal)
        {
            _bookDal = bookDal;
            _mapper = mapper;
            _authorDal = authorDal;
        }
        async Task<UpdateBookCommandResponse> IRequestHandler<UpdateBookCommandRequest, UpdateBookCommandResponse>.Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookDal.Get(x => x.Id == request.Id).AsNoTracking().FirstOrDefaultAsync();
            if (book == null)
                throw new Exception("Product you searched did not found");
            var author = await _authorDal.Get(x => x.Id == request.AuthorId).FirstOrDefaultAsync();
            if (author == null)
                throw new Exception("Author not found");

            var bookDto = _mapper.Map<RestfulApi.Entity.Book>(request);
            await _bookDal.UpdateAsync(bookDto);

            return new UpdateBookCommandResponse { IsUpdated = true };

        }
    }
}
