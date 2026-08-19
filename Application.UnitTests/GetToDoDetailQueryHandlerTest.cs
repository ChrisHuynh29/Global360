using Moq;
using Application.Contracts;
using Domain.Entities;
using Application.Exceptions;

namespace Application.UnitTests
{
    public class GetToDoDetailQueryHandlerTest
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsToDoDetail()
        {
            // Arrange
            var mockRepository = new Mock<IToDoRepository>();
            var command = new GetToDoDetailQuery()
            {
                Id = 1
            };

            mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => new ToDoItem { Id = id, Title = "Test ToDo" });

            var handler = new GetToDoDetailQueryHandler(mockRepository.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test ToDo", result.Title);

            mockRepository.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidCommand_ThrowsNotFoundException()
        {
            // Arrange
            var mockRepository = new Mock<IToDoRepository>();
            var command = new GetToDoDetailQuery()
            {
                Id = 999 // Assuming this ID does not exist
            };
            mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((ToDoItem?)null);
            var handler = new GetToDoDetailQueryHandler(mockRepository.Object);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(command, CancellationToken.None));
            mockRepository.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}