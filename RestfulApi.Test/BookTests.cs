using FluentValidation.Results;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;
using RestfulApi.Application.Attributes;
using RestfulApi.Application.Book.Commands.Request;
using RestfulApi.Application.Book.Commands.Response;
using RestfulApi.Application.Book.Queries.Request;
using RestfulApi.Application.Book.Queries.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace RestfulApi.Test
{
    public class BookTests
    {
        private readonly Mock<IMediator> _mediatorMock;

        public BookTests()
        {
            _mediatorMock = new Mock<IMediator>();
        }


        [Fact]
        public async Task Delete_Book_Command()
        {
            // Arrange
            var deleteBookByIdCommandRequest = new DeleteBookByIdCommandRequest { Id = 1 };
            var deleteBookByIdCommandResponse = new DeleteBookByIdCommandResponse { IsDeleted = true };

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteBookByIdCommandRequest>(), default))
                .ReturnsAsync(deleteBookByIdCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(deleteBookByIdCommandRequest);

            // Assert
            Assert.True(result.IsDeleted);
        }
        [Fact]
        public async Task Delete_Book_Command_Validator()
        {
            var updateBookCommandRequest = new DeleteBookByIdCommandRequest { };
            var updateBookCommandResponse = new DeleteBookByIdCommandResponse { };

            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteBookByIdCommandRequest>(), default))
                .ReturnsAsync(updateBookCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(updateBookCommandRequest);

            Assert.False(result.IsDeleted);
        }

        [Fact]
        public async Task Update_Book_Command()
        {
            Guid guid = new Guid("aa2a1a01-f351-4de5-96eb-dcbabe85edfa");
            var updateBookCommandRequest = new UpdateBookCommandRequest { Id = 1, AuthorId = guid, BookName = "Validation", PublishDate = DateTime.Now };
            var updateBookCommandResponse = new UpdateBookCommandResponse { IsUpdated = true };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateBookCommandRequest>(), default))
                .ReturnsAsync(updateBookCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(updateBookCommandRequest);

            // Assert
            Assert.True(result.IsUpdated);
        }
        [Fact]
        public async Task Update_Book_Command_Validator()
        {
            var updateBookCommandRequest = new UpdateBookCommandRequest { };
            var updateBookCommandResponse = new UpdateBookCommandResponse { };

            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateBookCommandRequest>(), default))
                .ReturnsAsync(updateBookCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(updateBookCommandRequest);

            Assert.False(result.IsUpdated);
        }
        [Fact]
        public async Task GetBook_Detail_Query()
        {

            // Arrange
            var deleteBookByIdCommandRequest = new GetBookByIdQueryRequest { Id = 1 };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBookByIdQueryRequest>(), default))
            .Returns(Task.FromResult(new GetBookByIdQueryResponse()));

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(deleteBookByIdCommandRequest);

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetBook_Detail_Query_Validator()
        {
            var updateBookCommandRequest = new GetBookByIdQueryRequest { };
            var updateBookCommandResponse = new GetBookByIdQueryResponse { };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetBookByIdQueryRequest>(), default))
                .ReturnsAsync(updateBookCommandResponse);

            var mediator = _mediatorMock.Object;

            // Act
            var result = await mediator.Send(updateBookCommandRequest);

            Assert.Null(result.BookName);
        }
    }
}