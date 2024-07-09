using Microsoft.AspNetCore.Mvc;
using RestfulApi.Application.Attributes;
using RestfulApi.Application.Product.Queries.Request;

namespace RestfulApi.Controllers
{
    public class BookController : ControllerBase
    {

        [HttpGet("getProductById/{Id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> GetProductById([FromRoute] GetProductByIdQueryRequest getProductByIdQueryRequest)
        {
            var response = await _mediator.Send(getProductByIdQueryRequest);
            return Ok(response);
        }
    }
}
