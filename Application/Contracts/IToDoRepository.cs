using Domain.Entities;

namespace Application.Contracts
{
    public interface IToDoRepository
    {
        Task<List<ToDoItem>> GetAllAsync();
        Task<ToDoItem?> GetByIdAsync(int id);
        Task<ToDoItem> Create(ToDoItem item);
        Task DeleteAsync(int id);
    }
}
