using MediatR;
using RestfulApi.Application.Author.Queries.Request;
using RestfulApi.Entity.Helpers;
using RestfulApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RestfulApi.Data.Abstract;

namespace RestfulApi.Application.Author.Handlers.QueryHandlers
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQueryRequest, PagedList<ShapedEntity>>
    {
        private readonly IAuthorDal _authorDal;
        private readonly IMapper _mapper;
        private readonly ISortHelper<Entity.Author> _sortHelper;
        private readonly IDataShaper<Entity.Author> _dataShaper;
        public GetAllAuthorQueryHandler(IAuthorDal authorDal, IMapper mapper, ISortHelper<Entity.Author> sortHelper, IDataShaper<Entity.Author> dataShaper)
        {
            _authorDal = authorDal;
            _mapper = mapper;
            _sortHelper = sortHelper;
            _dataShaper = dataShaper;
        }
        public async Task<PagedList<ShapedEntity>> Handle(GetAllAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            var parameters = _mapper.Map<AuthorParameters>(request);
            if (!parameters.ValidYearRange)
                throw new Exception("it is not valid year range.");
            var author = _authorDal.GetAll(x => x.BirthDate >= parameters.MinBirthDate && x.BirthDate <= parameters.MaxBirthDate);
            SearchByName(ref author, parameters.Name);
            var sortedProducts = _sortHelper.ApplySort(author, parameters.OrderBy);
            var shapedProducts = _dataShaper.ShapeData(sortedProducts, parameters.Fields);

            return await Task.Run(() => PagedList<ShapedEntity>.ToPagedList(shapedProducts,
          request.PageNumber,
          request.PageSize));
        }

        private void SearchByName(ref IQueryable<RestfulApi.Entity.Author> authors, string authorName)
        {
            if (!authors.Any() || string.IsNullOrWhiteSpace(authorName))
                return;

            if (string.IsNullOrEmpty(authorName))
                return;

            authors = authors.Where(o => o.Name == authorName);
        }
    }
}
