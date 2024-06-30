using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestfulApi.Data.Abstract;

using RestfulApi.Application.Product.Queries.Request;
using Pipelines.Sockets.Unofficial.Buffers;
using Newtonsoft.Json;
using RestfulApi.Entity.Helpers;
using Microsoft.AspNetCore.OutputCaching;
using RestfulApi.Application.Product.Commands.Request;
using RestfulApi.Application.Attributes;
using Microsoft.AspNetCore.JsonPatch;

namespace RestfulApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private IProductDal _productDal;
        private LinkGenerator _linkGenerator;
        public ProductController(IMediator mediator, LinkGenerator linkGenerator, IProductDal productDal)
        {
            _mediator = mediator;
            _linkGenerator = linkGenerator;
            _productDal = productDal;
        }


        [HttpGet("getAllProducts")]
        [OutputCache(Duration = 10)]
        public async Task<IActionResult> GetAllProducts([FromQuery] GellAllProductQueryRequest gellAllProductQueryRequest)
        {
            var response = await _mediator.Send(gellAllProductQueryRequest);
            var metadata = new
            {
                response.TotalCount,
                response.PageSize,
                response.CurrentPage,
                response.TotalPages,
                response.HasNext,
                response.HasPrevious
            };
            var shapedProducts = response.Select(o => o.Entity).ToList();
            Response.Headers.TryAdd("X-Pagination", JsonConvert.SerializeObject(metadata));
            for (var index = 0; index < response.Count(); index++)
            {
                var ownerLinks = CreateLinksForProduct(response[index].Id, gellAllProductQueryRequest.Fields);
                shapedProducts[index].Add("Links", ownerLinks);
            }
            var productsWrapper = new LinkCollectionWrapper<RestfulApi.Entity.Entity>(shapedProducts);
            return Ok(CreateLinksForProduct(productsWrapper));
        }

        [HttpGet("getProductById/{Id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> GetProductById([FromRoute] GetProductByIdQueryRequest getProductByIdQueryRequest)
        {
            var response = await _mediator.Send(getProductByIdQueryRequest);
            return Ok(response);
        }
        [HttpPost("addProduct")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommandRequest addProductCommandRequest)
        {
            var response = await _mediator.Send(addProductCommandRequest);
            return Ok(response);
        }
        [HttpDelete("deleteProduct/{Id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductCommandRequest deleteProductCommandRequest)
        {
            var response = await _mediator.Send(deleteProductCommandRequest);
            return Ok(response);
        }
        [HttpPut("updateProduct")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            var response = await _mediator.Send(updateProductCommandRequest);
            return Ok(response);
        }
        [HttpPatch("updateProductPartial")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateProductPartial([FromBody] UpdateProductPartialCommandRequest patchDoc)
        {
            var response = await _mediator.Send(patchDoc);
            return Ok();
        }

        private IEnumerable<Link> CreateLinksForProduct(Guid id, string fields = "")
        {
            var links = new List<Link>
    {
        new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetProductById), values: new { id, fields }),
        "self",
        "GET"),
        new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(DeleteProduct), values: new { id }),
        "delete_product",
        "DELETE"),
        new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(UpdateProductPartial), values: new { id }),
        "partial_update_product",
        "PATCH"),
        new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(UpdateProduct), values: new { id }),
        "update_product",
        "PUT")
    };
            return links;
        }
        private LinkCollectionWrapper<RestfulApi.Entity.Entity> CreateLinksForProduct(LinkCollectionWrapper<RestfulApi.Entity.Entity> productsWrapper)
        {
            productsWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetAllProducts), values: new { }),
                    "self",
                    "GET"));
            return productsWrapper;
        }
    }
}
