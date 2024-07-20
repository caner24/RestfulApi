using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Genre.Commands.Request;
using RestfulApi.Application.Genre.Commands.Response;
using RestfulApi.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Genre.Handlers.CommandHandlers
{
    internal class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommandRequest, DeleteGenreCommandResponse>
    {
        private readonly IGenreDal _genreDal;
        public DeleteGenreCommandHandler(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }
        public async Task<DeleteGenreCommandResponse> Handle(DeleteGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var genre = await _genreDal.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (genre is null)
                throw new Exception("Genre not found");

            await _genreDal.DeleteAsync(genre);
            return new DeleteGenreCommandResponse
            {
                IsDeleted = true
            };
        }
    }
}
