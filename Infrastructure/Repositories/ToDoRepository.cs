using Domain.Entities;
using Application.Contracts;

namespace Infrastructure.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly List<ToDoItem> _toDoItems = new List<ToDoItem>();
        public async Task<List<ToDoItem>> GetAllAsync()
        {
            var result = _toDoItems.ToList();
            return await Task.FromResult(result);
        }

        public async Task<ToDoItem?> GetByIdAsync(int id)
        {
            var item = _toDoItems.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(item);
        }

        public async Task<ToDoItem> Create(ToDoItem item)
        {
            // Simulate creating a ToDo item (in a real application, this would save it to a database)
            item.Id = _toDoItems.Count + 1;
            _toDoItems.Add(item);

            return await Task.FromResult(item);
        }
        public async Task DeleteAsync(int id)
        {
            // Simulate deleting a ToDo item (in a real application, this would delete it from a database)
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _toDoItems.Remove(item);
            }
            await Task.CompletedTask;
        }
    }
}
