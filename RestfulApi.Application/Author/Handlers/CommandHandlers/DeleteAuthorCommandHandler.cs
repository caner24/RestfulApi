using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Author.Commands.Request;
using RestfulApi.Application.Author.Commands.Response;
using RestfulApi.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Author.Handlers.CommandHandlers
{
    internal class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommandRequest, DeleteAuthorCommandResponse>
    {
        private readonly IAuthorDal _authorDal;
        public DeleteAuthorCommandHandler(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }
        public async Task<DeleteAuthorCommandResponse> Handle(DeleteAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorDal.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (author == null)
                throw new Exception("Author not found");

            await _authorDal.DeleteAsync(author);
            return new DeleteAuthorCommandResponse { IsDeleted = true };
        }
    }
}
