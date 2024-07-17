using AutoMapper;
using MediatR;
using RestfulApi.Application.Author.Commands.Request;
using RestfulApi.Application.Author.Commands.Response;
using RestfulApi.Data.Abstract;
using RestfulApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Author.Handlers.CommandHandlers
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommandRequest, AddAuthorCommandResponse>
    {
        private readonly IAuthorDal _authorDal;
        private readonly IMapper _mapper;

        public AddAuthorCommandHandler(IAuthorDal authorDal, IMapper mapper)
        {
            _authorDal = authorDal;
            _mapper = mapper;
        }
        public async Task<AddAuthorCommandResponse> Handle(AddAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Entity.Author>(request);
            var addedAuthor = await _authorDal.AddAsync(author);
            return new AddAuthorCommandResponse { Id = addedAuthor.Id };
        }
    }
}
