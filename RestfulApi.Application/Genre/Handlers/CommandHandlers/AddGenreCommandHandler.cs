using MediatR;
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
    public class AddGenreCommandHandler : IRequestHandler<AddGenreCommandRequest, AddGenreCommandResponse>
    {
        private readonly IGenreDal _genreDal;
        public AddGenreCommandHandler(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        public async Task<AddGenreCommandResponse> Handle(AddGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var genre = new Entity.Genre
            {
                GenreName = request.GenreName
            };
            var response = await _genreDal.AddAsync(genre);

            return new AddGenreCommandResponse
            {
                Id = response.Id
            };
        }
    }
}
