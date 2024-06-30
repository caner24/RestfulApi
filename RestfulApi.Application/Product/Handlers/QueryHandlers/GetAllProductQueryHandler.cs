using MediatR;
using RestfulApi.Application.Product.Queries.Request;
using System;
using System.Collections.Generic;
using RestfulApi.Data.Abstract;
using System.Security.Principal;
using RestfulApi.Entity;
using RestfulApi.Entity.Helpers;
namespace RestfulApi.Application.Product.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GellAllProductQueryRequest, PagedList<ShapedEntity>>
    {
        private readonly IProductDal _productDal;
        private readonly ISortHelper<RestfulApi.Entity.Product> _sortHelper;
        private readonly IDataShaper<RestfulApi.Entity.Product> _dataShaper;
        public GetAllProductQueryHandler(IProductDal productDal, ISortHelper<RestfulApi.Entity.Product> sortHelper, IDataShaper<RestfulApi.Entity.Product> dataShaper)
        {
            _productDal = productDal;
            _sortHelper = sortHelper;
            _dataShaper = dataShaper;
        }

        public async Task<PagedList<ShapedEntity>> Handle(GellAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = _productDal.GetAll();

            SearchByName(ref products, request.Name);
            var sortedProducts = _sortHelper.ApplySort(products, request.OrderBy);
            var shapedProducts = _dataShaper.ShapeData(sortedProducts, request.Fields);

            return  PagedList<ShapedEntity>.ToPagedList(shapedProducts,
          request.PageNumber,
          request.PageSize);
        }

        private void SearchByName(ref IQueryable<RestfulApi.Entity.Product> products, string productName)
        {
            if (!products.Any() || string.IsNullOrWhiteSpace(productName))
                return;

            if (string.IsNullOrEmpty(productName))
                return;

            products = products.Where(o => o.ProductName == productName);
        }
    }
}
