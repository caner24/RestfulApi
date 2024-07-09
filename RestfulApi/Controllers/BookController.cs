using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestfulApi.Application.Attributes;
using RestfulApi.Application.Book.Commands.Request;
using RestfulApi.Application.Book.Queries.Request;
using RestfulApi.Application.Product.Queries.Request;

namespace RestfulApi.Controllers
{
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getBookById/{Id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> GetProductById([FromRoute] GetBookByIdQueryRequest getBookByIdCommandRequest)
        {
            var response = await _mediator.Send(getBookByIdCommandRequest);
            return Ok(response);
        }

        [HttpPut("updateBookById")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> UpdateBookById([FromBody] UpdateBookCommandRequest updateBookCommandRequest)
        {
            var response = await _mediator.Send(updateBookCommandRequest);
            return Ok(response);
        }

        [HttpPost("deleteBookById/{Id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> DeleteeBookById([FromRoute] DeleteBookByIdCommandRequest deleteBookByIdCommandRequest)
        {
            var response = await _mediator.Send(deleteBookByIdCommandRequest);
            return Ok(response);
        }
    }
}
