using MediatR;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Genre.Queries.Request;
using RestfulApi.Application.Genre.Queries.Response;
using RestfulApi.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Application.Genre.Handlers.QueryHandlers
{
    public class GetGenreDetailQueryHandler : IRequestHandler<GetGenreDetailQueryRequest, GetGenreDetailQueryResponse>
    {
        private readonly IGenreDal _genredDal;
        public GetGenreDetailQueryHandler(IGenreDal genreDal)
        {
            _genredDal = genreDal;
        }

        public async Task<GetGenreDetailQueryResponse> Handle(GetGenreDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var genre = await _genredDal.Get(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (genre is null)
                throw new Exception("Genre not found");


            return new GetGenreDetailQueryResponse
            {
                Id = genre.Id,
                GenreName = genre.GenreName
            };
        }
    }
}
