using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Book.Commands.Response;
using RestfulApi.Application.Book.Queries.Request;
using RestfulApi.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Book.Handlers.CommandHandlers
{
    public class DeleteBookByIdCommandHandler : IRequestHandler<DeleteBookByIdCommandRequest, DeleteBookByIdCommandResponse>
    {
        private readonly IBookDal _bookDal;

        public DeleteBookByIdCommandHandler(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }
        async Task<DeleteBookByIdCommandResponse> IRequestHandler<DeleteBookByIdCommandRequest, DeleteBookByIdCommandResponse>.Handle(DeleteBookByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookDal.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (book is null)
                throw new Exception("You searched product did not found");

            await _bookDal.DeleteAsync(book);

            return new DeleteBookByIdCommandResponse { IsDeleted = true };
        }
    }
}
