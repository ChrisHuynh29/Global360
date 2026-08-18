using Application.Commands.CreateToDo;
using Application.Contracts;
using Domain.Entities;
using Moq;

namespace Application.UnitTests
{
    public class CreateToDoCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ValidCommand_CreatesToDoAndReturnsResponse()
        {
            // Arrange
            var mockRepository = new Mock<IToDoRepository>();
            var command = new CreateToDoCommand
            {
                Title = "Test ToDo"
            };
            mockRepository.Setup(repo => repo.Create(It.IsAny<ToDoItem>()))
                .ReturnsAsync((ToDoItem item) => { item.Id = 1; return item; });
            
            var handler = new CreateToDoCommandHandler(mockRepository.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.True(result.Success);
            Assert.Equal(command.Title, result.Title);
        }

        [Fact]
        public async Task Handle_InvalidCommand_ThrowsValidationException_Specific()
        {
            // Arrange
            var repoMock = new Mock<IToDoRepository>();
            var handler = new CreateToDoCommandHandler(repoMock.Object);

            var invalidCommand = new CreateToDoCommand { Title = string.Empty };

            // Act & Assert
            await Assert.ThrowsAsync<Exceptions.ValidationException>(async () =>
            {
                await handler.Handle(invalidCommand, CancellationToken.None);
            });

            repoMock.Verify(r => r.Create(It.IsAny<ToDoItem>()), Times.Never);
        }

    }
}
