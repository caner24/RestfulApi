using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using RestfulApi.Application.Attributes;
using RestfulApi.Application.Author.Commands.Request;
using RestfulApi.Application.Author.Queries.Request;
using RestfulApi.Application.Genre.Commands.Request;
using RestfulApi.Application.Genre.Queries.Request;

namespace RestfulApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{AuthorId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [OutputCache(Duration = 10)]
        public async Task<IActionResult> GetAuthorById([FromRoute] GetGenreDetailQueryRequest getGenreDetailQueryRequest)
        {
            var response = await _mediator.Send(getGenreDetailQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddAuthor([FromBody] AddGenreCommandRequest addGenreCommandRequest)
        {
            var response = await _mediator.Send(addGenreCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateGenreCommandRequest updateGenreCommandRequest)
        {
            var response = await _mediator.Send(updateGenreCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> DeleteAuthor([FromRoute] DeleteGenreCommandRequest deleteGenreCommandRequest)
        {
            var response = await _mediator.Send(deleteGenreCommandRequest);
            return Ok(response);
        }
    }
}
