using Application.Commands.DeleteToDo;
using Application.Contracts;
using Application.Exceptions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests
{
    public class DeleteToDoCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ValidCommand_DeletesAndReturnsSuccess()
        {
            // Arrange
            var repoMock = new Mock<IToDoRepository>();
            repoMock
                .Setup(r => r.DeleteAsync(It.IsAny<int>()))
                .Returns(Task.CompletedTask);

            var handler = new DeleteToDoCommandHandler(repoMock.Object);
            var command = new DeleteToDoCommand { Id = 1 };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
            repoMock.Verify(r => r.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidCommand_ThrowsValidationException_RepositoryNotCalled()
        {
            // Arrange
            var repoMock = new Mock<IToDoRepository>();
            var handler = new DeleteToDoCommandHandler(repoMock.Object);
            var invalidCommand = new DeleteToDoCommand { Id = 0 };

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await handler.Handle(invalidCommand, CancellationToken.None);
            });

            repoMock.Verify(r => r.DeleteAsync(It.IsAny<int>()), Times.Never);
        }
    }
}
