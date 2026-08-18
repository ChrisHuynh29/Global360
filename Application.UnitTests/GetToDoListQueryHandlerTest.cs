using Application.Contracts;
using Application.Queries.GetToDoList;
using Domain.Entities;
using Moq;

namespace Application.UnitTests
{
    public class GetToDoListQueryHandlerTest
    {
        [Fact]
        public async Task Handle_ValidCommand_ReturnsToDoList()
        {
            // Arrange
            var mockRepository = new Mock<IToDoRepository>();
            var command = new GetToDoListQuery();
            mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(
                [
                    new ToDoItem { Id = 1, Title = "Test ToDo 1" },
                    new ToDoItem { Id = 2, Title = "Test ToDo 2" }
                ]);
            var handler = new GetToDoListQueryHandler(mockRepository.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Test ToDo 1", result[0].Title);
            Assert.Equal("Test ToDo 2", result[1].Title);

            mockRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task Handle_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            var mockRepository = new Mock<IToDoRepository>();
            var command = new GetToDoListQuery();
            mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<ToDoItem>());

            var handler = new GetToDoListQueryHandler(mockRepository.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);

            mockRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
        }
    }
}
