using MediatR;
using Moq;
using RestfulApi.Application.Author.Commands.Request;
using RestfulApi.Application.Author.Commands.Response;
using RestfulApi.Application.Book.Commands.Response;
using RestfulApi.Application.Book.Queries.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApi.Test
{
    public class AuthorTests
    {
        private readonly Mock<IMediator> _mediatorMock;

        public AuthorTests()
        {
            _mediatorMock = new Mock<IMediator>();
        }


        [Fact]
        public async Task Delete_Author_Command_Request()
        {
            var id = Guid.Parse("aa2a1a01-f351-4de5-96eb-dcbabe85edfa");
            // Arrange
            var deleteAuthorCommandRequest = new DeleteAuthorCommandRequest { Id = id };
            var deleteAuthorCommandResponse = new DeleteAuthorCommandResponse { IsDeleted = true };

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteAuthorCommandRequest>(), default))
                .ReturnsAsync(deleteAuthorCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(deleteAuthorCommandRequest);

            // Assert
            Assert.True(result.IsDeleted);
        }
        [Fact]
        public async Task Delete_Author_Command_Validator()
        {
            var deleteAuthorCommandRequest = new DeleteAuthorCommandRequest { };
            var deleteAuthorCommandResponse = new DeleteAuthorCommandResponse { };

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteAuthorCommandRequest>(), default))
                .ReturnsAsync(deleteAuthorCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(deleteAuthorCommandRequest);

            Assert.False(result.IsDeleted);
        }

        [Fact]
        public async Task Update_Author_Command_Request()
        {
            var id = Guid.Parse("aa2a1a01-f351-4de5-96eb-dcbabe85edfa");
            // Arrange
            var updateAuthorCommandRequest = new UpdateAuthorCommandRequest { Id = id, BirthDate = DateTime.Now, Name = "Caner", Surname = "Celep" };
            var updateAuthorCommandResponse = new UpdateAuthorCommandResponse { IsUpdated = true };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateAuthorCommandRequest>(), default))
                .ReturnsAsync(updateAuthorCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(updateAuthorCommandRequest);

            // Assert
            Assert.True(result.IsUpdated);
        }
        [Fact]
        public async Task Update_Author_Command_Validator()
        {
            var updateAuthorCommandRequest = new UpdateAuthorCommandRequest { };
            var updateAuthorCommandResponse = new UpdateAuthorCommandResponse { };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateAuthorCommandRequest>(), default))
                .ReturnsAsync(updateAuthorCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(updateAuthorCommandRequest);

            Assert.False(result.IsUpdated);
        }
    }
}
