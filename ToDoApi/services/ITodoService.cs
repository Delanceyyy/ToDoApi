using ToDoApi.Models;
using ToDoApi.Entity;

namespace ToDoApi.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItemDto>> GetAllAsync();
        Task<TodoItemDto?> GetByIdAsync(int id);
        Task<TodoItem> CreateAsync(CreateTodoDto dto);
        Task<bool> UpdateAsync(int id, UpdateTodoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}