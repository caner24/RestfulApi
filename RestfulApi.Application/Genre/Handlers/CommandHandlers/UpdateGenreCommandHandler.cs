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
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommandRequest, UpdateGenreCommandRepsonse>
    {
        private readonly IGenreDal _genreDal;
        public UpdateGenreCommandHandler(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }
        public async Task<UpdateGenreCommandRepsonse> Handle(UpdateGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var genre = await _genreDal.Get(x => x.Id == request.Id).AsNoTracking().FirstOrDefaultAsync();
            if (genre is null)
                throw new Exception("Genre not found");

            genre.GenreName = request.GenreName;
            await _genreDal.UpdateAsync(genre);

            return new UpdateGenreCommandRepsonse { IsUpdated = true };
        }
    }
}
