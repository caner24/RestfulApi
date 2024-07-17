using AutoMapper;
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
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, UpdateAuthorCommandResponse>
    {
        private readonly IAuthorDal _authorDal;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorDal authorDal, IMapper mapper)
        {
            _authorDal = authorDal;
            _mapper = mapper;
        }
        public async Task<UpdateAuthorCommandResponse> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorDal.Get(x => x.Id == request.Id).AsNoTracking().FirstOrDefaultAsync();
            if (author is null)
                throw new Exception("Author not found !.");

            var authorDto = _mapper.Map<Entity.Author>(request);
            await _authorDal.UpdateAsync(authorDto);

            return new UpdateAuthorCommandResponse { IsUpdated = true };
        }
    }
}
