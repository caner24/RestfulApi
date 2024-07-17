using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using RestfulApi.Application.Attributes;
using RestfulApi.Application.Author.Commands.Request;
using RestfulApi.Application.Author.Queries.Request;

namespace RestfulApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [OutputCache(Duration = 10)]
        public async Task<IActionResult> GetAllAuthors([FromQuery] GetAllAuthorQueryRequest getAuthorByIdQueryRequest)
        {
            var response = await _mediator.Send(getAuthorByIdQueryRequest);
            return Ok(response);
        }
        [HttpGet("{AuthorId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [OutputCache(Duration = 10)]
        public async Task<IActionResult> GetAuthorById([FromRoute] GetAuthorByIdQueryRequest getAuthorByIdQueryRequest)
        {
            var response = await _mediator.Send(getAuthorByIdQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddAuthor([FromBody] AddAuthorCommandRequest addAuthorCommandRequest)
        {
            var response = await _mediator.Send(addAuthorCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorCommandRequest updateAuthorCommandRequest)
        {
            var response = await _mediator.Send(updateAuthorCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> DeleteAuthor([FromRoute] DeleteAuthorCommandRequest deleteAuthorCommandRequest)
        {
            var response = await _mediator.Send(deleteAuthorCommandRequest);
            return Ok(response);
        }
    }
}
