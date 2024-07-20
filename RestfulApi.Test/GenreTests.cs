using MediatR;
using Moq;
using RestfulApi.Application.Book.Commands.Request;
using RestfulApi.Application.Book.Commands.Response;
using RestfulApi.Application.Book.Queries.Request;
using RestfulApi.Application.Book.Queries.Response;
using RestfulApi.Application.Genre.Commands.Request;
using RestfulApi.Application.Genre.Commands.Response;
using RestfulApi.Application.Genre.Queries.Request;
using RestfulApi.Application.Genre.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Test
{
    public class GenreTests
    {
        private readonly Mock<IMediator> _mediatorMock;

        public GenreTests()
        {
            _mediatorMock = new Mock<IMediator>();
        }


        [Fact]
        public async Task Delete_Genre_Command()
        {
            // Arrange
            var deleteGenreByIdCommandRequest = new DeleteGenreCommandRequest { Id = 1 };
            var deleteGenreByIdCommandResponse = new DeleteGenreCommandResponse { IsDeleted = true };

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteGenreCommandRequest>(), default))
                .ReturnsAsync(deleteGenreByIdCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(deleteGenreByIdCommandRequest);

            // Assert
            Assert.True(result.IsDeleted);
        }
        [Fact]
        public async Task Delete_Genre_Command_Validator()
        {
            var updateGenreCommandRequest = new DeleteGenreCommandRequest { };
            var updateGenreCommandResponse = new DeleteGenreCommandResponse { };

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteGenreCommandRequest>(), default))
                .ReturnsAsync(updateGenreCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(updateGenreCommandRequest);

            Assert.False(result.IsDeleted);
        }

        [Fact]
        public async Task Update_Genre_Command()
        {
            var updateGenreCommandRequest = new UpdateGenreCommandRequest { Id = 1, GenreName = "Hikaye" };
            var updateGenreCommandResponse = new UpdateGenreCommandRepsonse { IsUpdated = true };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateGenreCommandRequest>(), default))
                .ReturnsAsync(updateGenreCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(updateGenreCommandRequest);

            // Assert
            Assert.True(result.IsUpdated);
        }
        [Fact]
        public async Task Update_Genre_Command_Validator()
        {
            var updateGenreCommandRequest = new UpdateGenreCommandRequest { };
            var updateGenreCommandResponse = new UpdateGenreCommandRepsonse { };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateGenreCommandRequest>(), default))
                .ReturnsAsync(updateGenreCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(updateGenreCommandRequest);

            Assert.False(result.IsUpdated);
        }
        [Fact]
        public async Task Get_Genre_Detail_Query()
        {

            // Arrange
            var deleteGenreByIdCommandRequest = new GetGenreDetailQueryRequest { Id = 1 };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetGenreDetailQueryRequest>(), default))
            .Returns(Task.FromResult(new GetGenreDetailQueryResponse()));

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(deleteGenreByIdCommandRequest);

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task Get_Genre_Detail_Query_Validator()
        {
            var updateGenreCommandRequest = new GetGenreDetailQueryRequest { };
            var updateGenreCommandResponse = new GetGenreDetailQueryResponse { };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetGenreDetailQueryRequest>(), default))
                .ReturnsAsync(updateGenreCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(updateGenreCommandRequest);

            Assert.Null(result.GenreName);
        }

        [Fact]
        public async Task Add_Genre_Command()
        {

            // Arrange
            var addGenreByIdCommandRequest = new AddGenreCommandRequest { GenreName = "demo" };
            var addGenreByIdCommandResponse = new AddGenreCommandResponse { Id = 2 };

            _mediatorMock.Setup(m => m.Send(It.IsAny<AddGenreCommandRequest>(), default))
            .Returns(Task.FromResult(addGenreByIdCommandResponse));

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(addGenreByIdCommandRequest);

            // Assert
            Assert.True(result.Id == 2);
        }
        [Fact]
        public async Task Add_Genre_Detail_Query_Validator()
        {
            var addGenreCommandRequest = new AddGenreCommandRequest { };
            var addGenreCommandResponse = new AddGenreCommandResponse { };

            _mediatorMock.Setup(m => m.Send(It.IsAny<AddGenreCommandRequest>(), default))
                .ReturnsAsync(addGenreCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(addGenreCommandRequest);

            Assert.True(result.Id < 1);
        }
    }
}
