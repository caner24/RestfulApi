using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Author.Queries.Request;
using RestfulApi.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Author.Handlers.QueryHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQueryRequest, Entity.Author>
    {
        private readonly IAuthorDal _authorDal;
        public GetAuthorByIdQueryHandler(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }
        public async Task<Entity.Author> Handle(GetAuthorByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorDal.Get(x => x.Id == request.AuthorId).Include(x => x.Books).AsNoTracking().FirstOrDefaultAsync();
            if (author is null)
                throw new Exception("Author not found");

            return author;
        }
    }
}
