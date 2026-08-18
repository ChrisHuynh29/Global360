using Infrastructure.Repositories;

namespace Infrastructure.UnitTests
{
    public class ToDoRepositoryTest
    {
        [Fact]
        public async Task CreateToDoItem_ShouldAddItemToRepository()
        {
            // Arrange
            var repository = new ToDoRepository();
            var newItem = new Domain.Entities.ToDoItem { Title = "Test ToDo Item" };

            // Act
            var createdItem = await repository.Create(newItem);
            var allItems = await repository.GetAllAsync();

            // Assert
            Assert.NotNull(createdItem);
            Assert.Equal(1, createdItem.Id);
            Assert.Equal("Test ToDo Item", createdItem.Title);

            Assert.Single(allItems);
            Assert.Equal(createdItem.Id, allItems[0].Id);
            Assert.Equal(createdItem.Title, allItems[0].Title);
        }

        [Fact]
        public async Task DeleteToDoItem_ShouldRemoveItemFromRepository()
        {
            // Arrange
            var repository = new ToDoRepository();
            var newItem = new Domain.Entities.ToDoItem { Title = "Test ToDo Item" };
            var createdItem = await repository.Create(newItem);

            // Act
            await repository.DeleteAsync(createdItem.Id);
            var allItems = await repository.GetAllAsync();

            // Assert
            Assert.Empty(allItems);
        }

        [Fact]
        public async Task GetById_ShouldReturnCorrectItem()
        {
            // Arrange
            var repository = new ToDoRepository();
            var newItem = new Domain.Entities.ToDoItem { Title = "Test ToDo Item" };
            var createdItem = await repository.Create(newItem);

            // Act
            var retrievedItem = await repository.GetByIdAsync(createdItem.Id);

            // Assert
            Assert.NotNull(retrievedItem);
            Assert.Equal(createdItem.Id, retrievedItem.Id);
            Assert.Equal(createdItem.Title, retrievedItem.Title);
        }

        [Fact]
        public async Task GetById_ShouldReturnNullForNonExistentItem()
        {
            // Arrange
            var repository = new ToDoRepository();

            // Act
            var retrievedItem = await repository.GetByIdAsync(999); // Non-existent ID

            // Assert
            Assert.Null(retrievedItem);

        }

        [Fact]
        public async Task GetAll_ShouldReturnAllItems()
        {
            // Arrange
            var repository = new ToDoRepository();
            var item1 = new Domain.Entities.ToDoItem { Title = "Test ToDo Item 1" };
            var item2 = new Domain.Entities.ToDoItem { Title = "Test ToDo Item 2" };
            await repository.Create(item1);
            await repository.Create(item2);

            // Act
            var allItems = await repository.GetAllAsync();

            // Assert
            Assert.Equal(2, allItems.Count);
            Assert.Contains(allItems, item => item.Title == "Test ToDo Item 1");
            Assert.Contains(allItems, item => item.Title == "Test ToDo Item 2");
        }
    }
}
